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
    class NegativeSpeedPowerUp : PowerUp
    {
        public NegativeSpeedPowerUp()
        {
            Position = new Point(500, 500);
            Texture = new PictureBox();
            Texture.Name = "pbPowerUp SpeedoNegativo";
            Texture.BackColor = Color.Transparent;
            Velocity = new Point(1, 0);
        }

        //public override void Activate()
        //{
        //    target.CurrentSpeed = target.CurrentSpeed - 5;
        //}
        public override void MakePowerUp()
        {
            image = "PowerUpNegative.png";
            name = "-normal";
            Console.WriteLine("Making power up " + name);
        }
        //public override void setTarget(MovingWall target)
        //{
        //    this.target = target;
        //}
    }
}
