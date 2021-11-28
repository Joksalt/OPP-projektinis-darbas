using Xunit;
using Moq;
using PingPong3.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Forms;

namespace PingPong3.Patterns.Decorator.Tests
{
    public class DecoratorTests
    {
        [Fact()]
        public void DefaultRacketMode_ShouldReturnCertainSpeed()
        {
            int s = Form1.defaultRacket.GetSpeed();
            Assert.Equal(30, s);
        }

        [Fact()]
        public void RacketMode1_ShouldReturnCertainSpeed()
        {
            int s = Form1.normalRacket.GetSpeed();
            Assert.Equal(40, s);
        }

        [Fact()]
        public void RacketMode2_ShouldReturnCertainSpeed()
        {
            int s = Form1.devRacket.GetSpeed();
            Assert.Equal(60, s);
        }

        [Fact()]
        public void DefaultRacketMode_ShouldReturnAString()
        {
            string s = Form1.defaultRacket.GetSkin();
            Assert.Equal("Paddle1", s);
        }

        [Fact()]
        public void RacketMode1_ShouldReturnAString()
        {
            string s = Form1.normalRacket.GetSkin();
            Assert.Equal("Paddle1_2", s);
        }

        [Fact()]
        public void RacketMode2_ShouldReturnAString()
        {
            string s = Form1.devRacket.GetSkin();
            Assert.Equal("Paddle1_2_3", s);
        }
        [Fact()]
        public void DefaultRacketMode_ShouldReturnSoftness()
        {
            int s = Form1.defaultRacket.GetSoftness();
            Assert.Equal(0, s);
        }
        [Fact()]
        public void RacketMode1_ShouldReturnSoftness()
        {
            int s = Form1.normalRacket.GetSoftness();
            Assert.Equal(10, s);
        }
        [Fact()]
        public void RacketMode2_ShouldReturnSoftness()
        {
            int s = Form1.devRacket.GetSoftness();
            Assert.Equal(30, s);
        }


    }
}