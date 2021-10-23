using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Builder
{
    class ClassicLevelBuilder : LevelBuilder
    {
        private LevelData levelData = new LevelData();
        public override void BuildMovingWalls()
        {
            
        }
        public override void BuildStaticWalls()
        {
            
        }
        public override LevelData GetResult()
        {
            return levelData;
        }
    }
}
