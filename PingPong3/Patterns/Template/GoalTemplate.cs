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
                //TODO: Continue from here. Make power up reset method here.
                RacketPowerUpReseter();

                //_racketMode1 = "default";
                ////////////RacketSkinReseter();
                //RacketSkinSender(defaultRacket.GetSkin());
                /////////////PowerUpMaking();
                //_PowerUpExists = true;
            }
            if (NeedToLimitPoints())
            {
                //Hook method for classic game mode
                if (playerSelfScore >= 3)
                {
                    SendScoreSignal(0, 0);
                    SendScoreSignal(0, 1);
                }
            }
        }

        protected void IncreaseScore()
        {
            _commandController.Run(new ScoreIncreaseCommand(this));
        }

        public void SendScoreSignal()
        {
            throw new NotImplementedException();
        }

        protected void ResetBall()
        {
            _commandController.Run(new BallResetCommand(this));
        }

        public abstract bool NeedToRemovePowers();
        public abstract bool NeedToLimitPoints();
    }
}
