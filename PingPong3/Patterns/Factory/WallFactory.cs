using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Strategy;
using System.Drawing;
using System.Windows.Forms;

namespace PingPong3.Patterns.Factory
{
    public class WallFactory
    {
        //1024, 768
        private int WallCount = 0;

        public Wall MakeWall(int Number)
        {
            if (Number == 0)
                return new StaticWall(WallCount++);
            else if (Number == 1)
                return new MovingWall(WallCount++);
            else return null;
        }
    }
}
