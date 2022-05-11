using DataHandler.Models;
using DataHandler.Services;

namespace DataHandler.DataInterface
{
    public interface IDeviceService : IBaseService
    {
        List<Device> GetDevices();
        List<Service> GetServices();
        List<DeviceType> GetDeviceTypes();
        List<ServiceType> GetServiceTypes();
        List<ProductFamily> GetProductFamilies();
    }
}