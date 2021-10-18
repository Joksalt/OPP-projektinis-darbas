using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Strategy;
using System.Drawing;
using System.Windows.Forms;

namespace PingPong3.Patterns.Factory
{
    public class WallFactory
    {
        //1024, 768
        private int WallCount = 0;

        public Wall MakeWall(int Number)
        {
            if (Number == 0)
                return new StaticWall(WallCount++);
            else if (Number == 1)
                return new MovingWall(WallCount++);
            else return null;
        }

        public List<Wall> Production1()
        {
            List<Wall> walls = new List<Wall>();

            //walls.Add(MakeWall(0).SetData(new Point(412, 40), new Size(30, 80), Color.White));
            walls.Add(MakeWall(0).SetData(new Point(612, 90), new Size(30, 180), Color.White));
            walls.Add(MakeWall(0).SetData(new Point(412, 658), new Size(30, 180), Color.White));
            //walls.Add(MakeWall(0).SetData(new Point(612, 728), new Size(30, 80), Color.White));

            return walls;
        }

        public List<Wall> Production2()
        {
            List<Wall> walls = new List<Wall>();
            //Aint working
            Wall wall;
            for(int i = 0; i < 7; i++)
            {
                wall = MakeWall(1).SetData(new Point(792 - (30 * i), -90 + (30 * i)), new Size(30, 180), Color.White, -90, 90, new Point(0, 2));
                walls.Add(wall.SetMove(new MoveVertically(wall)));
                wall = MakeWall(1).SetData(new Point(232 + (30 * i), -90 + (30 * i)), new Size(30, 180), Color.White, -90, 90, new Point(0, 2));
                walls.Add(wall.SetMove(new MoveVertically(wall)));

                wall = MakeWall(1).SetData(new Point(612 + (30 * i), 678 + (30 * i)), new Size(30, 180), Color.White, 678, 858, new Point(0, 2));
                walls.Add(wall.SetMove(new MoveVertically(wall)));
                wall = MakeWall(1).SetData(new Point(412 - (30 * i), 678 + (30 * i)), new Size(30, 180), Color.White, 678, 858, new Point(0, 2));
                walls.Add(wall.SetMove(new MoveVertically(wall)));
            }
            return walls;
        }

        public List<Wall> Production3()
        {
            List<Wall> walls = new List<Wall>();
            Wall wall;
            wall = MakeWall(1).SetData(new Point(100, 384), new Size(50, 50), Color.White, 10, 180, new Point(0, 2));
            walls.Add(wall.SetMove(new ChangeSize(wall)));
            wall = MakeWall(1).SetData(new Point(924, 384), new Size(50, 50), Color.White, 10, 180, new Point(0, 2));
            walls.Add(wall.SetMove(new ChangeSize(wall)));
            return walls;
        }
    }
}
