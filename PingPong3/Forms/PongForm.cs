using PingPong3.Patterns.Command;
using PingPong3.Patterns.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PingPong3.Patterns.Decorator;

namespace PingPong3.Forms
{
    public abstract class PongForm : Form
    {
        public BallItem _ball;
        public int _level;
        //---command----
        public Random _random;
        public GameController _commandController;
        public int playerSelfScore;
        public int playerOtherScore;
        public int _playerSelfIndex;
        protected Background background;
        //----template---
        public string _racketMode1, _racketMode2;
        public static RacketStyle defaultRacket = new DefaultRacketMode();
        public static RacketStyle normalRacket = new RacketMode1(defaultRacket);
        public static RacketStyle devRacket = new RacketMode2(normalRacket);
        //public RacketStyle defaultRacket;
        //public RacketMode1 normalRacket;
        //public RacketMode2 devRacket;
        public bool _PowerUpExists;

        public abstract int GenerateBallX();
        public abstract int GenerateBallY();
        public abstract void notifyResetBallSignal(int velocityX, int velocityY);
        public abstract void SendScoreSignal(int score, int player);
        public abstract void SendRacketSkin(string racket);
        public abstract void SendRacketSkin2(string racket);

        public Background Background
        {
            set { background = value; }
        }

        public virtual void setBackgroundTheme()
        {
            background.setBackgroundTheme();
        }

        //---template--
        public void RacketPowerUpReseter()
        {
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin\\Debug"));
            path = path + "Images\\";

            SendRacketSkin(path + "Paddle1" + ".png");
            SendRacketSkin2(path + "Paddle1" + ".png");
            _racketMode1 = "default";
            _racketMode2 = "default";
        }
        //public void RacketSkinSender(string picture)
        //{
        //    String path = System.IO.Directory.GetCurrentDirectory();
        //    path = path.Substring(0, path.LastIndexOf("bin\\Debug"));
        //    path = path + "Images\\";

        //    SendRacketSkin(path + picture + ".png");
        //    //SendRacketSkin2(path + picture + ".png");
        //}
    }
}
