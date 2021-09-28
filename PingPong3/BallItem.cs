using System.Drawing;

namespace PingPong3
{
    public class BallItem : GameItem
    {
        public void Update()
        {
            Position = new Point(Position.X + Velocity.X,
                Position.Y + Velocity.Y);
        }
    }
}
