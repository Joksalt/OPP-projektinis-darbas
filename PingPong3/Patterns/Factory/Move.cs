using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Factory
{
    class Move : Wall
    {
        public Move()
        {
            //explode previously
            SetName("Ball3.png");
        }
    }
}
