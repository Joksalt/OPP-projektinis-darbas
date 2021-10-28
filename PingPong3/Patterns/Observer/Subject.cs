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
			unitList.Remove(unit);
		}
	

		public void notifyAllResetBallSignal(int velocityX, int velocityY)
		{
			foreach (var unit in unitList)
			{
				unit.updateResetBallSignal(velocityX, velocityY);
			}
		}

		public void receiveResetBallSignal(int velocityX, int velocityY)
		{
			notifyAllResetBallSignal(velocityX, velocityY);
		}

	}
	
}
