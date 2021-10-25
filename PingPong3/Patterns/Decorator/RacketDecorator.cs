using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Decorator
{
    public abstract class RacketDecorator : RacketStyle
    {
        protected RacketStyle tempSkin;

        public RacketDecorator(RacketStyle newSkin)
        {
            this.tempSkin = newSkin;
        }
        public override string GetSkin()
        {
            return tempSkin.GetSkin();
        }
        public override int GetSpeed()
        {
            return tempSkin.GetSpeed();

        }
        public override int GetSoftness()
        {
            return tempSkin.GetSoftness();

        }
    }
}
