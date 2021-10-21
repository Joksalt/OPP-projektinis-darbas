using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Decorator
{
    public class BackgroundSkin : GameDecorator
    {
        public BackgroundSkin(Skin newSkin) : base(newSkin)
        {
            Console.WriteLine("Adding background");
        }
        public string GetDescription()
        {
            return tempSkin.GetDescription() + "!!!!Shit";
        }
        public int GetCost()
        {
            return tempSkin.GetCost() + 1;
        }
    }
}
