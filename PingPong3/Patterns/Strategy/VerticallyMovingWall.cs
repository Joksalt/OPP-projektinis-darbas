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
    public class VerticallyMovingWall : MovingWall
    {
        public VerticallyMovingWall(int i)
        {
            Position = new Point(500, 500);
            Texture = new PictureBox();
            Texture.Name = "pbWall" + i.ToString();
            Texture.Size = new Size(100, 10);
            Texture.BackColor = Color.White;

            Start = 0;
            End = 100;
            Velocity = new Point(0, 1);
        }
        public override Wall SetData(Point position, Size size, Color color, int start, int end, int speed)
        {
            Position = position;
            Texture.Size = size;
            Texture.BackColor = color;

            Start = start;
            End = end;
            Velocity = new Point(0, speed);
            
            return this;
        }
        public override void Move()
        {
            Position = new Point(Position.X, Position.Y + Velocity.Y);

            if (Position.Y < Start)
            {
                Position = new Point(Position.X, Start);
                Velocity = new Point(0, -Velocity.Y);
            }

            if (Position.Y > End)
            {
                Position = new Point(Position.X, End);
                Velocity = new Point(0, -Velocity.Y);
            }//Draw();
        }
    }
}
