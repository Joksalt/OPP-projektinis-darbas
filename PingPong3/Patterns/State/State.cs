using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.State
{
    public abstract class State
    {
        protected Racket racket;
        protected string mode;
        protected int speed;
        protected int softness;
        public Racket Racket
        {
            get { return racket; }
            set { racket = value; }
        }
        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int Softness
        {
            get { return softness; }
            set { softness = value; }
        }
        public abstract void PickState(string newMode);
    }
}
