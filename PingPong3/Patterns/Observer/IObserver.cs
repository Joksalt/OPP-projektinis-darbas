
namespace PingPong3.Patterns.Observer
{
	public interface IObserver
	{
		void setServer( Subject server );
		
		void notifyServer(string message);
		
		void update(string msg);
		
	}
	
}
