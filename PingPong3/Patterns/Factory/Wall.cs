using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using PingPong3.Patterns.Strategy;

namespace PingPong3.Patterns.Factory
{
    public abstract class Wall : GameItem
    {
        public virtual Wall SetData()
        {
            return null;
        }
        public virtual Wall SetData(Point position, Size size, Color color)
        {
            return null;
        }
        public virtual Wall SetData(Point position, Size size, Color color, int start, int end, Point speed)
        {
            return null;
        }

        public virtual Wall SetMove(Move move)
        {
            return null;
        }
    }
}
