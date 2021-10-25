using System;
using System.Collections.Generic;

namespace PingPong3.Patterns.Observer
{
	public abstract class Subject
	{

		private LinkedList<IObserver> unitList = new LinkedList<IObserver>();

		public void attach( IObserver unit )
		{
			unitList.AddLast(unit);
			unit.setServer(this);
		}
		
		public void deattach( IObserver unit )
		{
			//TODO: cover deaatach method
		}
		
		public void notifyAll(string message)
		{
            foreach (var unit in unitList)
            {
				unit.update(message);
			}
		}
		
		public void receiveFromClient(string message)
		{
			notifyAll(message);
		}
		
	}
	
}
