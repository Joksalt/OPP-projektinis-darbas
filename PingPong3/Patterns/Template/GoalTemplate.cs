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
            ResetBall();
            if (NeedToRemovePowers())
            {
                //TODO: Continue from here
                _racketMode1 = "default";
                //RacketSkinReseter();
                RacketSkinSender(defaultRacket.GetSkin());
                //PowerUpMaking();
                Console.WriteLine("b" + _PowerUpExists);
                _PowerUpExists = true;
                Console.WriteLine("a" + _PowerUpExists);
            }
        }

        protected void IncreaseScore()
        {
            _commandController.Run(new ScoreIncreaseCommand(this));
        }

        protected void ResetBall()
        {
            _commandController.Run(new BallResetCommand(this));
        }

        public abstract bool NeedToRemovePowers();
    }
}
