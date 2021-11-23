using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Decorator
{
    public class RacketMode2 : RacketDecorator
    {
        public RacketMode2(RacketStyle newSkin) : base(newSkin)
        {
            Console.WriteLine("Adding New Skin Mode 2");
        }
        public override string GetSkin()
        {
            base.GetSkin();
            return tempSkin.GetSkin() + "_3";
        }
        public override int GetSpeed()
        {
            base.GetSpeed();
            return tempSkin.GetSpeed() + 20;
        }
        public override int GetSoftness()
        {
            base.GetSoftness();
            return tempSkin.GetSoftness() + 20;
        }
    }
}
