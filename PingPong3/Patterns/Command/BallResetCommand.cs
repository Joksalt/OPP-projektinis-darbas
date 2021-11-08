using PingPong3.Forms;
using System.Windows.Forms;

namespace PingPong3.Patterns.Command
{
	public class BallResetCommand : ICommand
	{
        private BallItem BallCopy;
		public BallResetCommand(PongForm formItem)
        {
			target = formItem;
        }

		public override void Execute()
        {
            BallCopy = (BallItem)target._ball.DeepCopy();

            target._level = 7;

            int velocityY = target.GenerateBallY();
            int velocityX = target.GenerateBallX();

            //target.gameLogger.Write(LOG_SENDER, "reset ball");
            target.notifyResetBallSignal(velocityX, velocityY);
        }

        public override void Undo()
        {
            target._ball = BallCopy;

            target.notifyResetBallSignal(BallCopy.Velocity.X, BallCopy.Velocity.Y);
        }
    }
	
}
