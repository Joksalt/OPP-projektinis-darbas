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
    public class MoveVertically : Move
    {
        public MoveVertically(int i, IMediator medi, RacketStyle normalRacket, RacketStyle defaultRacket)
        {
            movingWall = new MovingWall(i, medi, normalRacket, defaultRacket);
        }
        public MoveVertically(Wall wall)
        {
            movingWall = wall as MovingWall;
        }
        public override void MoveAction()
        {
            movingWall.Position = new Point(movingWall.Position.X, movingWall.Position.Y + movingWall.Velocity.Y);

            if (movingWall.Position.Y < movingWall.Start)
            {
                movingWall.Position = new Point(movingWall.Position.X, movingWall.Start);
                movingWall.Velocity = new Point(0, -movingWall.Velocity.Y);
            }

            if (movingWall.Position.Y > movingWall.End)
            {
                movingWall.Position = new Point(movingWall.Position.X, movingWall.End);
                movingWall.Velocity = new Point(0, -movingWall.Velocity.Y);
            }
        }
    }
}
