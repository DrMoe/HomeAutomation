using Microsoft.AspNetCore.SignalR;

namespace Home_Automation.Hubs
{
    public class EventHub : Hub
    {
        public async Task DeviceEvent(string device, string value)
        {
            await Clients.All.SendAsync("DeviceEvent", device, value);
        }
    }
}
