using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    public abstract class PowerUp
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
        
        public string toString()
        {
            string infoOfPowerUp = "Power up " + name +" with effect "+ effect.toString()+" with image "+image;
            return infoOfPowerUp;
        }
    }
}
