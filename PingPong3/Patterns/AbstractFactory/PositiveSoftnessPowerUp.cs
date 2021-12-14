using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PingPong3.Patterns.Factory;
using PingPong3.Patterns.Mediator;

namespace PingPong3.Patterns.AbstractFactory
{
    class PositiveSoftnessPowerUp : PowerUp
    {
        //public override void Activate()
        //{
        //    target.CurrentSpeed = target.CurrentSpeed + 5;
        //}
        public PositiveSoftnessPowerUp(IMediator medi) : base(medi)
        {
            Position = new Point(450, 500);
            Texture = new PictureBox();
            Texture.Name = "pbPowerUp +Softness";
            Texture.BackColor = Color.Transparent;
            Velocity = new Point(1, 0);
        }

        public override ColleagueType GetColleagueType()
        {
            return ColleagueType.powerUp;
        }

        public override void MakePowerUp()
        {
            image = "PowerUp.png";
            name = "+Softness Power Up";
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
