using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    public class Explode : PowerUp
    {
        PowerUpFactory powerUpFactory;

        public Explode(PowerUpFactory powerUpFactory)
        {
            this.powerUpFactory = powerUpFactory;
            //SetName("Ball3.png");
        }
        public override void MakePowerUp()
        {
            Console.WriteLine("Making power up " + GetName());
            effect = powerUpFactory.addPUEffect();
        }

    }
}
