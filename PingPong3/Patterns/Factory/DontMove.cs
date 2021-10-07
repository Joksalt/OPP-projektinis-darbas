using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Factory
{
    class DontMove:Wall
    {
        public DontMove()
        {
            //speed previously
            SetName("Ball1.png");
        }
       
    }
}
