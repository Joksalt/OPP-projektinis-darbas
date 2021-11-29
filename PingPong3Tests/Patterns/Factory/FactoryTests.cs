using Xunit;
using Moq;
using PingPong3.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Forms;
using System.Windows.Forms;

namespace PingPong3.Patterns.Factory.Tests
{
    public class FactoryTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void WallFactory_ShouldCreateStaticAndMovingWall(int value)
        {
            WallFactory factory = new WallFactory();
           
            Assert.NotNull(factory.MakeWall(value));
        }


        [Fact()]
        public void WallFactory_ShouldntCreateWall()
        {
            WallFactory factory = new WallFactory();

            Assert.Null(factory.MakeWall(3));
        }

        [Fact()]
        public void StaticWall_ShouldReturnSize()
        {
            WallFactory factory = new WallFactory();
            Wall s = factory.MakeWall(0);
            System.Drawing.Size a = new System.Drawing.Size(100, 10);
            Assert.Equal(a, s.Texture.Size);
        }
        [Fact()]
        public void MovingWall_ShouldReturnSize()
        {
            WallFactory factory = new WallFactory();
            Wall s = factory.MakeWall(1);
            System.Drawing.Size a = new System.Drawing.Size(20, 10);
            Assert.Equal(a, s.Texture.Size);
        }

    }
}