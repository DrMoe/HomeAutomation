using PluginBase.Models;

namespace PluginBase
{
    public interface IPlugin
    {
     
        /// <summary>
        /// Name of the plugin.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Decription of the plugin.
        /// </summary>
        string Description { get; }

        string IP { get; }
        string APIKey { get; }


        /// <summary>
        /// Discover exsisting devices on the network.
        /// </summary>
        /// <returns>List of discovered devices</returns>
        Task<List<Device>> DiscoverDevices();

        Task<Device> GetDevice(Guid deviceId);

        Task<Service> GetDeviceServices(Guid deviceId);
        Task GetServiceProperty(Guid serviceId, ServiceType serviceType);
    }
}