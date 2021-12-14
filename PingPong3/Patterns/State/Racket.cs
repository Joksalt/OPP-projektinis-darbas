using PingPong3.Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.State
{
    public class Racket : Colleague
    {
        private State state;
        private string owner;

        public Racket(string owner, IMediator mediator) : base(mediator)
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

        public override ColleagueType GetColleagueType()
        {
            return ColleagueType.racket;
        }

        public override void ReceiveMessage(string msg)
        {
            RequestState(msg);
            mediator.BroadcastMessage(this, Mode);
        }

        public void RequestState(string newMode)
        {
            state.PickState(newMode);
            Console.WriteLine(" State  = {0}", this.State.GetType().Name);
        }

        public override void SendMessage(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
