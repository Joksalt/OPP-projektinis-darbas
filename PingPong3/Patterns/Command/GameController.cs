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
			ICommand cmd = commandList.Last();
			commandList.RemoveLast();
            cmd.Undo();
        }
    }
	
}
