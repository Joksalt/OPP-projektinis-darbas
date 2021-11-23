using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Decorator
{
    public class RacketMode1 : RacketDecorator
    {
        public RacketMode1(RacketStyle newSkin) : base(newSkin)
        {
            Console.WriteLine("Adding New Skin Mode 1");
        }
        public override string GetSkin()
        {
            base.GetSkin();
            return tempSkin.GetSkin() + "_2";
        }
        public override int GetSpeed()
        {
            base.GetSpeed();
            return tempSkin.GetSpeed() + 10;
        }
        public override int GetSoftness()
        {
            base.GetSoftness();
            return tempSkin.GetSoftness() + 10;
        }
    }
}
