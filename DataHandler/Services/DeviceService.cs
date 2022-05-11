using DataHandler.Data;
using DataHandler.Models;
using DataHandler.Services;
using Microsoft.EntityFrameworkCore;

namespace DataHandler.DataInterface
{
    public class DeviceService : BaseService, IDeviceService
    {
        public List<Device> GetDevices()
        {
            using (var context = new HomeautomationContext())
            {
                var devices = context.Device.Include(x => x.Service).ToList();

                return devices;
            }
        }

        public List<Service> GetServices()
        {
            using (var context = new HomeautomationContext())
            {
                var services = context.Service.Include(x => x.Device).ToList();

                return services;
            }
        }

        public List<DeviceType> GetDeviceTypes()
        {
            using (var context = new HomeautomationContext())
            {
                var deviceTypes = context.DeviceType.ToList();

                return deviceTypes;
            }
        }

        public List<ProductFamily> GetProductFamilies()
        {
            using (var context = new HomeautomationContext())
            {
                var productFamily = context.ProductFamily.ToList();

                return productFamily;
            }
        }

        public List<ServiceType> GetServiceTypes()
        {
            using (var context = new HomeautomationContext())
            {
                var serviceTypes = context.ServiceType.ToList();

                return serviceTypes;
            }
        }
    }
}