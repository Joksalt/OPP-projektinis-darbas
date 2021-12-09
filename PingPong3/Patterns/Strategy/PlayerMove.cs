using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PingPong3.Patterns.Factory;
using System.Windows.Forms;
using PingPong3.Patterns.Mediator;

namespace PingPong3.Patterns.Strategy
{
    public class PlayerMove : Move
    {
        public PlayerMove(int i, IMediator medi)
        {
            movingWall = new MovingWall(i, medi);
        }
        public PlayerMove(Wall wall)
        {
            movingWall = wall as MovingWall;
        }
        public override void MoveAction()
        {
            movingWall.Position = new Point(movingWall.Position.X, movingWall.Position.Y + movingWall.Velocity.Y);
        }
    }
}
