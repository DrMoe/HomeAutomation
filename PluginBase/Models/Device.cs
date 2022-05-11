namespace PluginBase.Models
{
    public class Device
    {
        public Device()
        {
            Services = new List<Service>();
        }
        public string Name { get; set; }
        public Guid DeviceId { get; set; }
        public DeviceType Type { get; set; }
        public string Product { get; set; }
        public string ProductFamily { get; set; }
        public List<Service> Services { get; set; }
    }

    public enum DeviceType
    {
        Bridge = 0,
        Light = 1,
        Motion = 2,
        Switch = 3,
        Plug = 4,
        Unknown = 5
    }
}