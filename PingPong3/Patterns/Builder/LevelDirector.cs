using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Builder
{
    public class LevelDirector
    {
        public void ConstructWalls(LevelBuilder builder)
        {
            builder.BuildStaticWalls();
            builder.BuildMovingWalls();
        }

    }
}
