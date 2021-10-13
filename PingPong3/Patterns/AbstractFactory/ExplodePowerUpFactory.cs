using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    public class ExplodePowerUpFactory : PowerUpFactory
    {
        public PUEffect addPUEffect()
        {
            return new PUPowerUpEffect();
        }
    }
}
