using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.State
{
    public class BlueState : State
    {
        public BlueState(State state)
        {
            this.mode = state.Mode;
            this.racket = state.Racket;
            this.speed = state.Speed;
            this.softness = state.Softness;
            Initialize();
        }
        public override void PickState(string newMode)
        {
            mode = newMode;
            StateChangeCheck();
        }
        private void Initialize()
        {
            softness = 40;
            speed = 40;
        }


        private void StateChangeCheck()
        {
            switch (mode)
            {
                case "-normal":
                    racket.State = new Blue2State(this);
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
