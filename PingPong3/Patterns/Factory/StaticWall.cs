using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong3.Patterns.Factory
{
    class StaticWall : Wall
    {
        public StaticWall(int i)
        {
            Position = new Point(500, 500);
            Texture = new PictureBox();
            Texture.Name = "pbWall" + i.ToString();
            Texture.Size = new Size(100, 10);
            Texture.BackColor = Color.White;
        }

        public override Wall SetData(Point position, Size size, Color color)
        {
            Position = position;
            Texture.Size = size;
            Texture.BackColor = color;
            return this;
        }
    }
}
