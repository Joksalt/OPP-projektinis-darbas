using PingPong3.Patterns.Decorator;
using PingPong3.Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Builder
{
    public class LevelDirector
    {
        public void ConstructWalls(LevelBuilder builder, IMediator medi, RacketStyle normalRacket, RacketStyle defaultRacket)
        {
            builder.BuildStaticWalls(medi, normalRacket, defaultRacket);
            builder.BuildMovingWalls(medi, normalRacket, defaultRacket);
        }

    }
}
