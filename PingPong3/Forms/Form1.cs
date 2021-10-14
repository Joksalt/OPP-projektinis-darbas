using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static PingPong3.Models.Game;
using PingPong3.Patterns.Factory;
using PingPong3.Patterns.AbstractFactory;
using PingPong3.Patterns.Singleton_logger;

namespace PingPong3
{
    public partial class Form1 : Form
    {
        HubConnection connection;

        //---------
        public static LoggerSingleton gameLogger = LoggerSingleton.LoggerInstance;
        private string LOG_SENDER = "P1";
        //---------

        private const int ScreenWidth = 1024;
        private const int ScreenHeight = 768;

        private const int BaseBallSpeed = 2;
        private int _level = 7;

        private GameItem _player1;
        private GameItem _player2;
        private GameItem _wall;
        private BallItem _ball;

        private HubItem _titleScreen;

        private Random _random;

        //private PowerUp theSpeed =null;
        //private PowerUpBuilding MakeUFOs = new ExplodePowerUpBuilding();
       
        private PowerUp thePowerUp = null;

        private WallFactory WallFactory = new WallFactory();
        private Wall TheWall = null;

        private int _scorePlayer1;
        private int _scorePlayer2;
        private string a = "";

        public Form1()
        {
            InitializeComponent();

            gameLogger.Write(LOG_SENDER, "start");
            //TODO: Increments by 2. Possible solution - add parameter that checks if it's
            //P1 or P2 playing and only P1 will send goal signals.

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

            //PowerUp theGrunt = MakeUFOs.OrderPowerUp("E");
            //Console.WriteLine(theGrunt);
        }

        #region gameplay methods

        private void BeginGame()
        {
            _isGameRunning = true;
            ResetBall();

            //pbTitleScreen.Hide();

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
            _random = new Random();
            _player1 = new GameItem();

            _player2 = new GameItem
            {
                Position = new Point(ScreenWidth - 3, ScreenHeight / 2)
            };
            _ball = new BallItem
            {
                Velocity = new Point(2, 5)
            };
            //wall game item creation
            _wall = new GameItem
            {
                Position = new Point(100, 500)
            };

            _titleScreen = new HubItem();
            _titleScreen.Position = new Point(0, 0);
            _titleScreen.Width = ScreenWidth;
            _titleScreen.Height = ScreenHeight;
        }


        private void LoadGraphicsContent()
        {
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin\\Debug"));
            path = path + "Images\\";

            pbTitleScreen.Load(path + "Fondo.png");
            _titleScreen.Texture = pbTitleScreen;
            pbTitleScreen.BackColor = Color.Transparent;

            pbPlayer1.Load(path + "Paddle1.png");
            pbTitleScreen.Controls.Add(pbPlayer1);
            _player1.Texture = pbPlayer1;
            pbPlayer1.BackColor = Color.Transparent;

            pbPlayer2.Load(path + "Paddle2.png");
            pbTitleScreen.Controls.Add(pbPlayer2);
            _player2.Texture = pbPlayer2;
            pbPlayer2.BackColor = Color.Transparent;

            pbBall.Load(path + "Ball.png");
            pbTitleScreen.Controls.Add(pbBall);
            _ball.Texture = pbBall;
            pbBall.BackColor = Color.Transparent;

            TheWall = WallFactory.MakeWall(0);
            if (TheWall != null)
            {
                //Wall options from wall factory and picture box creation
                PictureBox wallBox = new PictureBox();
                wallBox.Name = "pbWall";
                wallBox.Size = new System.Drawing.Size(TheWall.GetHeight(), TheWall.GetWidth());
                wallBox.BackColor = TheWall.GetColor();
                _wall.Texture = wallBox;
                // add graphics maby, but probz not
                pbTitleScreen.Controls.Add(wallBox);
            }
            else
            {
                Console.WriteLine("Broken Wall Factory");
            }
            
            int randomNum = _random.Next(2);
            SendPowerUpChange(randomNum);
            //thePowerUp = PowerUpFactory.MakePowerUp(randomNum); //this is in the signals
            if (thePowerUp != null)
            {
                pbBall.Load(thePowerUp.GetName());  
            }
            else
            {
                Console.WriteLine("Something is wrong");
            }
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
                //MoveWall();
            }
            //else if (MouseButtons == MouseButtons.Left)
            //{
            //    BeginGame();
            //}
        }

        private bool _isGameRunning;
        private void DrawScene()
        {
            if (_isGameRunning)
            {
                _player1.Draw();
                _player2.Draw();
                _ball.Draw();
                _wall.Draw();
            }
            else
            {
                _titleScreen.Draw();
            }
        }

        #endregion

        #region Mechanics

        private int _currentYP1;
        private int _currentYP2;
        //FIN: !! Start two forms from main
        //FIN: !! Create different forms for p1 and p2
        

        //TODO: Allow start only when two are connected
        private void UpdatePlayer()
        {
            //------P1

            int player1X = 0 + 30;

            if (Keyboard.IsKeyDown(Key.Down))
            {
                if (_player1.Texture.Bottom >= ScreenHeight)
                {
                    _currentYP1 -= 0;
                }
                else
                {
                    _currentYP1 += 30;
                }
                var newPosition = new Point(player1X, _currentYP1);
                _player1.Position = newPosition;
                SendPlayer1Position(newPosition);
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                if (_player1.Texture.Top <= 0)
                {
                    _currentYP1 += 0;
                }
                else
                {
                    _currentYP1 -= 30;
                }
                var newPosition = new Point(player1X, _currentYP1);
                _player1.Position = newPosition;
                SendPlayer1Position(newPosition);
            }
        }

        private int _currentYW1;

        private void MoveWall()
        {

            int wallX = 0 + 30;

                if (_wall.Texture.Bottom >= ScreenHeight)
                {
                _currentYW1 -= 30;
                }
                else
                {
                _currentYW1 += 30;
                }
            
                if (_wall.Texture.Top <= 0)
                {
                _currentYW1 += 30;
                }
                else
                {
                _currentYW1 -= 30;
                }
                var newPosition = new Point(wallX, _currentYW1);
                _wall.Position = newPosition;
                SendPlayer1Position(newPosition);
        }

        private void ResetBall()
        {
            _level = 7;
            int velocityY = GenerateBallY();
            int velocityX = GenerateBallX();

            gameLogger.Write(LOG_SENDER, "reset ball");
            SendResetBallSignal(velocityX, velocityY);

        }

        private int GenerateBallX()
        {
            _level += 1;
            int velocityX = _level;
            if (_random.Next(2) == 0)
            {
                velocityX *= -1;
            }
            return velocityX;
        }

        private int GenerateBallY()
        {
            _level += (int).5;
            int velocityY = _random.Next(0, _level);
            if (_random.Next(2) == 0)
            {
                velocityY *= -1;
            }
            return velocityY;
        }

        #endregion

        #region Collision

        private int _currentBallX;

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

            
        }

        private void CheckWallOut()
        {
            //P1 goals
            if (pbBall.Right > ScreenWidth)
            {
                ResetBall();
                _scorePlayer1 += 1;
                lblScore1.Text = _scorePlayer1.ToString();

                int randomNum = _random.Next(2);
                SendPowerUpChange(randomNum);
                //thePowerUp = PowerUpFactory.MakePowerUp(randomNum);
                if (thePowerUp != null)
                {
                    pbBall.Load(thePowerUp.GetName());  ///Testing Factory
                }
                else
                {
                    Console.WriteLine("Something is wrong");
                }
                gameLogger.Write(LOG_SENDER, "score");
                SendScoreSignal(_scorePlayer1, 0);
            }
        }

        private void CheckPaddleCollision()
        {
            if (_ball.LeftUpCorner.X < _player1.RightUpCorner.X &&
                _ball.LeftBottomCorner.Y > _player1.RightUpCorner.Y &&
                _ball.LeftUpCorner.Y < _player1.RightBottomCorner.Y)
            {
                SendBallVelocityDirection1(GenerateBallX(), GenerateBallY());
            }

            if (_ball.RightUpCorner.X > _player2.LeftUpCorner.X &&
                _ball.RightBottomCorner.Y > _player2.LeftUpCorner.Y &&
                _ball.RightUpCorner.Y < _player2.LeftBottomCorner.Y)
            {
                SendBallVelocityDirection2(GenerateBallX(), GenerateBallY());
            }
            // ball hitting wall on map check
            if (_ball.RightUpCorner.X > _wall.LeftUpCorner.X &&
                _ball.RightBottomCorner.Y > _wall.LeftUpCorner.Y &&
                _ball.RightUpCorner.Y < _wall.LeftBottomCorner.Y)
            {
                SendBallVelocityDirection2(GenerateBallX(), GenerateBallY());
            }
            if( _ball.LeftUpCorner.X < _wall.RightUpCorner.X &&
                _ball.LeftBottomCorner.Y > _wall.RightUpCorner.Y &&
                _ball.LeftUpCorner.Y < _wall.RightBottomCorner.Y)
            {
                SendBallVelocityDirection1(GenerateBallX(), GenerateBallY());
            }
        }
        #endregion

        #region TestSignalR
        private async void SendMessage(string message)
        {
            try
            {
                await connection.InvokeAsync("SendMessage",
                    "aa", message);
            }
            catch (Exception ex)
            {
                //messagesList.Items.Add(ex.Message);
            }
        }
        #endregion

        #region SignalRMessages

        private async void connectButton_Click(object sender, EventArgs e)
        {
            connection.On<int>("RecievePowerUpChange", (random) =>
            {
                //thePowerUp = PowerUp.Equals(random);
            });

            connection.On<int, int>("ReceivePlayer2Position", (x, y) =>
            {
                var newPosition = new Point(x, y);
                _player2.Position = newPosition;
            });

            connection.On<int, int>("ReceivePlayer1Position", (x, y) =>
            {
                var newPosition = new Point(x, y);
                _player1.Position = newPosition;
            });

            connection.On<int>("ReceiveStartSignal", (mode) =>
            {
                //TODO: set correct game mode
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
                    _scorePlayer1 = score;
                    lblScore1.Text = _scorePlayer1.ToString();
                }
                else
                {
                    _scorePlayer2 = score;
                    lblScore2.Text = _scorePlayer2.ToString();
                }
            });

            connection.On<int, int>("ReceiveBallVelocityDirection1", (velocityX, velocityY) =>
            {
                _currentBallX = velocityX;
                if (_currentBallX < 0)
                {
                    _currentBallX *= -1;
                }
                _ball.Velocity = new Point(_currentBallX, velocityY);
            });

            connection.On<int, int>("ReceiveBallVelocityDirection2", (velocityX, velocityY) =>
            {
                _currentBallX = velocityX;
                if (_currentBallX > 0)
                {
                    _currentBallX *= -1;
                }
                _ball.Velocity = new Point(_currentBallX, velocityY);
            });

            

            try
            {
                await connection.StartAsync();
                //connectButton.Visible = false;
            }
            catch (Exception ex)
            {
            }
        }
        private async void SendPowerUpChange(int randomNum)
        {
            try
            {
                await connection.InvokeAsync("SendPowerUpChange", randomNum);
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
                //messagesList.Items.Add(ex.Message);
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
                //messagesList.Items.Add(ex.Message);
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
                //messagesList.Items.Add(ex.Message);
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
                //messagesList.Items.Add(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="score"></param>
        /// <param name="player">Equals 0 if for P1, equals 1 if for P2</param>
        private async void SendScoreSignal(int score, int player)
        {
            try
            {
                await connection.InvokeAsync("SendScoreSignal", score, player);
            }
            catch (Exception ex)
            {
                //messagesList.Items.Add(ex.Message);
            }
        }

        private async void SendBallVelocityDirection1(int velocityX, int velocityY)
        {
            try
            {
                await connection.InvokeAsync("SendBallVelocityDirection1", velocityX, velocityY);
            }
            catch (Exception ex)
            {
                //messagesList.Items.Add(ex.Message);
            }
        }

        private async void SendBallVelocityDirection2(int velocityX, int velocityY)
        {
            try
            {
                await connection.InvokeAsync("SendBallVelocityDirection2", velocityX, velocityY);
            }
            catch (Exception ex)
            {
                //messagesList.Items.Add(ex.Message);
            }
        }

        #endregion

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
    }
}
