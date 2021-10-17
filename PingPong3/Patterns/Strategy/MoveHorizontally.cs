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
    class MoveHorizontally : Move
    {
        MovingWall movingWall;
        public MoveHorizontally(Wall wall)
        {
             movingWall = wall as MovingWall;
        }
        
        public override void MoveAction()
        {
            movingWall.Position = new Point(movingWall.Position.X + movingWall.Velocity.X, movingWall.Position.Y);

            if (movingWall.Position.X < movingWall.Start)
            {
                movingWall.Position = new Point(movingWall.Start, movingWall.Position.Y);
                movingWall.Velocity = new Point(-movingWall.Velocity.X, 0);
            }

            if (movingWall.Position.X > movingWall.End)
            {
                movingWall.Position = new Point(movingWall.End, movingWall.Position.Y);
                movingWall.Velocity = new Point(-movingWall.Velocity.X, 0);
            }
        }
    }
}
