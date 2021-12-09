using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Strategy;
using System.Drawing;
using System.Windows.Forms;
using PingPong3.Patterns.Mediator;
using PingPong3.Patterns.Decorator;

namespace PingPong3.Patterns.Factory
{
    public class WallFactory
    {
        //1024, 768
        private int WallCount = 0;

        public Wall MakeWall(int Number, IMediator medi, RacketStyle normalRacket, RacketStyle defaultRacket)
        {
            if (Number == 0)
                return new StaticWall(WallCount++, medi);
            else if (Number == 1)
                return new MovingWall(WallCount++, medi, normalRacket, defaultRacket);
            else return null;
        }
    }
}
