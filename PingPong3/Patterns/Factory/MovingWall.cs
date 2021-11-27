using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Strategy;
using System.Windows.Forms;

namespace PingPong3.Patterns.Factory
{
    public class MovingWall : Wall
    {
        public const int BaseSpeed = 30;
        public int CurrentSpeed = BaseSpeed;
        public Move move;
        public int Start { get; set; }
        public int End { get; set; }
        public MovingWall(int i)
        {
            Position = new Point(50, 50);
            Texture = new PictureBox();
            Texture.Name = "pbWall" + i.ToString();
            Texture.Size = new Size(20, 10);
            Texture.BackColor = Color.White;

            Start = 10;
            End = 100;
            Velocity = new Point(1, 1);
        }
        public override Wall SetData(Point position, Size size, Color color, int start, int end, Point speed)
        {
            Position = position;
            Texture.Size = size;
            Texture.BackColor = color;

            Start = start;
            End = end;
            Velocity = new Point(speed.X, speed.Y);
            return this;
        }
        public void Move()
        {
            move.MoveAction();
        }
        //Geras sablonas bet neveikia
        public override Wall SetMove(Move move)
        {
            this.move = move;
            return this;
        }
    }
}
