using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PingPong3.Patterns.Factory;

namespace PingPong3.Patterns.AbstractFactory
{
    class PositiveSoftnessPowerUp : PowerUp
    {
        //public override void Activate()
        //{
        //    target.CurrentSpeed = target.CurrentSpeed + 5;
        //}
        public PositiveSoftnessPowerUp()
        {
            Position = new Point(450, 500);
            Texture = new PictureBox();
            Texture.Name = "pbPowerUp +Softness";
            Texture.BackColor = Color.Transparent;
            Velocity = new Point(1, 0);
        }
        public override void MakePowerUp()
        {
            image = "PowerUp.png";
            name = "+Softness Power Up";
            Console.WriteLine("Making power up " + name);
        }
        //public override void setTarget(MovingWall target)
        //{
        //    this.target = target;
        //}
    }
}
