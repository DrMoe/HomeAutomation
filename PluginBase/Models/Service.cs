namespace PluginBase.Models
{
    public class Service
    {
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public ServiceType ServiceType { get; set; }
    }

    public enum ServiceType
    {
        Light = 0,
        Bridge = 1,
        Connectivity = 2,
        Motion = 3,
        DevicePower = 4,
        LightLevel = 5,
        Temperature = 6,
        Button = 7,
        Unknown = 8
    }
}