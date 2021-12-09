using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Decorator;
using PingPong3.Patterns.Factory;
using PingPong3.Patterns.Mediator;
using PingPong3.Patterns.Strategy;

namespace PingPong3.Patterns.Builder
{
    public class FrenzyLevelBuilder : LevelBuilder
    {
        private LevelData levelData = new LevelData();
        public override void BuildMovingWalls(IMediator medi, RacketStyle normalRacket, RacketStyle defaultRacket)
        {
            WallFactory wallFactory = new WallFactory();
            Wall wall;
            for (int i = 0; i < 7; i++)
            {
                wall = wallFactory.MakeWall(1, medi, normalRacket, defaultRacket).SetData(new Point(792 - (30 * i), -90 + (30 * i)), new Size(30, 180), Color.White, -90, 90, new Point(0, 2));
                levelData.walls.Add(wall.SetMove(new MoveVertically(wall)));
                wall = wallFactory.MakeWall(1, medi, normalRacket, defaultRacket).SetData(new Point(232 + (30 * i), -90 + (30 * i)), new Size(30, 180), Color.White, -90, 90, new Point(0, 2));
                levelData.walls.Add(wall.SetMove(new MoveVertically(wall)));

                wall = wallFactory.MakeWall(1, medi, normalRacket, defaultRacket).SetData(new Point(612 + (30 * i), 678 + (30 * i)), new Size(30, 180), Color.White, 678, 858, new Point(0, 2));
                levelData.walls.Add(wall.SetMove(new MoveVertically(wall)));
                wall = wallFactory.MakeWall(1, medi, normalRacket, defaultRacket).SetData(new Point(412 - (30 * i), 678 + (30 * i)), new Size(30, 180), Color.White, 678, 858, new Point(0, 2));
                levelData.walls.Add(wall.SetMove(new MoveVertically(wall)));
            }
        }
        public override void BuildStaticWalls(IMediator medi, RacketStyle normalRacket, RacketStyle defaultRacket)
        {
            /*Wall wall;
            wall = MakeWall(1).SetData(new Point(100, 384), new Size(50, 50), Color.White, 10, 180, new Point(0, 2));
            walls.Add(wall.SetMove(new ChangeSize(wall)));
            wall = MakeWall(1).SetData(new Point(924, 384), new Size(50, 50), Color.White, 10, 180, new Point(0, 2));
            walls.Add(wall.SetMove(new ChangeSize(wall)));*/
        }
        public override LevelData GetResult()
        {
            return levelData;   
        }
    }
}
