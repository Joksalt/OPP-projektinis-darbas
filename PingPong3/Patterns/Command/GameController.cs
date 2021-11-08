using System.Collections.Generic;

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

		//public void undo()
		//{ //removeCommand
		//	int index = list.size();
		//	ICommand cmd = list.get(index - 1);
		//	list.remove(index - 1);
		//	cmd.undo();
		//}
	}
	
}
