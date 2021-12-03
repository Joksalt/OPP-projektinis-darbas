using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.State
{
    public class Racket
    {
        private State state;
        private string owner;

        public Racket(string owner)
        {
            this.owner = owner;
            this.state = new WhiteState("default", this, 30, 0);
        }
        public string Mode
        {
            get { return state.Mode; }
        }
        public int Speed
        {
            get { return state.Speed; }
        }
        public int Softness
        {
            get { return state.Softness; }
        }
        public State State
        {
            get { return state; }
            set { state = value; }
        }
        public void PickState(string newMode)
        {
            state.PickState(newMode);
            Console.WriteLine(" State  = {0}", this.State.GetType().Name);
        }
    }
}
