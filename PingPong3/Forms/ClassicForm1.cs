using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static PingPong3.Models.Game;
using PingPong3.Patterns.Factory;
using PingPong3.Patterns.AbstractFactory;
using PingPong3.Patterns.Adapter;
using PingPong3.Patterns.Singleton_logger;
using PingPong3.Patterns.Strategy;
using PingPong3.Patterns.Builder;
using PingPong3.Patterns.Decorator;
using PingPong3.Patterns.Bridge;
using System.Collections.Generic;
using System.Timers;
using PingPong3.Patterns.Observer;
using PingPong3.Patterns.Command;
using PingPong3.Forms;
using PingPong3.Patterns.Template;
using PingPong3.Patterns.ChainOfCommand;

namespace PingPong3
{
    //public partial class Form1 : PongForm, IObserver
    public partial class ClassicForm1 :  GoalTemplate, IObserver
    {
        #region Variables
        HubConnection connection;

        //---------
        public static LoggerSingleton gameLogger = LoggerSingleton.LoggerInstance;
        private string LOG_SENDER = "P1";
        //---------

        //--Observer---
        private Subject _server;

        private const int ScreenWidth = 1024;
        private const int ScreenHeight = 768;

        private const int BaseBallSpeed = 2;

        private MovingWall _player1, _player2;

        private HubItem _titleScreen;

        private Random randomSeed;

        private System.Timers.Timer myTimer = new System.Timers.Timer();

        private PowerUpFactory MakePowerUpPositive = new PositivePowerUpFactory();
        private PowerUpFactory MakePowerUpNegative = new NegativePowerUpFactory();


        private WallFactory WallFactory = new WallFactory();


        private bool _isGameRunning;


        private int _currentBallX;


        private LevelDirector levelDirector;
        private ClassicLevelBuilder classicLevelBuilder;
        private AdvancedLevelBuilder advancedLevelBuilder;
        private FrenzyLevelBuilder frenzyLevelBuilder;
        private LevelData levelData;


        private CertainSound WinSound = new CertainSound("Win");
        private CertainSound HitSound = new CertainSound("Hit");
        private CertainSound ScoreSound = new CertainSound("Score");
        private CertainSound MissSound = new CertainSound("Miss");

        private HeartHandler p1HeartHandler, p1SecondHandler, p1FinalHandler, p2HeartHandler, p2SecondHandler, p2FinalHandler;
        private HeartItem p1H1, p1H2, p1H3, p2H1, p2H2, p2H3;
        #endregion

        #region FormConstructor
        public ClassicForm1()
        {
            _level = 7;
            playerSelfScore = 0;
            playerOtherScore = 0;
            _playerSelfIndex = 0;

            _racketMode1 = "default";
            //TODO: different from form1
            _PowerUpExists = false;

            InitializeComponent();

            gameLogger.Write(LOG_SENDER, "start");

            #region SignalRconnection
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:53353/ChatHub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
            #endregion

            ClientSize = new Size(ScreenWidth, ScreenHeight);
            Initialize();
            Load += Form1_Load;

            _commandController = new GameController();
            
        }
        #endregion

        #region GameplayMethods
        private void BeginGame()
        {
            _isGameRunning = true;
            _commandController.Run(new BallResetCommand(this));
            
            _racketMode1 = "default";
            RacketSkinSender(defaultRacket.GetSkin());
            _PowerUpExists = true;

            lblScore1.Hide();
            lblScore2.Hide();
            label4.Hide();
            connectButton.Hide();
            startButton.Hide();
            //ResetBall();
        }
        //private void EndGame()
        //{
        //    _isGameRunning = false;
        //    pbTitleScreen.Show();
        //}
        #endregion

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGraphicsContent();
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateScene();
        }
        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            DrawScene();
        }
        #endregion

        #region EngineMethods
        private void Initialize()
        {
            levelDirector = new LevelDirector();
            classicLevelBuilder = new ClassicLevelBuilder();
            advancedLevelBuilder = new AdvancedLevelBuilder();
            frenzyLevelBuilder = new FrenzyLevelBuilder();

            levelDirector.ConstructWalls(classicLevelBuilder, _mediator, normalRacket, defaultRacket);
            levelData = classicLevelBuilder.GetResult();

            InitializeHearts();

            randomSeed = new Random();
            _player1 = WallFactory.MakeWall(1, _mediator, normalRacket, defaultRacket).SetData(new Point(30, ScreenHeight / 2), new Size(30, 180), Color.White, 0, 0, new Point(0, 0)) as MovingWall;
            _player1.SetMove(new PlayerMove(_player1));
            _player2 = WallFactory.MakeWall(1, _mediator, normalRacket, defaultRacket).SetData(new Point(ScreenWidth - 30, ScreenHeight / 2), new Size(30, 180), Color.White, 0, 0, new Point(0, 0)) as MovingWall;
            _player2.SetMove(new PlayerMove(_player2));
            _ball = new BallItem
            {
                Velocity = new Point(2, 5)
            };

            _titleScreen = new HubItem { 
                Position = new Point(0, 0),
                Width = ScreenWidth,
                Height = ScreenHeight
            };
        }
        private void InitializeHearts()
        {
            p1HeartHandler = new FirstHeartHandler();
            p1SecondHandler = new SecondHeartHandler();
            p1FinalHandler = new FinalHeartHandler();
            p1SecondHandler.SetSuccessor(p1FinalHandler);
            p1HeartHandler.SetSuccessor(p1SecondHandler);

            p2HeartHandler = new FirstHeartHandler();
            p2SecondHandler = new SecondHeartHandler();
            p2FinalHandler = new FinalHeartHandler();
            p2SecondHandler.SetSuccessor(p2FinalHandler);
            p2HeartHandler.SetSuccessor(p2SecondHandler);

            p1H1 = new HeartItem("p1H1");
            p1H2 = new HeartItem("p1H2");
            p1H3 = new HeartItem("p1H3");

            p2H1 = new HeartItem("p2H1");
            p2H2 = new HeartItem("p2H2");
            p2H3 = new HeartItem("p2H3");
        }
        private void LoadGraphicsContent()
        {
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin\\Debug"));
            path = path + "Images\\";

            // ----------- BRIDGE PATTERN ----------------
            //Form's background picture
            //pbTitleScreen.Load(path + "Fondo.png");
            setBackgroundTheme();
            pbTitleScreen.Load(this.background.setBackgroundTheme());

            _titleScreen.Texture = pbTitleScreen;
            pbTitleScreen.BackColor = Color.Transparent;

            pbPlayer1.Load(path + defaultRacket.GetSkin() + ".png");
            pbTitleScreen.Controls.Add(pbPlayer1);
            _player1.Texture = pbPlayer1;
            pbPlayer1.BackColor = Color.Transparent;

            pbPlayer2.Load(path + defaultRacket.GetSkin() + ".png");
            pbTitleScreen.Controls.Add(pbPlayer2);
            _player2.Texture = pbPlayer2;
            pbPlayer2.BackColor = Color.Transparent;

            foreach(Wall w in levelData.walls)
            {
                pbTitleScreen.Controls.Add(w.Texture);
            }

            pbBall.Load(path + "Ball.png");
            pbTitleScreen.Controls.Add(pbBall);
            _ball.Texture = pbBall;
            pbBall.BackColor = Color.Transparent;

            SetHeartData();
        }
        private void SetHeartData()
        {
            p1FinalHandler.SetData(pbTitleScreen, p1H1, this, 30);
            p1SecondHandler.SetData(pbTitleScreen, p1H2, this, 80);
            p1HeartHandler.SetData(pbTitleScreen, p1H3, this, 130);

            p2FinalHandler.SetData(pbTitleScreen, p2H1, this, ScreenWidth - 130);
            p2SecondHandler.SetData(pbTitleScreen, p2H2, this, ScreenWidth - 80);
            p2HeartHandler.SetData(pbTitleScreen, p2H3, this, ScreenWidth - 30);
        }
        private void UpdateScene()
        {
            if (_isGameRunning)
            {
                UpdatePlayer();
                _ball.Update();

                CheckWallCollision();
                CheckWallOut();
                CheckPaddleCollision();
                //CheckMapWallCollision();
                foreach (Wall w in levelData.walls)
                {
                    if (w is MovingWall)
                    {
                        (w as MovingWall).Move();
                    }
                }
                p1H1.Draw();
            }
        }
        private void DrawScene()
        {
            if (_isGameRunning)
            {
                //TODO: P1 move command
                _player1.Draw();
                _player2.Draw();
                //TODO: ball move command
                _ball.Draw();


                foreach (Wall w in levelData.walls)
                {
                    w.Draw();
                }

                p1H1.Draw();
                p1H2.Draw();
                p1H3.Draw();
                p2H1.Draw();
                p2H2.Draw();
                p2H3.Draw();
            }
            else
            {
                _titleScreen.Draw();
            }
        }
        #endregion

        #region Mechanics
        private void UpdatePlayer()
        {
            
            //------P1
            if (Keyboard.IsKeyDown(Key.S))
            {
                if (_player1.Texture.Bottom >= ScreenHeight)//ScreenHeight/2;
                    //TODO: command change p1 velocity
                    _player1.Velocity = new Point(0, 0);
                else
                {
                    //if (_ball.Player1Hit && !_PowerUpExists)
                    if (!_PowerUpExists)
                    {
                        //TODO: racket mode
                        switch (_racketMode1)
                        {
                            case "+normal":
                                _player1.Velocity = new Point(0, _player1.CurrentSpeed + normalRacket.GetSpeed());
                                break;
                            case "-normal":
                                _player1.Velocity = new Point(0, _player1.CurrentSpeed - normalRacket.GetSpeed());
                                break;
                            case "dev":
                                _player1.Velocity = new Point(0, _player1.CurrentSpeed + devRacket.GetSpeed());
                                break;
                            default:
                                _player1.Velocity = new Point(0, _player1.CurrentSpeed);
                                break;
                        }

                    }
                    else
                    {
                        _player1.Velocity = new Point(0, _player1.CurrentSpeed);
                    }
                }
                    
                    
                _player1.Move();
                SendPlayer1Position(_player1.Position);
            }
            else if (Keyboard.IsKeyDown(Key.W))
            {
                if (_player1.Texture.Top <= 0)
                    _player1.Velocity = new Point(0, 0);
                else
                {
                    if (!_PowerUpExists)
                    {
                        switch (_racketMode1)
                        {
                            case "+normal":
                                _player1.Velocity = new Point(0, -_player1.CurrentSpeed - normalRacket.GetSpeed());
                                break;
                            case "-normal":
                                _player1.Velocity = new Point(0, -_player1.CurrentSpeed + normalRacket.GetSpeed());
                                break;
                            case "dev":
                                _player1.Velocity = new Point(0, -_player1.CurrentSpeed - devRacket.GetSpeed());
                                break;
                            default:
                                _player1.Velocity = new Point(0, -_player1.CurrentSpeed);
                                break;
                        }
                    }
                    else
                    {
                        _player1.Velocity = new Point(0, -_player1.CurrentSpeed);
                    }
                }
                   
                _player1.Move();
                SendPlayer1Position(_player1.Position);
            }
            if (!_PowerUpExists)
            {
                //TODO: loops around here
                switch (_racketMode1)
                {
                    case "+normal":
                        RacketSkinSender(normalRacket.GetSkin());
                        break;
                    case "-normal":
                        RacketSkinSender(devRacket.GetSkin());
                        break;
                    case "dev":
                        RacketSkinSender(devRacket.GetSkin());
                        break;
                    default:
                        RacketSkinSender(defaultRacket.GetSkin());
                        break;
                }
            }
            else
            {
                RacketSkinSender(defaultRacket.GetSkin());
            }
            if (Keyboard.IsKeyDown(Key.D1))
            {
                _racketMode1 = "default";
            }
            if (Keyboard.IsKeyDown(Key.D2))
            {
                _racketMode1 = "+normal";
            }
            if (Keyboard.IsKeyDown(Key.D3))
            {
                _racketMode1 = "dev";
            }
            //Undo last command
            if (Keyboard.IsKeyDown(Key.D4))
            {
                _commandController.Undo();
            }
        }
        private void PowerUpMaking()
        {
            _PowerUpExists = true;
            int randomPowerUp = randomSeed.Next(2);
            SendPowerUpChange(randomPowerUp);
        }
        //private void RacketSkinReseter()
        //{
        //    String path = System.IO.Directory.GetCurrentDirectory();
        //    path = path.Substring(0, path.LastIndexOf("bin\\Debug"));
        //    path = path + "Images\\";

        //    SendRacketSkin(path + "Paddle1" + ".png");
        //    SendRacketSkin2(path + "Paddle1" + ".png");
        //}
        private void RacketSkinSender(string picture)
        {
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin\\Debug"));
            path = path + "Images\\";

            SendRacketSkin(path + picture + ".png");
        }
        /// <summary>
        /// Tiemr to spawn power ups. Now not in use. Add in later
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            if (!_PowerUpExists)
                _PowerUpExists = true;
        }
        public override int GenerateBallX()
        {
            _level += 1;
            int velocityX = _level;
            if (randomSeed.Next(2) == 0)
            {
                velocityX *= -1;
            }
            return velocityX;
        }
        public override int GenerateBallY()
        {
            _level += (int).5;
            int velocityY = randomSeed.Next(0, _level);
            if (randomSeed.Next(2) == 0)
            {
                velocityY *= -1;
            }
            return velocityY;
        }
        #endregion

        #region Collision
        private void CheckWallCollision()
        {
            if (pbBall.Bottom >= ScreenHeight)
            {
                _ball.Velocity = new Point(_currentBallX, -BaseBallSpeed);
            }
            else if (pbBall.Top <= 0)
            {
                _ball.Velocity = new Point(_currentBallX, BaseBallSpeed);
            }

            
            foreach (Wall w in levelData.walls)
            {
                if (_ball.LeftUpCorner.X < w.RightUpCorner.X &&
                    _ball.LeftBottomCorner.Y > w.RightUpCorner.Y &&
                    _ball.LeftUpCorner.Y < w.RightBottomCorner.Y &&
                    _ball.RightUpCorner.X > w.LeftUpCorner.X)
                {
                    if (_currentBallX < 0)
                        SendBallVelocityDirection1(_ball.Position.X, _ball.Position.Y, GenerateBallX(), GenerateBallY());
                    else
                        SendBallVelocityDirection2(_ball.Position.X, _ball.Position.Y, GenerateBallX(), GenerateBallY());
                }
            }
            
        }
        private void CheckWallOut()
        {
            //P1 goals
            if (pbBall.Right > ScreenWidth)
            {
                GoalProcess();
                //ResetBall();

                lblScore1.Text = playerSelfScore.ToString();
                gameLogger.Write(LOG_SENDER, "score");



                //playerSelfScore += 1;
                //lblScore1.Text = playerSelfScore.ToString();
                //gameLogger.Write(LOG_SENDER, "score");
                //SendScoreSignal(playerSelfScore, _playerSelfIndex);
            }
        }
        private void CheckPaddleCollision()
        {
            if (_ball.LeftUpCorner.X < _player1.RightUpCorner.X &&
                _ball.LeftBottomCorner.Y > _player1.RightUpCorner.Y &&
                _ball.LeftUpCorner.Y < _player1.RightBottomCorner.Y)
            {
                SendBallVelocityDirection1(_ball.Position.X, _ball.Position.Y, GenerateBallX(), GenerateBallY());
                SendPlayer1HitBool(true);
            }

            if (_ball.RightUpCorner.X > _player2.LeftUpCorner.X &&
                _ball.RightBottomCorner.Y > _player2.LeftUpCorner.Y &&
                _ball.RightUpCorner.Y < _player2.LeftBottomCorner.Y)
            {
                SendBallVelocityDirection2(_ball.Position.X, _ball.Position.Y, GenerateBallX(), GenerateBallY());
                SendPlayer1HitBool(true);
            }
        }
        #endregion

        #region TestSignalR
        private async void SendMessage(string message)
        {
            try
            {
                await connection.InvokeAsync("SendMessage", "aa", message);
            }
            catch (Exception ex)
            {
                gameLogger.Write(LOG_SENDER, ex.Message);
            }
        }
        #endregion

        #region SignalRMessages
        private async void connectButton_Click(object sender, EventArgs e)
        {
            connection.On<int>("RecievePowerUpChange", (powerUp) =>
            {
                ////thePowerUp = PowerUp.Equals(random);
            });
            connection.On<bool>("RecievePlayer1HitBool", (Player1Hit) =>
            {
                //Console.WriteLine("Plauyer 1 " + Player1Hit);
                _ball.Player1Hit = Player1Hit;
            });
            connection.On<string>("RecieveRacketSkin", (racket) =>
            {
                //Console.WriteLine(racket);
                pbPlayer1.Load(racket);
            });
            connection.On<string>("RecieveRacketSkin2", (racket) =>
            {
                //Console.WriteLine(racket);
                pbPlayer2.Load(racket);
            });
            connection.On<int, int>("ReceivePlayer2Position", (x, y) =>
            {
                _player2.Position = new Point(x, y);
            });
            connection.On<int, int>("ReceivePlayer1Position", (x, y) =>
            {
                _player1.Position = new Point(x, y);
            });
            connection.On<int>("ReceiveStartSignal", (mode) =>
            {
                BeginGame();
            });
            connection.On<int, int>("ReceiveResetBallSignal", (velocityX, velocityY) =>
            {
                _ball.Position = new Point(ScreenWidth / 2, ScreenHeight / 2);
                _ball.Velocity = new Point(velocityX, velocityY);

                _currentBallX = velocityX;
            });
            connection.On<int, int>("ReceiveScoreSignal", (score, player) =>
            {
                if (player == 0)
                {
                    playerSelfScore = score;
                    //lblScore1.Text = playerSelfScore.ToString();
                    p2HeartHandler.HandleRequest(score);
                    //ScoreSound.RequestSound();
                }
                else
                {
                    playerOtherScore = score;
                    playerOtherScore = score;//Excuse me, wtf? -Symuciakas
                    //lblScore2.Text = playerOtherScore.ToString();
                    p1HeartHandler.HandleRequest(score);
                    //MissSound.RequestSound();
                }
            });
            connection.On<int, int, int, int>("ReceiveBallVelocityDirection1", (positionX, positionY, velocityX, velocityY) =>
            {
                _currentBallX = velocityX;
                if (_currentBallX < 0)
                {
                    _currentBallX *= -1;
                }
                _ball.Velocity = new Point(_currentBallX, velocityY);
                _ball.Position = new Point(positionX, positionY);
                //HitSound.RequestSound();
            });
            connection.On<int, int, int, int>("ReceiveBallVelocityDirection2", (positionX, positionY, velocityX, velocityY) =>
            {
                _currentBallX = velocityX;
                if (_currentBallX > 0)
                {
                    _currentBallX *= -1;
                }
                _ball.Velocity = new Point(_currentBallX, velocityY);
                _ball.Position = new Point(positionX, positionY);
                //HitSound.RequestSound();
            });
            try
            {
                await connection.StartAsync();
                //connectButton.Visible = false;
            }
            catch (Exception ex)
            {
                gameLogger.Write(LOG_SENDER, ex.Message);
            }
        }
        private async void SendPowerUpChange(int powerUp)
        {
            try
            {
                await connection.InvokeAsync("SendPowerUpChange", powerUp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private async void SendPlayer1HitBool(bool Player1Hit)
        {
            try
            {
                await connection.InvokeAsync("SendPlayer1HitBool", Player1Hit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public override async void SendRacketSkin(string racket)
        {
            try
            {
                await connection.InvokeAsync("SendRacketSkin", racket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public override async void SendRacketSkin2(string racket)
        {
            try
            {
                await connection.InvokeAsync("SendRacketSkin2", racket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private async void SendPlayer2Position(Point playerPosition)
        {
            try
            {
                await connection.InvokeAsync("SendPlayer2Position", playerPosition.X, playerPosition.Y);
            }
            catch (Exception ex)
            {
                gameLogger.Write(LOG_SENDER, ex.Message);
            }
        }
        private async void SendPlayer1Position(Point playerPosition)
        {
            try
            {
                await connection.InvokeAsync("SendPlayer1Position", playerPosition.X, playerPosition.Y);
            }
            catch (Exception ex)
            {
                gameLogger.Write(LOG_SENDER, ex.Message);
            }
        }
        private async void SendStartSignal(GameMode gameMode)
        {
            try
            {
                await connection.InvokeAsync("SendStartSignal", ((int)gameMode));
            }
            catch (Exception ex)
            {
                gameLogger.Write(LOG_SENDER, ex.Message);
            }
        }
        private async void SendResetBallSignal(int velocityX, int velocityY)
        {
            try
            {
                await connection.InvokeAsync("SendResetBallSignal", velocityX, velocityY);
            }
            catch (Exception ex)
            {
                gameLogger.Write(LOG_SENDER, ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="score"></param>
        /// <param name="player">Equals 0 if for P1, equals 1 if for P2</param>
        public override async void SendScoreSignal(int score, int player)
        {
            try
            {
                await connection.InvokeAsync("SendScoreSignal", score, player);
            }
            catch (Exception ex)
            {
                gameLogger.Write(LOG_SENDER, ex.Message);
            }
        }
        private async void SendBallVelocityDirection1(int positionX, int positionY, int velocityX, int velocityY)
        {
            try
            {
                await connection.InvokeAsync("SendBallVelocityDirection1", positionX, positionY, velocityX, velocityY);
            }
            catch (Exception ex)
            {
                gameLogger.Write(LOG_SENDER, ex.Message);
            }
        }
        private async void SendBallVelocityDirection2(int positionX, int positionY, int velocityX, int velocityY)
        {
            try
            {
                await connection.InvokeAsync("SendBallVelocityDirection2", positionX, positionY, velocityX, velocityY);
            }
            catch (Exception ex)
            {
                gameLogger.Write(LOG_SENDER, ex.Message);
            }
        }
        #endregion

        #region ButtonClicks
        private void pbPlayer2_Click(object sender, EventArgs e)
        {
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!_isGameRunning)
            {
                SendStartSignal(GameMode.Basic);
                //BeginGame();                
            }   
        }

        private void pbWall_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #region ObserverImplementation

        public void setServer(Subject server)
        {
            _server = server;
        }

        public override void notifyResetBallSignal(int velocityX, int velocityY)
        {
            _server.receiveResetBallSignal(velocityX, velocityY);
        }

        public void updateResetBallSignal(int velocityX, int velocityY)
        {
            _ball.Position = new Point(ScreenWidth / 2, ScreenHeight / 2);
            _ball.Velocity = new Point(velocityX, velocityY);

            _currentBallX = velocityX;
        }

        #endregion

        #region TemplateImplementation
        public override bool NeedToRemovePowers()
        {
            return false;
        }

        public override bool NeedToLimitPoints()
        {
            return true;
        }
        #endregion

        public override void setBackgroundTheme()
        {
            //this.background = new DynamicBackground();
            this.background = new ClassicBackground();
        }
    }
}
