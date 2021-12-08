using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Mediator
{
    //public abstract class Colleague
    public abstract class Colleague : GameItem
    {
        public IMediator mediator;

        public Colleague(IMediator medi)
        {
            mediator = medi;
        }

        public abstract void SendMessage(String msg);

        public abstract void ReceiveMessage(String msg);
    }
}
