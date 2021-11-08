using PingPong3;

namespace PingPong3.Patterns.Command
{
	public abstract class ICommand
	{
		//BUGBUG: make abstract form class that could be used here
		protected Form1 target;
		protected Form1 targetCopy;

		public abstract void Execute();

		public abstract void Undo();
		
	}
	
}
