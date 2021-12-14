using PingPong3.Patterns.Decorator;
using PingPong3.Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Builder
{
    public class ClassicLevelBuilder : LevelBuilder
    {
        private LevelData levelData = new LevelData();
        public override void BuildMovingWalls(IMediator medi, RacketStyle normalRacket, RacketStyle defaultRacket)
        {
            
        }
        public override void BuildStaticWalls(IMediator medi, RacketStyle normalRacket, RacketStyle defaultRacket)
        {
            
        }
        public override LevelData GetResult()
        {
            return levelData;
        }
    }
}
