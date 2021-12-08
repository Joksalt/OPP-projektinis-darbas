using PingPong3.Patterns.Factory;
using PingPong3.Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong3.Patterns.AbstractFactory
{
    class PositiveSpeedPowerUp : PowerUp
    {
        public PositiveSpeedPowerUp(IMediator medi): base(medi)
        {
            Position = new Point(500, 500);
            Texture = new PictureBox();
            Texture.Name = "pbPowerUp Speedo Positivo";
            Texture.BackColor = Color.Transparent;
            Velocity = new Point(1, 0);
        }

        //public override void Activate()
        //{
        //    target.CurrentSpeed = target.CurrentSpeed + 50; ;
        //}
        public override void MakePowerUp()
        {
            image = "PowerUp.png";
            name = "+normal";
            Console.WriteLine("Making power up " + name);
        }

        public override void ReceiveMessage(string msg)
        {
            throw new NotImplementedException();
        }

        public override void SendMessage(string msg)
        {
            throw new NotImplementedException();
        }
        //public override void setTarget(MovingWall target)
        //{
        //    this.target = target;
        //}
    }
}
