using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Decorator
{
    public class DefaultRacketMode : RacketStyle
    {
        public override int GetSpeed()
        {
            return 30;
        }

        public override string GetSkin()
        {
            return "Paddle1";
        }
        public override int GetSoftness()
        {
            return 0;
        }
    }
}
