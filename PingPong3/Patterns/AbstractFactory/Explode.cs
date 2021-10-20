using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong3.Patterns.AbstractFactory
{
    public class Explode : PowerUp
    {
    
        PowerUpFactory powerUpFactory;

        public Explode(PowerUpFactory powerUpFactory)
        {
            this.powerUpFactory = powerUpFactory;
            Position = new Point(500, 500);
            Texture = new PictureBox();
            Texture.Name = "pbPowerUp Explode ";
            Texture.Size = new Size(100, 100);
            Texture.BackColor = Color.Red;

            Velocity = new Point(1, 0);
            //SetName("Ball3.png");
        }
        public override void MakePowerUp()
        {
            effect = powerUpFactory.addPUEffect();
            image = "Ball2.png";
            name = "Explosive Power Up";
            Console.WriteLine("Making power up " + name);
        }

    }
}
