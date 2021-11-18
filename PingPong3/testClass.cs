using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3
{
    //Use as a library
    public class testClass
    {
        public Random _random;
        public int Test(int num)
        {
            if (num > 1)
            {
                return 1;
            }
            else return 0;
        }


        public int GenerateVelocityX(int level)
        {
            _random = new Random();
            int velocityX = level;
            if (_random.Next(2) == 0)
            {
                velocityX *= -1;
            }
            return velocityX;
        }
    }
}
