using PingPong3;

namespace PingPong3.Patterns.Command
{
	public abstract class ICommand
	{
		protected BallItem target;
		protected BallItem targetCopy;

		public abstract void Execute();

		public abstract void Undo();
		
	}
	
}
