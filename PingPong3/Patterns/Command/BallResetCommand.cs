namespace PingPong3.Patterns.Command
{
	public class BallResetCommand : ICommand
	{
		public BallResetCommand(BallItem ballItem)
        {
			target = ballItem;
        }

		public override void Execute()
        {

        }

        public override void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
	
}
