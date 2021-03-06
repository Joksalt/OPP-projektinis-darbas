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
        public async Task SendRacketSpeedChange(int s)
        {
            await Clients.All.SendAsync("RecieveRacketSpeedChange", s);
        }
        public async Task SendPowerUpChange(int powerUp)
        {
            await Clients.All.SendAsync("RecievePowerUpChange", powerUp);
        }
        public async Task SendPlayer1HitBool(bool Player1Hit)
        {
            await Clients.All.SendAsync("RecievePlayer1HitBool", Player1Hit);
        }
        public async Task SendRacketSkin(string racket)
        {
            await Clients.All.SendAsync("RecieveRacketSkin", racket);
        }
        public async Task SendRacketSkin2(string racket)
        {
            await Clients.All.SendAsync("RecieveRacketSkin2", racket);
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
        //Symuciakas
        public async Task SendPlayerSize(int size, int player)
        {
            await Clients.All.SendAsync("ReceivePlayerSize", size, player);
        }
        public async Task SendPlayerSpeed(int speed, int player)
        {
            await Clients.All.SendAsync("ReceivePlayerSpeed", speed, player);
        }
    }
}
