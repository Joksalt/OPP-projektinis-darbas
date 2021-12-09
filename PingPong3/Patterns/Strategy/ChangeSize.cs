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
    public class ChangeSize : Move
    {
        public ChangeSize(int i, IMediator medi)
        {
            movingWall = new MovingWall(i, medi);
        }
        public ChangeSize(Wall wall)
        {
            movingWall = wall as MovingWall;
        }

        public override void MoveAction()
        {
            movingWall.Texture.Size = new Size(movingWall.Texture.Size.Width + movingWall.Velocity.X, movingWall.Texture.Size.Height + movingWall.Velocity.Y);

            if (movingWall.Texture.Size.Width < movingWall.Start)
            {
                movingWall.Texture.Size = new Size(movingWall.Start, movingWall.Texture.Size.Height-1);
                movingWall.Velocity = new Point(-movingWall.Velocity.X, -movingWall.Velocity.Y);
            }
            else if (movingWall.Texture.Size.Height < movingWall.Start)
            {
                movingWall.Texture.Size = new Size(movingWall.Texture.Size.Width-1, movingWall.Start);
                movingWall.Velocity = new Point(-movingWall.Velocity.X, -movingWall.Velocity.Y);
            }

            if (movingWall.Texture.Size.Width > movingWall.End)
            {
                movingWall.Texture.Size = new Size(movingWall.End, movingWall.Texture.Size.Height-1);
                movingWall.Velocity = new Point(-movingWall.Velocity.X, -movingWall.Velocity.Y);
            }
            else if (movingWall.Texture.Size.Height > movingWall.End)
            {
                movingWall.Texture.Size = new Size(movingWall.Texture.Size.Width-1, movingWall.End);
                movingWall.Velocity = new Point(-movingWall.Velocity.X, -movingWall.Velocity.Y);
            }
        }
    }
}
