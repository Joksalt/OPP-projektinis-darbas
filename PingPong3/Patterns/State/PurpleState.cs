using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.State
{
    public class PurpleState : State
    {
        public PurpleState(State state)
            : this(state.Mode, state.Racket, state.Speed, state.Softness)
        {
        }
        public PurpleState(string mode, Racket racket, int speed, int softness)
        {
            this.mode = mode;
            this.racket = racket;
            this.speed = speed;
            this.softness = softness;
            Initialize();

        }
        private void Initialize()
        {
            softness = 60;
            speed = 60;
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
                default:
                    racket.State = new WhiteState(this);
                    break;

            }
        }
    }
}
