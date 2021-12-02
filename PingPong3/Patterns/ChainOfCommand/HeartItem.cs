using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong3.Patterns.ChainOfCommand
{
    public class HeartItem : GameItem
    {
        public HeartItem(String s)
        {
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin\\Debug"));
            path = path + "Images\\";

            Position = new Point(10000, 10000);
            Texture = new PictureBox();
            Texture.Name = s;
            Texture.Size = new Size(40, 40);
            Texture.BackColor = Color.Transparent;
            Texture.Load(path + "Heart.png");
        }
    }
}
