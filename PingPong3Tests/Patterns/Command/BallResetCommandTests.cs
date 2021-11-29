using Xunit;
using PingPong3.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Forms;
using System.Drawing;

namespace PingPong3.Patterns.Command.Tests
{
    public class BallResetCommandTests
    {
        [Fact()]
        public void UndoTest()
        {
            PongForm form1 = new Form1();
            form1._ball.Update();
            int firstVelocityX = form1.GenerateBallX();
            int firstVelocityY = form1.GenerateBallY();
            form1._ball.Velocity = new Point(firstVelocityX, firstVelocityY);
            //form1._ball.Velocity = new Point(form1.GenerateBallX(), form1.GenerateBallY());
            form1._commandController.Run(new BallResetCommand(form1));

            form1._commandController.Undo();

            Assert.Equal(firstVelocityX, form1._ball.Velocity.X);
            Assert.Equal(firstVelocityY, form1._ball.Velocity.Y);
        }
    }
}