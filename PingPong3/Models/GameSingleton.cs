using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Models
{
	public sealed class GameSingleton
	{
		private int P1Points;
		private int P2Points;

		private GameSingleton()
		{
			P1Points = 0;
			P2Points = 0;
		}

		public static GameSingleton Instance { get { return Nested.instance; } }

		private class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly GameSingleton instance = new GameSingleton();
		}
	}

	public enum GameMode
    {
        Basic,
        Advanced,
        Frenzy
    }
}


	//Game saves points and defines if goal was made??
	//public class GameSingleton
	//   {

//	private static bool instantiated = false;

//	public static class SingletonHolder
//	{
//		GameSingleton instance = new GameSingleton();
//	}

//	private GameSingleton()
//	{
//		Activity();
//		instantiated = true;
//	}

//	private static void Activity() { 
//	}

//	public static GameSingleton GetInstance()
//	{

//		//if (instantiated == false)
//		//{
//		//	System.out.println("First call to InnerHolderSingleton getInstance()");
//		//}
//		return SingletonHolder.instance;
//	}

//	public enum GameMode
//       {
//           Basic,
//           Advanced,
//           Frenzy
//       }
//   }
