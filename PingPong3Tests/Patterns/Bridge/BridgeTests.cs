using Xunit;
using Moq;
using PingPong3.Patterns.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Forms;

namespace PingPong3.Patterns.Bridge.Tests
{
    public class BridgeTests
    {
        [Fact()]
        public void ClassicBackground_stringPath_NotNull()
        {
            ClassicBackground background = new ClassicBackground();
            Assert.NotNull(background.setBackgroundTheme());
        }

        [Fact()]
        public void ClassicBackground_correctBackgroundPictureFile()
        {
            ClassicBackground background = new ClassicBackground();
            Assert.EndsWith("black.png", background.setBackgroundTheme());
        }

        [Fact()]
        public void DynamicBackground_stringPath_NotNull()
        {
            DynamicBackground background = new DynamicBackground();
            Assert.NotNull(background.setBackgroundTheme());
        }

        [Fact()]
        public void DynamicBackground_correctBackgroundPictureFile()
        {
            DynamicBackground background = new DynamicBackground();
            Assert.EndsWith("matrix.gif", background.setBackgroundTheme());
        }

        [Fact()]
        public void StaticBackground_stringPath_NotNull()
        {
            StaticBackground background = new StaticBackground();
            Assert.NotNull(background.setBackgroundTheme());
        }

        [Fact()]
        public void StaticBackground_correctBackgroundPictureFile()
        {
            StaticBackground background = new StaticBackground();
            Assert.EndsWith("Fondo.png", background.setBackgroundTheme());
        }
    }
}
