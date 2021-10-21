using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    public class ExplodePowerUpMaking : PowerUpMaking
    {
        protected override PowerUp MakePowerUp(int typeOfPowerup)
        {
            PowerUp thePowerUp = null;
            if (typeOfPowerup.Equals(0))
            {
                PowerUpFactory powerUpPartsFactory = new ExplodePowerUpFactory();
                thePowerUp = new Explode(powerUpPartsFactory);
                //thePowerUp.SetData(new Point(100, 384), new Size(50, 50), Color.White); //later for random spawn position
            }
            return thePowerUp;
        }
    }
}
