using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Mediator
{
    public interface IMediator
    {
        void SetServer(Colleague user);

        void BroadcastMessage(Colleague sender, String msg);
    }
}
