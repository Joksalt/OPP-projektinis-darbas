//using Xunit;
//using PingPong3.Patterns.Command;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using PingPong3.Forms;
//using System.Drawing;
//using Moq;

//namespace PingPong3.Patterns.Command.Tests
//{
//    public class BallResetCommandTests
//    {
//        [Fact()]
//        public void UndoTest()
//        {
//            PongForm form1 = new Form1();
//            form1._ball = new BallItem
//            {
//                Velocity = new Point(2, 5)
//            };
//            form1._ball.Update();
//            int firstVelocityX = form1.GenerateBallX();
//            int firstVelocityY = form1.GenerateBallY();
//            form1._ball.Velocity = new Point(firstVelocityX, firstVelocityY);
//            var realReset = new BallResetCommand(form1);
            

//            //var resetCommand = new Mock<BallResetCommand>();
//            //resetCommand.SetupAllProperties();
//            //resetCommand.Object = realReset;
//            //resetCommand.Setup(x => x.Execute(2, 2)).Returns(4);

//            form1._commandController.Run(realReset);
//            //form1._commandController.Run(resetCommand.Object);

//            form1._commandController.Undo();

//            Assert.Equal(firstVelocityX, form1._ball.Velocity.X);
//            Assert.Equal(firstVelocityY, form1._ball.Velocity.Y);
//        }
//    }
//}