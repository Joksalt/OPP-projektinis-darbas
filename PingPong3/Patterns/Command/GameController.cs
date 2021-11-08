using System.Collections.Generic;
using System.Linq;

namespace PingPong3.Patterns.Command
{
	public class GameController
	{
		private LinkedList<ICommand> commandList = new LinkedList<ICommand>();

		public void Run(ICommand cmd)
		{
			commandList.AddLast(cmd);
			cmd.Execute();
		}
		/// <summary>
		/// Undo is D5 for Form2 and D4 for Form1
		/// </summary>
        public void Undo()
        {
			if (commandList.Count > 0)
			{
				ICommand cmd = commandList.Last();
				commandList.RemoveLast();
				cmd.Undo();
			}
        }
    }
	
}
