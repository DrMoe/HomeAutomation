using DataHandler.DataInterface;
using EventOperation.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
public class EventRunner
{
    private static async Task Main(string[] args)
    {
        try
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddScoped<IDeviceService, DeviceService>()).Build();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false);

            var config = builder.Build();
            var ip = config.GetSection("Hue:IP").Value;
            var APIKey = config.GetSection("Hue:APIKey").Value;


            var hueRunner = new HueRunner(host.Services.CreateScope().ServiceProvider.GetRequiredService<IDeviceService>(), ip, APIKey);
            await hueRunner.Run();

            Console.Read();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error" + e.Message);
        }
    }
}