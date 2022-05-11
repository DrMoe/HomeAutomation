using DataHandler.Models;

namespace Home_Automation.Utilities
{
    public interface IDeviceUtility
    {
        List<Device> GetDevices();
        void AddDevice();
        Task SearchForNewDevices();
    }
}