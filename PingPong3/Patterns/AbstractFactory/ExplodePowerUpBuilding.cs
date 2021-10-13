using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    public class ExplodePowerUpBuilding : PowerUpBuilding
    {
        protected override PowerUp MakePowerUp(String typeOfPowerup)
        {
            PowerUp thePowerUp = null;
            if (typeOfPowerup.Equals("UFO"))
            {
                PowerUpFactory powerUpPartsFactory = new ExplodePowerUpFactory();
                thePowerUp = new Explode(powerUpPartsFactory);
                thePowerUp.SetName("UFO GRUNT SHIP");
            }
            return thePowerUp;
        }
        
    }
}
