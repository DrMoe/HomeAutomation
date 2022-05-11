using DataHandler.DataInterface;
using DataHandler.Models;
using PluginBase;

namespace Home_Automation.Utilities
{
    public class DeviceUtility : IDeviceUtility
    {
        private readonly IDeviceService _deviceService;
        private readonly IPlugin _pluginProvider;
        public DeviceUtility(IDeviceService deviceService, IPlugin pluginProvider)
        {
            _deviceService = deviceService;
            _pluginProvider = pluginProvider;
        }
        public void AddDevice()
        {
            throw new NotImplementedException();
        }

        public List<Device> GetDevices()
        {
            var devices = _deviceService.GetDevices();
            return devices;
        }

        public async Task SearchForNewDevices()
        {
            var devices = _pluginProvider.DiscoverDevices().Result;
            var exsistingDevices = _deviceService.GetDevices();

            var deviceTypes = _deviceService.GetDeviceTypes();
            var serviceTypes = _deviceService.GetServiceTypes();
            var productFamilies = _deviceService.GetProductFamilies();

            foreach (var item in devices)
            {
                if (!exsistingDevices.Any(x => x.Id == item.DeviceId))
                {
                    var deviceNew = new Device();
                    deviceNew.Name = item.Name;
                    deviceNew.Id = item.DeviceId;
                    deviceNew.ProductName = item.Product;


                    deviceNew.DeviceTypeId = deviceTypes.FirstOrDefault(x => x.DeviceTypeName == item.Type.ToString()).DeviceTypeId;
                    deviceNew.ProductFamilyId = productFamilies.FirstOrDefault(x => x.ProductName == "Philips Hue").ProductFamilyId;

                    _deviceService.Add(deviceNew);

                    foreach (var service in item.Services)
                    {
                        var serviceNew = new Service();
                        serviceNew.Id = service.ServiceId;
                        serviceNew.ServiceName = service.ServiceName;
                        serviceNew.DeviceId = deviceNew.DeviceId;
                        serviceNew.ServiceTypeId = serviceTypes.FirstOrDefault(x => x.ServiceName.Replace(" ", "") == service.ServiceType.ToString()).ServiceTypeId;

                        _deviceService.Add(serviceNew);
                    }

                }
            }
        }
    }
}
