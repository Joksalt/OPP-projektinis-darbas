using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    public abstract class PowerUp
    {
        private string name;
        public PUEffect effect;

        //PUImage image;

        public abstract void MakePowerUp();

        public string GetName()
        {
            return name;
        }
        public void SetName(string NewName)
        {
            this.name = NewName;
        }
        
        public string toString()
        {
            string infoOfPowerUp = "Power up " + name +" with effect "+effect;
            return infoOfPowerUp;
        }
    }
}
