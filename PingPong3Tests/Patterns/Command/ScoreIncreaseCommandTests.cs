using Xunit;
using Moq;
using PingPong3.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Forms;

namespace PingPong3.Patterns.Command.Tests
{
    public class ScoreIncreaseCommandTests
    {
        [Fact()]
        public void Undo_CommandListNotEmpty_ShouldLowerScore()
        {
            //Arrange
            PongForm form1 = new Form1();
            form1._commandController.Run(new ScoreIncreaseCommand(form1));
            form1._commandController.Run(new ScoreIncreaseCommand(form1));
            //Act
            form1._commandController.Undo();
            //Assert
            Assert.Equal(1, form1.playerSelfScore);
        }

        [Fact()]
        public void Undo_ScoreLowerThanZero_ShouldDoNothing()
        {
            PongForm form1 = new Form1();
            form1._commandController.Run(new ScoreIncreaseCommand(form1));
            form1.playerSelfScore = 0;
            form1._commandController.Undo();
            Assert.Equal(0, form1.playerSelfScore);
        }

        [Fact()]
        public void Execute_IncreaseOnce_ScoreShouldIncrease()
        {
            PongForm form1 = new Form1();

            form1.playerSelfScore = 1;
            form1._commandController.Run(new ScoreIncreaseCommand(form1));
            Assert.Equal(2, form1.playerSelfScore);
        }
    }
}