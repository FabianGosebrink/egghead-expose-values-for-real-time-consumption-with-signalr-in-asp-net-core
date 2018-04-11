using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace server.Hubs
{
    public class MessagesHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Sendback", message);
        }
    }
}