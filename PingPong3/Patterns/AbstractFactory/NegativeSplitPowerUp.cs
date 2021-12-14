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
    class NegativeSplitPowerUp : PowerUp
    {
        public NegativeSplitPowerUp(IMediator medi) : base(medi)
        {
            Position = new Point(550, 500);
            Texture = new PictureBox();
            Texture.Name = "pbPowerUp Split";
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
            name = "Split Power Up";
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
        //public override PowerUp SetData(Point position) //later for random spawn pos
        //{
        //    Position = position;
        //    return this;
        //}
    }
}

