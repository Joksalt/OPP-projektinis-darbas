using PingPong3.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    class PositiveSpeedPowerUp : SpeedPowerUp
    {
        public override void Activate()
        {
            target.CurrentSpeed = target.CurrentSpeed + 5; ;
        }
        public override void MakePowerUp()
        {
            image = "PowerUp.png";
            name = "Speed Power Up";
            Console.WriteLine("Making power up " + name);
        }
        public override void setTarget(MovingWall target)
        {
            this.target = target;
        }
    }
}
