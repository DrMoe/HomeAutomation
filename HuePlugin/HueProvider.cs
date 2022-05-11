using HueApi;
using PluginBase;
using PluginBase.Models;

namespace HuePlugin
{
    [Plugin(Name = "HueProvider")]
    public class HueProvider : IPlugin
    {
        public HueProvider(string ip, string apiKey)
        {
            IP = ip;
            APIKey = apiKey;
        }
        public string IP { get; set; }
        public string APIKey { get; set; }

        public string Name => "Hue Provider";

        public string Description => "Provides connection to Hue products";

        private ServiceType MatchServiceType(string type)
        {
            switch (type.ToUpperInvariant())
            {
                case "LIGHT":
                    return ServiceType.Light;
                case "BRIDGE":
                    return ServiceType.Bridge;
                case "ZIGBEE_CONNECTIVITY":
                    return ServiceType.Connectivity;
                case "MOTION":
                    return ServiceType.Motion;
                case "DEVICE_POWER":
                    return ServiceType.DevicePower;
                case "LIGHT_LEVEL":
                    return ServiceType.LightLevel;
                case "TEMPERATURE":
                    return ServiceType.Temperature;
                case "BUTTON":
                    return ServiceType.Button;
                default:
                    return ServiceType.Unknown;
            }
        }

        public async Task<List<Device>> DiscoverDevices()
        {
            var devicesList = new List<Device>();

            var localHueClient = new LocalHueApi(IP, APIKey);
            var devices = await localHueClient.GetDevicesAsync().ConfigureAwait(false);

            if (devices.HasErrors)
            {

            }
            else
            {
                foreach (var device in devices.Data)
                {
                    if (device != null)
                    {
                        var deviceType = DeviceType.Bridge;
                        var services = new List<Service>();

                        if(device.IdV1.Contains("lights"))
                        {
                            deviceType = DeviceType.Light;
                        }

                        if (device.IdV1.Contains("sensors"))
                        {
                            if (device.ProductData.ProductName.Contains("switch"))
                            {
                                deviceType = DeviceType.Switch;
                            }
                            else
                            {
                                deviceType = DeviceType.Motion;
                            }
                        }

                        foreach (var item in device.Services)
                        {
                            var service = new Service
                            {
                                ServiceId = item.Rid,
                                ServiceName = item.Rtype,
                                ServiceType = MatchServiceType(item.Rtype)
                            };

                            services.Add(service);
                        }

                        devicesList.Add(new Device
                        {
                            Name = device.Metadata.Name,
                            DeviceId = device.Id,
                            Product = device.ProductData.ProductName,
                            ProductFamily = "Hue",
                            Type = deviceType,
                            Services = services
                        });
                    }
                }
            }

            return devicesList;

        }

        public Task<Device> GetDevice(Guid deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetDeviceServices(Guid deviceId)
        {
            throw new NotImplementedException();
        }

        public Task GetServiceProperty(Guid serviceId, ServiceType serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
