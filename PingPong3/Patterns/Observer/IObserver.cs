
namespace PingPong3.Patterns.Observer
{
	public interface IObserver
	{
		void setServer( Subject server );
		
		void notifyResetBallSignal(int velocityX, int velocityY);
		
		void updateResetBallSignal(int velocityX, int velocityY);
		
	}
	
}
