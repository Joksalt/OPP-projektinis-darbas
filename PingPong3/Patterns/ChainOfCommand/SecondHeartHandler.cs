using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PingPong3.Patterns.Template;

namespace PingPong3.Patterns.ChainOfCommand
{
    class SecondHeartHandler : HeartHandler
    {
        public override void SetData(PictureBox c, GameItem h, GoalTemplate f, int x)
        {
            context = c;
            heart = h;
            form = f;
            heart.Position = new Point(x, 40);
            c.Controls.Add(heart.Texture);
        }
        public override void SetSuccessor(HeartHandler s)
        {
            successor = s;
        }
        public override void HandleRequest(int i)
        {
            if (i == 2)
                heart.Remove();
            else
                successor.HandleRequest(i);
        }
    }
}
