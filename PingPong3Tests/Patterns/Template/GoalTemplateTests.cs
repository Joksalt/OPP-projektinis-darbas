using Xunit;
using PingPong3.Patterns.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Forms;
using Moq;
using PingPong3.Patterns.Command;
using System.Drawing;

namespace PingPong3.Patterns.Template.Tests
{
    public class GoalTemplateTests
    {
        [Fact()]
        public void GoalProcess_NoHooks_ShouldIncreaseScore()
        {
            var form1 = new Mock<GoalTemplate>();
            form1.SetupAllProperties();
            form1.Object.playerSelfScore = 1;
            form1.Object._commandController = new GameController();
            form1.Object._ball = new BallItem
            {
                Velocity = new Point(2, 5)
            };
            form1.Object.GoalProcess();
            Assert.Equal(2, form1.Object.playerSelfScore);
        }

        [Fact()]
        public void GoalProcess_NeedToLimitPoints_ShouldZero()
        {
            var form1 = new Mock<GoalTemplate>();
            form1.SetupAllProperties();
            form1.Object.playerSelfScore = 2;
            //stub
            form1.Setup(x => x.NeedToLimitPoints()).Returns(true);
            form1.Setup(f => f.SendScoreSignal(It.IsAny<int>(), It.IsAny<int>()))
                .Callback((int score, int id) => {
                    form1.Object.playerSelfScore = score;
                }).Verifiable();
            form1.Object._commandController = new GameController();
            form1.Object._ball = new BallItem
            {
                Velocity = new Point(2, 5)
            };

            form1.Object.GoalProcess();

            Assert.Equal(0, form1.Object.playerSelfScore);
        }
    }
}