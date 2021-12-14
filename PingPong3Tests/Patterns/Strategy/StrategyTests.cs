//using Xunit;
//using Moq;
//using PingPong3.Patterns.Strategy;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using PingPong3.Forms;

//namespace PingPong3.Patterns.Strategy.Tests
//{
//    public class StrategyTests
//    {
//        [Fact()]
//        public void ChangeSizeSingleMoveWidthTest()
//        {
//            Move move = new ChangeSize(0);
//            move.MoveAction();
//            Assert.Equal(21, move.movingWall.Texture.Size.Width);
//        }
//        [Fact()]
//        public void ChangeSizeSingleMoveHeightTest()
//        {
//            Move move = new ChangeSize(0);
//            move.MoveAction();
//            Assert.Equal(11, move.movingWall.Texture.Size.Height);
//        }
//        [Fact()]
//        public void ChangeSizeLimitMoveWidthTest()
//        {
//            Move move = new ChangeSize(0);
//            for(int i = 0; i < 81; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(100, move.movingWall.Texture.Size.Width);
//        }
//        [Fact()]
//        public void ChangeSizeLimitMoveHeightTest()
//        {
//            Move move = new ChangeSize(0);
//            for (int i = 0; i < 81; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(90, move.movingWall.Texture.Size.Height);
//        }
//        [Fact()]
//        public void ChangeSizeLimitVelocityXTest()
//        {
//            Move move = new ChangeSize(0);
//            for (int i = 0; i < 81; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(-1, move.movingWall.Velocity.X);
//        }
//        [Fact()]
//        public void ChangeSizeLimitVelocityYTest()
//        {
//            Move move = new ChangeSize(0);
//            for (int i = 0; i < 81; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(-1, move.movingWall.Velocity.Y);
//        }
//        [Fact()]
//        public void MoveHorizontallySingleMovePositionXTest()
//        {
//            Move move = new MoveHorizontally(0);
//            move.MoveAction();
//            Assert.Equal(51, move.movingWall.Position.X);
//        }
//        [Fact()]
//        public void MoveHorizontallySingleMovePositionYTest()
//        {
//            Move move = new MoveHorizontally(0);
//            move.MoveAction();
//            Assert.Equal(50, move.movingWall.Position.Y);
//        }
//        [Fact()]
//        public void MoveHorizontallyLimitMovePositionXTest()
//        {
//            Move move = new MoveHorizontally(0);
//            for (int i = 0; i < 51; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(100, move.movingWall.Position.X);
//        }
//        [Fact()]
//        public void MoveHorizontallyLimitMovePositionYTest()
//        {
//            Move move = new MoveHorizontally(0);
//            for (int i = 0; i < 51; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(50, move.movingWall.Position.Y);
//        }
//        [Fact()]
//        public void MoveHorizontallyLimitVelocityXTest()
//        {
//            Move move = new MoveHorizontally(0);
//            for (int i = 0; i < 51; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(-1, move.movingWall.Velocity.X);
//        }
//        [Fact()]
//        public void MoveHorizontallyLimitVelocityYTest()
//        {
//            Move move = new MoveHorizontally(0);
//            for (int i = 0; i < 51; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(0, move.movingWall.Velocity.Y);
//        }
//        [Fact()]
//        public void MoveVerticallySingleMovePositionXTest()
//        {
//            Move move = new MoveVertically(0);
//            move.MoveAction();
//            Assert.Equal(50, move.movingWall.Position.X);
//        }
//        [Fact()]
//        public void MoveVerticallySingleMovePositionYTest()
//        {
//            Move move = new MoveVertically(0);
//            move.MoveAction();
//            Assert.Equal(51, move.movingWall.Position.Y);
//        }
//        [Fact()]
//        public void MoveVerticallyLimitMovePositionXTest()
//        {
//            Move move = new MoveVertically(0);
//            for (int i = 0; i < 51; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(50, move.movingWall.Position.X);
//        }
//        [Fact()]
//        public void MoveVerticallyLimitMovePositionYTest()
//        {
//            Move move = new MoveVertically(0);
//            for (int i = 0; i < 51; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(100, move.movingWall.Position.Y);
//        }
//        [Fact()]
//        public void MoveVerticallyLimitVelocityXTest()
//        {
//            Move move = new MoveVertically(0);
//            for (int i = 0; i < 51; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(0, move.movingWall.Velocity.X);
//        }
//        [Fact()]
//        public void MoveVerticallyLimitVelocityYTest()
//        {
//            Move move = new MoveVertically(0);
//            for (int i = 0; i < 51; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(-1, move.movingWall.Velocity.Y);
//        }
//        [Fact()]
//        public void PlayerMoveSingleMovePositionXTest()
//        {
//            Move move = new PlayerMove(0);
//            move.MoveAction();
//            Assert.Equal(50, move.movingWall.Position.X);
//        }
//        [Fact()]
//        public void PlayerMoveSingleMovePositionYTest()
//        {
//            Move move = new PlayerMove(0);
//            move.MoveAction();
//            Assert.Equal(51, move.movingWall.Position.Y);
//        }
//        [Fact()]
//        public void PlayerMoveLimitMovePositionXTest()
//        {
//            Move move = new PlayerMove(0);
//            for (int i = 0; i < 1000; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(50, move.movingWall.Position.X);
//        }
//        [Fact()]
//        public void PlayerMoveLimitMovePositionYTest()
//        {
//            Move move = new PlayerMove(0);
//            for (int i = 0; i < 1000; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(1050, move.movingWall.Position.Y);
//        }
//        [Fact()]
//        public void PlayerMoveLimitVelocityXTest()
//        {
//            Move move = new PlayerMove(0);
//            for (int i = 0; i < 1000; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(1, move.movingWall.Velocity.X);
//        }
//        [Fact()]
//        public void PlayerMoveLimitVelocityYTest()
//        {
//            Move move = new PlayerMove(0);
//            for (int i = 0; i < 1000; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(1, move.movingWall.Velocity.Y);
//        }
//        [Fact()]
//        public void PlayerMoveVelocityChangeSingleMovePositionXTest()
//        {
//            Move move = new PlayerMove(0);
//            move.movingWall.Velocity = new System.Drawing.Point(0, -1);
//            move.MoveAction();
//            Assert.Equal(50, move.movingWall.Position.X);
//        }
//        [Fact()]
//        public void PlayerMoveVelocityChangeSingleMovePositionYTest()
//        {
//            Move move = new PlayerMove(0);
//            move.movingWall.Velocity = new System.Drawing.Point(0, -1);
//            move.MoveAction();
//            Assert.Equal(49, move.movingWall.Position.Y);
//        }
//        [Fact()]
//        public void PlayerMoveVelocityChangeLimitMovePositionXTest()
//        {
//            Move move = new PlayerMove(0);
//            move.movingWall.Velocity = new System.Drawing.Point(0, -1);
//            for (int i = 0; i < 1000; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(50, move.movingWall.Position.X);
//        }
//        [Fact()]
//        public void PlayerMoveVelocityChangeLimitMovePositionYTest()
//        {
//            Move move = new PlayerMove(0);
//            move.movingWall.Velocity = new System.Drawing.Point(0, -1);
//            for (int i = 0; i < 1000; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(-950, move.movingWall.Position.Y);
//        }
//        [Fact()]
//        public void PlayerMoveVelocityChangeLimitVelocityXTest()
//        {
//            Move move = new PlayerMove(0);
//            move.movingWall.Velocity = new System.Drawing.Point(0, -1);
//            for (int i = 0; i < 1000; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(0, move.movingWall.Velocity.X);
//        }
//        [Fact()]
//        public void PlayerMoveVelocityChangeLimitVelocityYTest()
//        {
//            Move move = new PlayerMove(0);
//            move.movingWall.Velocity = new System.Drawing.Point(0, -1);
//            for (int i = 0; i < 1000; i++)
//            {
//                move.MoveAction();
//            }
//            Assert.Equal(-1, move.movingWall.Velocity.Y);
//        }
//    }
//}
