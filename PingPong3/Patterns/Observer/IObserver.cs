
namespace PingPong3.Patterns.Observer
{
	public interface IObserver
	{
		void setServer( Subject server );
		
		void notifyServer(string message);
		void notifyResetBallSignal(int velocityX, int velocityY);
		
		void update(string msg);
		void updateResetBallSignal(int velocityX, int velocityY);
		
	}
	
}
