﻿using PingPong3.Patterns.AbstractFactory;
using PingPong3.Patterns.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Mediator
{
    public class MediatorImpl : IMediator
    {
        LinkedList<Colleague> Players = new LinkedList<Colleague>();

        //teacher t? poweup p?
        PowerUp ActivatedPowerUp;
        Racket PlayerRacket;

        public void BroadcastMessage(Colleague sender, string msg)
        {
            if (sender.GetColleagueType().Equals(ColleagueType.powerUp))
            {
                PlayerRacket.ReceiveMessage(msg);
            }
        }

        public void AddUser(Colleague user)
        {
            if (user.GetColleagueType().Equals(ColleagueType.powerUp))
            {
                ActivatedPowerUp = (PowerUp)user;
            }
            else if (user.GetColleagueType().Equals(ColleagueType.racket))
            {
                PlayerRacket = (Racket)user;
            }
            
        }
    }
}
