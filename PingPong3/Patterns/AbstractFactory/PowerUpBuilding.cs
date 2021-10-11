using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    public abstract class PowerUpBuilding
    {
        protected abstract PowerUp makePowerUp(string TypeOfPowerUp);
        public PowerUp OrderPowerUp(string TypeOfPowerUp)
        {
            PowerUp ThePowerUp = makePowerUp(TypeOfPowerUp);

            ThePowerUp.MakePowerUp();
            ThePowerUp.GetName();

            return ThePowerUp;
        }
    }
}
