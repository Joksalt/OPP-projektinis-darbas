using System.Collections.Generic;
using System.Linq;

namespace PingPong3.Patterns.Command
{
	public class GameController
	{
		private LinkedList<ICommand> commandList = new LinkedList<ICommand>();

		//public ArrayList<ICommand> getList()
		//{
		//	return list;
		//}

		public void Run(ICommand cmd)
		{
			commandList.AddLast(cmd);
			cmd.Execute();
		}

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
