using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Builder
{
    public abstract class LevelBuilder
    {
        public abstract void BuildStaticWalls();
        public abstract void BuildMovingWalls();
        public abstract LevelData GetResult();
    }
}
