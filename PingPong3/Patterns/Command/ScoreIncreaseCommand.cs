using PingPong3.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Command
{
    public class ScoreIncreaseCommand : ICommand
    {
        public ScoreIncreaseCommand(PongForm formItem)
        {
            target = formItem;
        }
        public override void Execute()
        {
            var newScore = target.playerOtherScore + 1;
            target.playerOtherScore = newScore;            
            target.selfScoreLabel.Text = newScore.ToString();
            
            //var newScore = target.selfScoreLabel + 1;
            //target._scorePlayer1 = newScore;            
            //target._lblScore1.Text = newScore.ToString();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
