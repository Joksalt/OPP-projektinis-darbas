using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    class NegativePowerUpFactory : PowerUpFactory
    {
        protected override PowerUp MakePowerUp(int typeOfPowerup)
        {
            PowerUp thePowerUp = null;
            if (typeOfPowerup.Equals(0))
            {
                thePowerUp = new Explode();
                //thePowerUp.SetData(new Point(100, 384), new Size(50, 50), Color.White); //later for random spawn position
            }
            else if (typeOfPowerup.Equals(1))
            {
                thePowerUp = new NegativeSpeedPowerUp();
                //thePowerUp.SetData(new Point(100, 384), new Size(50, 50), Color.White); //later for random spawn position
            }
            else if (typeOfPowerup.Equals(2))
            {
                thePowerUp = new NegativeSplitPowerUp();
                //thePowerUp.SetData(new Point(100, 384), new Size(50, 50), Color.White); //later for random spawn position
            }
            return thePowerUp;
        }
    }
}
