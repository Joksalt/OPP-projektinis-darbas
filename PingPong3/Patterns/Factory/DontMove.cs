using System;
using System.Collections.Generic;
using System.Drawing;
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
            SetHeight(50);
            SetWidth(500);
            SetColor(Color.White);
        }
       
    }
}
