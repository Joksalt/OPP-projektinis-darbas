
namespace PingPong3.Patterns.Observer
{
	public interface IObserver
	{
		void setServer( Subject server );
		
		void notifyServer(  );
		
		void SendScoreSignal(  );
		
	}
	
}
