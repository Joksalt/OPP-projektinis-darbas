using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.State
{
    public class WhiteState : State
    {
        // Overloaded constructors
        public WhiteState(State state) :
            this(state.Mode, state.Racket, state.Speed, state.Softness)
        {
        }
        public WhiteState(string mode, Racket racket, int speed, int softness)
        {
            this.mode = mode;
            this.racket = racket;
            this.speed = speed;
            this.softness = softness;
            Initialize();
        }
        private void Initialize()
        {
            speed = 30;
            softness = 0;
        }
        public override void PickState(string newMode)
        {
            mode = newMode;
            StateChangeCheck();
        }
        private void StateChangeCheck()
        {
            switch (mode)
            {
                case "+normal":
                    racket.State = new BlueState(this);
                    break;
                case "-normal":
                    racket.State = new Blue2State(this);
                    break;
                case "dev":
                    racket.State = new PurpleState(this);
                    break;

            }
        }
    }
}
