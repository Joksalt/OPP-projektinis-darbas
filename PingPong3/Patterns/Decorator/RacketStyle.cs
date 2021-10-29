using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Decorator
{
    public abstract class RacketStyle
    {
        public abstract string GetSkin();
        public abstract int GetSpeed();
        public abstract int GetSoftness();

    }
}
