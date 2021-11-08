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
            target.playerSelfScore += 1;
            target.SendScoreSignal(target.playerSelfScore, target._playerSelfIndex);

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
