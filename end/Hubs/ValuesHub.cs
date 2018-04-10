using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace egghead_expose_values_for_real_time_consumption_with_signalr_in_asp_net_core.Hubs
{
    public class ValuesHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Sendback", message);
        }
    }
}