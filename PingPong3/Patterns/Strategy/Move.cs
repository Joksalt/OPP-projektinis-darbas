using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Factory;
using System.Drawing;

namespace PingPong3.Patterns.Strategy
{
    public abstract class Move
    {
        public MovingWall movingWall;
        public abstract void MoveAction();
    }
}
