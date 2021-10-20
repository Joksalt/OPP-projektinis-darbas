using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    public abstract class PowerUpMaking
    {
        protected abstract PowerUp MakePowerUp(string TypeOfPowerUp);
        public PowerUp OrderPowerUp(string TypeOfPowerUp)
        {
            PowerUp ThePowerUp = MakePowerUp(TypeOfPowerUp);

            ThePowerUp.MakePowerUp();
            //Random rand = new Random(); //later for adding random positions for powerups
            //int i = rand.Next(7);
            //ThePowerUp.SetData(new Point(792 - (30 * i), -90 + (30 * i)), new Size(30, 180), Color.White, -90, 90, new Point(0, 2));

                return ThePowerUp;
        }
    }
}
