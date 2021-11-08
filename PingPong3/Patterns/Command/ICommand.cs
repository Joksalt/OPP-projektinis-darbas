using PingPong3;
using PingPong3.Forms;
using System.Windows.Forms;

namespace PingPong3.Patterns.Command
{
	public abstract class ICommand
	{
		protected PongForm target;

		public abstract void Execute();

		public abstract void Undo();
		
	}
	
}
