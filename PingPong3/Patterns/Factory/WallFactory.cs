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

        //Random???

        public Wall MakeWall(int Number)
        {
            if (Number == 0)
                return new StaticWall(WallCount++);
            else if (Number == 1)
                return new VerticallyMovingWall(WallCount++);
            else if (Number == 2)
                return new HorizontallyMovingWall(WallCount++);
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

            walls.Add(MakeWall(1).SetData(new Point(792, -90), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(232, -90), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(762, -60), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(262, -60), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(732, -30), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(292, -30), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(702, 0), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(322, 0), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(672, 30), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(352, 30), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(642, 60), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(382, 60), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(612, 90), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(412, 90), new Size(30, 180), Color.White, -90, 90, 2));

            walls.Add(MakeWall(1).SetData(new Point(612, 678), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(412, 678), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(642, 708), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(382, 708), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(672, 738), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(352, 738), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(702, 768), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(322, 768), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(732, 798), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(292, 798), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(762, 828), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(262, 828), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(792, 858), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(232, 858), new Size(30, 180), Color.White, 678, 858, -2));

            return walls;
        }

        public List<Wall> Production3()
        {
            List<Wall> walls = new List<Wall>();

            walls.Add(MakeWall(2).SetData(new Point(642, 180), new Size(180, 20), Color.White, 612, 672, 3));
            walls.Add(MakeWall(2).SetData(new Point(382, 180), new Size(180, 20), Color.White, 352, 412, 3));

            walls.Add(MakeWall(1).SetData(new Point(612, 90), new Size(30, 180), Color.White, -90, 90, 2));
            walls.Add(MakeWall(1).SetData(new Point(412, 90), new Size(30, 180), Color.White, -90, 90, 2));

            walls.Add(MakeWall(1).SetData(new Point(612, 678), new Size(30, 180), Color.White, 678, 858, -2));
            walls.Add(MakeWall(1).SetData(new Point(412, 678), new Size(30, 180), Color.White, 678, 858, -2));

            walls.Add(MakeWall(2).SetData(new Point(642, 588), new Size(180, 20), Color.White, 612, 672, -3));
            walls.Add(MakeWall(2).SetData(new Point(382, 588), new Size(180, 20), Color.White, 352, 412, -3));

            return walls;
        }
    }
}
