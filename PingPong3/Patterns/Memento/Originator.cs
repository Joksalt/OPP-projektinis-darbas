using PingPong3.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Memento
{
    public class Originator
    {
        MovingWall player1, player2;
        BallItem ball;

        public MovingWall Player1
        {
            get { return player1; }
            set
            {
                player1 = value;
                Console.WriteLine("Player 1 = " + player1);
            }
        }
        public MovingWall Player2
        {
            get { return player2; }
            set
            {
                player2 = value;
                Console.WriteLine("Player2 = " + player2);
            }
        }
        public BallItem Ball
        {
            get { return ball; }
            set
            {
                ball = value;
                Console.WriteLine("Ball = " + ball);
            }
        }

        public Memento CreateMemento()
        {
            return (new Memento(player1, player1, ball));
        }

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            Player1 = memento.Player1;
            Player2 = memento.Player2;
            Ball = memento.Ball;
        }
    }
}
