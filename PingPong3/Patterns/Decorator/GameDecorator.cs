using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Decorator
{
    public abstract class GameDecorator : Skin
    {
        protected Skin tempSkin;

        public GameDecorator(Skin newSkin)
        {
            tempSkin = newSkin;
        }
        public int GetCost()
        {
            return tempSkin.GetCost();
        }

        public string GetDescription()
        {
            return tempSkin.GetDescription();
        }
    }
}
