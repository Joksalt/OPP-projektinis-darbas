using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Factory;

namespace PingPong3.Patterns.AbstractFactory
{
    class NegativeSoftnessPowerUp : PowerUp
    {
        //public override void Activate()
        //{
        //    target.CurrentSpeed = target.CurrentSpeed - 5;
        //}
        public override void MakePowerUp()
        {
            image = "PowerUp.png";
            name = "-Split Power Up";
            Console.WriteLine("Making power up " + name);
        }
        //public override void setTarget(MovingWall target)
        //{
        //    this.target = target;
        //}
    }
}
