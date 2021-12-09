using PingPong3.Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    //public abstract class PowerUp : GameItem
    public abstract class PowerUp : Colleague
    {
        public string name;
        public string image;

        public PowerUp(IMediator medi): base(medi)
        {
            
        }

        public abstract void MakePowerUp();

        public void SetPowerUpImage(string NewImage)
        {
            this.image = NewImage;
        }

        public void SendPowerUpName()
        {
            mediator.BroadcastMessage(this, name);
        }

        //public override string SendMessage(String msg)
        //{
        //    return msg;
        //}
        //public virtual PowerUp SetData(Point position)
        //{
        //    return null;
        //}

        public string toString()
        {
            string infoOfPowerUp = "Power up " + name +" with image "+ image;
            return infoOfPowerUp;
        }

        //public abstract void Activate();
    }
}
