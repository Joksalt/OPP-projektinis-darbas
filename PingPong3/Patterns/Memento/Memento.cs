using PingPong3.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Memento
{
    public class Memento
    {
        MovingWall player1, player2;
        BallItem ball;

        public Memento(MovingWall p1, MovingWall p2, BallItem b)
        {
            this.player1 = p1;
            this.player2 = p2;
            this.ball = b;
        }
        public MovingWall Player1
        {
            get { return player1; }
        }
        public MovingWall Player2
        {
            get { return player2; }
        }
        public BallItem Ball
        {
            get { return ball; }
        }

    }
}
