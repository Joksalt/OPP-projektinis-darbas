using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Decorator
{
    public class GameSkin1 : Skin
    {
        public int GetCost()
        {
            Console.WriteLine("Cost of Dough: " + 4.00);
            return 4;
        }

        public string GetDescription()
        {
            return "Thin Ass";
        }
    }
}
