﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.AbstractFactory
{
    public abstract class PowerUpMaking
    {
        protected abstract PowerUp MakePowerUp(string TypeOfPowerUp);
        public PowerUp OrderPowerUp(string TypeOfPowerUp)
        {
            PowerUp ThePowerUp = MakePowerUp(TypeOfPowerUp);

            ThePowerUp.MakePowerUp();

            return ThePowerUp;
        }
    }
}