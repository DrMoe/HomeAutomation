namespace PluginBase
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class PluginAttribute : Attribute
    {
        public string Name { get; set; } = string.Empty;
    }
}
