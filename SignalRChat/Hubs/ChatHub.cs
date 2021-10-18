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
        public async Task SendWallChange(int random)
        {
            await Clients.All.SendAsync("RecieveWallChange", random);
        }
        public async Task SendPlayer2Position(int x, int y)
        {
            await Clients.Others.SendAsync("ReceivePlayer2Position", x, y);
        }
        public async Task SendPlayer1Position(int x, int y)
        {
            await Clients.Others.SendAsync("ReceivePlayer1Position", x, y);
        }
        /// <summary>
        /// Send to all, so you would send the signal to yourself as well
        /// And would start the game synchronously
        /// </summary>
        /// <param name="gameMode"></param>
        /// <returns></returns>
        public async Task SendStartSignal(int gameMode)
        {
            await Clients.All.SendAsync("ReceiveStartSignal", gameMode);
        }
        /// <summary>
        /// Send to all, so you would send the signal to yourself as well
        /// And would reset the ball synchronously
        /// </summary>
        /// <param name="velocityX"></param>
        /// <param name="velocityY"></param>
        /// <returns></returns>
        public async Task SendResetBallSignal(int velocityX, int velocityY)
        {
            await Clients.All.SendAsync("ReceiveResetBallSignal", velocityX, velocityY);
        }
        public async Task SendScoreSignal(int score, int player)
        {
            await Clients.All.SendAsync("ReceiveScoreSignal", score, player);
        }
        public async Task SendBallVelocityDirection1(int positionX, int positionY, int velocityX, int velocityY)
        {
            await Clients.All.SendAsync("ReceiveBallVelocityDirection1", positionX, positionY, velocityX, velocityY);
        }
        public async Task SendBallVelocityDirection2(int positionX, int positionY, int velocityX, int velocityY)
        {
            await Clients.All.SendAsync("ReceiveBallVelocityDirection2", positionX, positionY, velocityX, velocityY);
        }
    }
}
