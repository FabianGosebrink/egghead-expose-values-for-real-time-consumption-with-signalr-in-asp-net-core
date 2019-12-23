using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace server.Hubs
{
    public class MessagesHub : Hub
    {
        public async Task SendMessage(string chatMessage)
        {
            await Clients.All.SendAsync("Sendback", chatMessage);
        }
    }
}