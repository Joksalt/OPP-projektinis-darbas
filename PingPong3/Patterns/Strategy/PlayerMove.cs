using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PingPong3.Patterns.Factory;
using System.Windows.Forms;
using PingPong3.Patterns.Mediator;
using PingPong3.Patterns.Decorator;

namespace PingPong3.Patterns.Strategy
{
    public class PlayerMove : Move
    {
        public PlayerMove(int i, IMediator medi, RacketStyle normalRacket, RacketStyle defaultRacket)
        {
            movingWall = new MovingWall(i, medi, normalRacket, defaultRacket);
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
