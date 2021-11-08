namespace PingPong3.Patterns.Command
{
	public class BallResetCommand : ICommand
	{
		public BallResetCommand(Form1 formItem)
        {
			target = formItem;
        }

		public override void Execute()
        {
            target._level = 7;

            int velocityY = target.GenerateBallY();
            int velocityX = target.GenerateBallX();

            //target.gameLogger.Write(LOG_SENDER, "reset ball");
            target.notifyResetBallSignal(velocityX, velocityY);
        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
	
}
