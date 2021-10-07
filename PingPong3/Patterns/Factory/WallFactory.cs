using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Factory
{
    public class WallFactory
    {
        public Wall MakeWall(int Number)
        {

            if (Number == 0)
            {
                return new DontMove();

            }
            else if (randoNumbermNumber == 1)
            {
                return new Move();
            }
            else return null;
        }
    }
}
