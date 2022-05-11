using DataHandler.DataInterface;
using Home_Automation.Utilities;
using HuePlugin;
using PluginBase;
using Home_Automation.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();


var hueIp = builder.Configuration["Hue:IP"];
var hueAPIKey = builder.Configuration["Hue:APIKey"];


builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IDeviceUtility, DeviceUtility>();
builder.Services.AddScoped<IPlugin>(x =>
    new HueProvider(hueIp, hueAPIKey));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<EventHub>("/eventHub");

app.Run();
