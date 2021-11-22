using PingPong3.Forms;
using PingPong3.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Template
{
    public abstract class GoalTemplate : PongForm
    {
        
        public void GoalProcess()
        {
            IncreaseScore();
        }

        protected void IncreaseScore()
        {
            _commandController.Run(new ScoreIncreaseCommand(this));
            _commandController.Run(new BallResetCommand(this));
        }
    }
}
