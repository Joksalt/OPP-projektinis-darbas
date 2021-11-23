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
    public abstract class SoftnessPowerUp : PowerUp
    {
        public MovingWall target;
        public SoftnessPowerUp()
        {

        }


        public abstract void setTarget(MovingWall target);
    }
}


