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
    public class MoveHorizontally : Move
    {
        public MoveHorizontally(int i, IMediator medi)
        {
            movingWall = new MovingWall(i, medi);
        }
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
