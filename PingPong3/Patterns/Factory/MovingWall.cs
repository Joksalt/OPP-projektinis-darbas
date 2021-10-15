using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Factory
{
    public abstract class MovingWall : Wall
    {
        public int Start { get; set; }
        public int End { get; set; }
        public abstract void Move();
    }
}
