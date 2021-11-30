using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns
{
    public class TestingMisc
    {
        public int GenerateBallVelocityX(int seed)
        {
            if (seed < 0)
            {
                return -1;
            }
            else if (seed < 2)
            {
                return 2;
            }
            return 0;
        }
    }
}
