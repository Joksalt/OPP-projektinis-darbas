using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PingPong3.Patterns.Template;

namespace PingPong3.Patterns.ChainOfCommand
{
    public abstract class HeartHandler
    {
        protected GoalTemplate form;
        protected PictureBox context;
        protected GameItem heart;
        protected HeartHandler successor;
        public abstract void SetData(PictureBox c, GameItem h, GoalTemplate f, int x);
        public abstract void SetSuccessor(HeartHandler s);
        public abstract void HandleRequest(int i);
    }
}
