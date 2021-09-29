using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user,message);
        }

        public async Task SendPlayer2Position(int x, int y)
        {
            await Clients.Others.SendAsync("ReceivePlayer2Position", x, y);
        }

        public async Task SendPlayer1Position(int x, int y)
        {
            await Clients.Others.SendAsync("ReceivePlayer1Position", x, y);
        }

        public async Task SendStartSignal(int gameMode)
        {
            await Clients.Others.SendAsync("ReceiveStartSignal", gameMode);
        }
    }
}
