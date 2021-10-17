using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PingPong3.Patterns.Factory;
using System.Windows.Forms;

namespace PingPong3.Patterns.Strategy
{
    public class MoveVertically : Move
    {
        MovingWall movingWall;
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
