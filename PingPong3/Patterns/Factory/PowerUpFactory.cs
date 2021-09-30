using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Factory
{
    public class PowerUpFactory
    {
        public PowerUp MakePowerUp(int randomNumber)
        {
            PowerUp newPowerUp = null;

            if (randomNumber == 0)
            {
                return new Speed();

            }
            else if (randomNumber == 1)
            {
                return new Explode();
            }
            else if (randomNumber == 3)
            {
                return new Split();
            }
            else return null;
        }
    }
}
