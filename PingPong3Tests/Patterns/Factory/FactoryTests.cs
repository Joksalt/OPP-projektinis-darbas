//using Xunit;
//using Moq;
//using PingPong3.Patterns.Command;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using PingPong3.Forms;
//using System.Windows.Forms;
//using System.Drawing;
//using PingPong3.Patterns.Strategy;

//namespace PingPong3.Patterns.Factory.Tests
//{
//    public class FactoryTests
//    {
//        [Theory]
//        [InlineData(0)]
//        [InlineData(1)]
//        public void WallFactory_ShouldCreateStaticAndMovingWall(int value)
//        {
//            WallFactory factory = new WallFactory();
           
//            Assert.NotNull(factory.MakeWall(value));
//        }


//        [Fact()]
//        public void WallFactory_ShouldntCreateWall()
//        {
//            WallFactory factory = new WallFactory();

//            Assert.Null(factory.MakeWall(3));
//        }

//        [Fact()]
//        public void StaticWall_ShouldReturnSize()
//        {
//            WallFactory factory = new WallFactory();
//            Wall s = factory.MakeWall(0);
//            Size a = new Size(100, 10);
//            Assert.Equal(a, s.Texture.Size);
//        }
//        [Fact()]
//        public void MovingWall_ShouldReturnSize()
//        {
//            WallFactory factory = new WallFactory();
//            Wall s = factory.MakeWall(1);
//            Size a = new Size(20, 10);
//            Assert.Equal(a, s.Texture.Size);
//        }
//        [Fact()]
//        public void MovingWall_SetData()
//        {
//            WallFactory factory = new WallFactory();
//            Point position = new Point(500, 500);
//            Size size = new Size(69, 420);
//            Color color = Color.Red;
//            MovingWall s = factory.MakeWall(1).SetData(position, size, color, 0, 0, new Point(0, 0)) as MovingWall;
//            Assert.Equal(color, s.Texture.BackColor);
//            Assert.Equal(position, s.Position);
//            Assert.Equal(size, s.Texture.Size);
//            Assert.Equal(0, s.End);
//            Assert.Equal(0, s.Start);
//        }
//        [Fact()]
//        public void StaticWall_SetData()
//        {
//            WallFactory factory = new WallFactory();
//            Point position = new Point(500, 500);
//            Size size = new Size(69, 420);
//            Color color = Color.Red;
//            StaticWall s = factory.MakeWall(0).SetData(position,size,color) as StaticWall;
//            Assert.Equal(color, s.Texture.BackColor);
//            Assert.Equal(position, s.Position);
//            Assert.Equal(size, s.Texture.Size);
//        }
//        [Fact()]
//        public void Wall_2MoreSetData()
//        {
//            WallFactory factory = new WallFactory();
//            MovingWall s = factory.MakeWall(1).SetData() as MovingWall;
//            Assert.Null(s);
//        }
//        [Fact()]
//        public void Wall_1MoreSetData()
//        {
//            WallFactory factory = new WallFactory();
//            MovingWall s = factory.MakeWall(1).SetData(new Point(500, 500), new Size(6, 420), Color.Red, 0, 0, new Point(0, 0)) as MovingWall;
//            s.SetMove(new PlayerMove(s));

//            WallFactory factory2 = new WallFactory();
//            MovingWall s2 = factory2.MakeWall(1).SetData(new Point(500, 500), new Size(6, 420), Color.Red, 0, 0, new Point(0, 0)) as MovingWall;
//            Assert.NotEqual(s, s2);
//        }

//    }
//}