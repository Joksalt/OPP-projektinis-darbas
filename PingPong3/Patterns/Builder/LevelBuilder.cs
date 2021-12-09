using PingPong3.Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Builder
{
    public abstract class LevelBuilder
    {
        public abstract void BuildStaticWalls(IMediator medi);
        public abstract void BuildMovingWalls(IMediator medi);
        public abstract LevelData GetResult();
    }
}
