using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.State
{
    public class Blue2State : State
    {
        public Blue2State(State state)
        {
            this.mode = state.Mode;
            this.racket = state.Racket;
            this.speed = state.Speed;
            this.softness = state.Softness;
            Initialize();
        }
        private void Initialize()
        {
            softness = 10;
            speed = 10;
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
                case "dev":
                    racket.State = new PurpleState(this);
                    break;
                default:
                    racket.State = new WhiteState(this);
                    break;

            }

        }
    }
}
