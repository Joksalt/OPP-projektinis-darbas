using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    public class ExplodePowerUpMaking : PowerUpMaking
    {
        protected override PowerUp MakePowerUp(String typeOfPowerup)
        {
            PowerUp thePowerUp = null;
            if (typeOfPowerup.Equals("E"))
            {
                PowerUpFactory powerUpPartsFactory = new ExplodePowerUpFactory();
                thePowerUp = new Explode(powerUpPartsFactory);
                thePowerUp.name = "EXPLOSION";
            }
            return thePowerUp;
        }
        
    }
}
