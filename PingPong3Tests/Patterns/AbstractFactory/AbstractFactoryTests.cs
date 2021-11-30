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
using System.Drawing;
using PingPong3.Patterns.AbstractFactory;

namespace PingPong3.Patterns.AbstractFactoryTests.Tests
{
    public class AbstractFactoryTests
    {


        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void AbstractFactory_ShouldCreatePositivePowerUp(int value)
        {
            PowerUpFactory factory = new PositivePowerUpFactory();
            factory.OrderPowerUp(value);

        Assert.NotNull(factory);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void AbstractFactory_ShouldCreateNegativePowerUp(int value)
        {
            PowerUpFactory factory = new NegativePowerUpFactory();
            factory.OrderPowerUp(value);

            Assert.NotNull(factory);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void AbstractFactory_PositivePowerUp(int value)
        {
            PowerUpFactory factory = new PositivePowerUpFactory();
            PowerUp a = factory.OrderPowerUp(value);
            a.MakePowerUp();

            Assert.Equal("PowerUp.png", a.image);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void AbstractFactory_NegativePowerUp(int value)
        {
            PowerUpFactory factory = new NegativePowerUpFactory();
            PowerUp a = factory.OrderPowerUp(value);
            a.MakePowerUp();

            Assert.Equal("PowerUp.png", a.image);
        }


    }
}