using DataHandler.DataInterface;
using HueApi;
using HueApi.Models.Responses;
using Microsoft.AspNetCore.SignalR.Client;
using PluginBase.Models;

namespace EventOperation.Runner
{

    public class HueRunner
    {
        public string IP { get; set; }
        public string APIKey { get; set; }

        private static LocalHueApi localHueClient;
        private readonly IDeviceService _deviceService;

        public HueRunner(IDeviceService deviceService, string ip, string apiKey)
        {
            _deviceService = deviceService;
            IP = ip;
            APIKey = apiKey;
        }

        public async Task Run()
        {

            var devices = _deviceService.GetDevices();
            var services = _deviceService.GetServices();

            var connection = new HubConnectionBuilder().WithUrl("https://localhost:44304/eventHub").Build();

            localHueClient = new LocalHueApi(IP, APIKey);

            localHueClient.OnEventStreamMessage += EventStreamMessage;
            localHueClient.StartEventStream();

            Console.WriteLine();

            void EventStreamMessage(List<EventStreamResponse> events)
            {
                foreach (var hueEvent in events)
                {
                    foreach (var data in hueEvent.Data)
                    {
                        var ID = data.Id;
                       
                        var deviceItem = devices.FirstOrDefault(x => x.Id == ID);

                        if (deviceItem == null)
                        {
                            var serviceItem = services.FirstOrDefault(x => x.Id == ID);
                            deviceItem = devices.FirstOrDefault(x => x.Id == serviceItem.Device.Id);                          
                        }


                        foreach (var serviceItem in deviceItem.Service)
                        {
                            switch ((ServiceType)serviceItem.ServiceTypeId)
                            {
                                case ServiceType.Light:
                                    var light = localHueClient.GetLightAsync(serviceItem.Id).Result;
                                    break;
                                case ServiceType.Bridge:
                                    var bridge = localHueClient.GetBridgeAsync(serviceItem.Id).Result;
                                    break;
                                case ServiceType.Connectivity:
                                    var connectivity = localHueClient.GetZigbeeConnectivityAsync(serviceItem.Id).Result;
                                    break;
                                case ServiceType.Motion:
                                    var motion = localHueClient.GetMotionAsync(serviceItem.Id).Result;
                                    break;
                                case ServiceType.DevicePower:
                                    var devicePower = localHueClient.GetDevicePowerAsync(serviceItem.Id).Result;
                                    break;
                                case ServiceType.LightLevel:
                                    var lightLevel = localHueClient.GetLightLevelAsync(serviceItem.Id).Result;
                                    break;
                                case ServiceType.Temperature:
                                    var temperature = localHueClient.GetTemperatureAsync(serviceItem.Id).Result;
                                    break;
                                case ServiceType.Button:
                                    var button = localHueClient.GetButtonAsync(serviceItem.Id).Result;
                                    break;
                                default:
                                    break;
                            }
                        }

                        if (connection.State == HubConnectionState.Connected)
                        {
                            connection.InvokeAsync("DeviceEvent", "Hue Events", $"Data: {data.Metadata?.Name} / {data.IdV1}");
                        }
                        else
                        {
                            connection.StartAsync().ContinueWith(task =>
                            {
                                if (task.IsFaulted)
                                {
                                }
                                else
                                {
                                    connection.InvokeAsync("DeviceEvent", "Hue Events", $"Data: {data.Metadata?.Name} / {data.IdV1}");
                                }
                            }).Wait();
                        }
                    }
                }
            }
        }
    }
}
