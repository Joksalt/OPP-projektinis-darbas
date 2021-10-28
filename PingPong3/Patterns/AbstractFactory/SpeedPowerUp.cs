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
    public abstract class SpeedPowerUp : PowerUp
    {
        public MovingWall target;
        public SpeedPowerUp()
        {
            /*Position = new Point(500, 500);
            Texture = new PictureBox();
            Texture.Name = "pbPowerUp Speed";
            Texture.BackColor = Color.Transparent;
            Velocity = new Point(1, 0);*/
        }
        /*public void MakePowerUp()
        {
            image = "PowerUp.png";
            name = "Speed Power Up";
            Console.WriteLine("Making power up " + name);
        }*/
        //public override PowerUp SetData(Point position) //later for random spawn pos
        //{
        //    Position = position;
        //    return this;
        //}

        public abstract void setTarget(MovingWall target);
    }
}


