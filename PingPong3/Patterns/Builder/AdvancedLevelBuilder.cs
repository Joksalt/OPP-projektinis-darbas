using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Decorator;
using PingPong3.Patterns.Factory;
using PingPong3.Patterns.Mediator;

namespace PingPong3.Patterns.Builder
{
    public class AdvancedLevelBuilder : LevelBuilder
    {
        private LevelData levelData = new LevelData();
        public override void BuildMovingWalls(IMediator medi, RacketStyle normalRacket, RacketStyle defaultRacket)
        {
            
        }
        public override void BuildStaticWalls(IMediator medi, RacketStyle normalRacket, RacketStyle defaultRacket)
        {
            WallFactory wallFactory = new WallFactory();
            levelData.walls.Add(wallFactory.MakeWall(0, medi, normalRacket, defaultRacket).SetData(new Point(412, 40), new Size(30, 80), Color.White));
            levelData.walls.Add(wallFactory.MakeWall(0, medi, normalRacket, defaultRacket).SetData(new Point(612, 90), new Size(30, 180), Color.White));
            levelData.walls.Add(wallFactory.MakeWall(0, medi, normalRacket, defaultRacket).SetData(new Point(412, 658), new Size(30, 180), Color.White));
            levelData.walls.Add(wallFactory.MakeWall(0, medi, normalRacket, defaultRacket).SetData(new Point(612, 728), new Size(30, 80), Color.White));
        }
        public override LevelData GetResult()
        {
            return levelData;
        }
    }
}
