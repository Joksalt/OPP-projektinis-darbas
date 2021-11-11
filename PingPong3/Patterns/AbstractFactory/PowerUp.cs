using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    public abstract class PowerUp : GameItem
    {
        public string name;
        public string image;

        public abstract void MakePowerUp();

        public void SetPowerUpImage(string NewImage)
        {
            this.image = NewImage;
        }
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
