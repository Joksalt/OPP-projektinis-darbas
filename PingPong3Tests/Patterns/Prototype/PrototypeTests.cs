using Xunit;
using Moq;
using PingPong3.Patterns.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Forms;

namespace PingPong3.Patterns.Prototype.Tests

{
    public class PrototypeTests
    {
        [Fact()]
        public void Prototype_DeepCopy_NotEqual_ToOriginalCopy()
        {
            Form1 form = new Form1();
            BallItem deepCopy = (BallItem)form._ball.DeepCopy();
            Assert.NotEqual(form._ball.GetHashCode(), deepCopy.GetHashCode());
        }

        [Fact()]
        public void Prototype_ShallowCopy_EqualTo_OriginalCopy()
        {
            Form1 form = new Form1();
            BallItem deepCopy = (BallItem)form._ball.ShallowCopy();
            Assert.Equal(form._ball.GetHashCode(), deepCopy.GetHashCode());
        }
    }
}
