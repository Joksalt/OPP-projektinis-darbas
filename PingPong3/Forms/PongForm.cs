using PingPong3.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong3.Forms
{
    public abstract class PongForm : Form
    {
        public BallItem _ball;
        public int _level;
        //---command----
        public GameController _commandController;

        public abstract int GenerateBallX();
        public abstract int GenerateBallY();
        public abstract void notifyResetBallSignal(int velocityX, int velocityY);
    }
}
