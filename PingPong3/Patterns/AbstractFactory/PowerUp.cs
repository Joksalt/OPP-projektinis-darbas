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
        public PUEffect effect;
        public string image;

        //PUImage image;
        public abstract void MakePowerUp();

        //public void SetName(string NewName)
        //{
        //    this.name = NewName;
        //}
        public virtual PowerUp SetData(Point position, Size size, Color color)
        {
            return null;
        }

        public string toString()
        {
            string infoOfPowerUp = "Power up " + name +" with effect "+ effect.toString()+" with image "+ image;
            return infoOfPowerUp;
        }
    }
}
