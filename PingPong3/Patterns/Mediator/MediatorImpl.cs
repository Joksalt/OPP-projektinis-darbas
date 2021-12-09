using PingPong3.Patterns.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Mediator
{
    public class MediatorImpl : IMediator
    {
        LinkedList<Colleague> players = new LinkedList<Colleague>();

        //teacher t? poweup p?
        PowerUp ActivatedPowerUp;

        public void BroadcastMessage(Colleague sender, string msg)
        {
            throw new NotImplementedException();
        }

        public void AddUser(Colleague user)
        {
            if (user.GetColleagueType().Equals(ColleagueType.powerUp))
            {
                ActivatedPowerUp = (PowerUp)user;
            }
            
        }
    }
}
