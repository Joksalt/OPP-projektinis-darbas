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
    class HorizontallyMovingWall : MovingWall
    {
        public HorizontallyMovingWall(int i)
        {
            Position = new Point(500, 500);
            Texture = new PictureBox();
            Texture.Name = "pbWall" + i.ToString();
            Texture.Size = new Size(100, 10);
            Texture.BackColor = Color.White;

            Start = 0;
            End = 100;
            Velocity = new Point(1, 0);
        }
        public override Wall SetData(Point position, Size size, Color color, int start, int end, int speed)
        {
            Position = position;
            Texture.Size = size;
            Texture.BackColor = color;

            Start = start;
            End = end;
            Velocity = new Point(speed, 0);
            return this;
        }
        public override void Move()
        {
            Position = new Point(Position.X + Velocity.X, Position.Y);

            if (Position.X < Start)
            {
                Position = new Point(Start, Position.Y);
                Velocity = new Point(-Velocity.X, 0);
            }

            if (Position.X > End)
            {
                Position = new Point(End, Position.Y);
                Velocity = new Point(-Velocity.X, 0);
            }//Draw();
        }
    }
}
