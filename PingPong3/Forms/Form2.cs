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
    public partial class Form2 : Form
    {
        HubConnection connection;

        //---------
        public static Logger gameLogger = Logger.LoggerInstance;
        private string LOG_SENDER = "P2";
        //---------

        private const int ScreenWidth = 1024;
        private const int ScreenHeight = 768;

        private const int BaseBallSpeed = 2;
        private int _level = 7;

        private GameItem _player1;
        private GameItem _player2;
        private BallItem _ball;

        private HubItem _titleScreen;

        private Random _random;

        //private PowerUp theSpeed =null;
        private PowerUpFactory PowerUpFactory = new PowerUpFactory();
        private PowerUp thePowerUp = null;

        private int _scorePlayer1;
        private int _scorePlayer2;
        private string a = "";

        public Form2()
        {
            InitializeComponent();

            gameLogger.Write(LOG_SENDER,"start");
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

            
        }

        #region gameplay methods

        private void BeginGame()
        {
            _isGameRunning = true;
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

            _titleScreen = new HubItem();
            _titleScreen.Position = new Point(0, 0);
            _titleScreen.Width = ScreenWidth;
            _titleScreen.Height = ScreenHeight;
        }

        

        private void LoadGraphicsContent()
        {

            pbTitleScreen.Load("Fondo.png");
            _titleScreen.Texture = pbTitleScreen;

            pbPlayer1.Load("Paddle1.png");
            pbTitleScreen.Controls.Add(pbPlayer1);
            _player1.Texture = pbPlayer1;
            pbPlayer1.BackColor = Color.Transparent;


            pbPlayer2.Load("Paddle2.png");
            pbTitleScreen.Controls.Add(pbPlayer2);
            _player2.Texture = pbPlayer2;
            pbPlayer2.BackColor = Color.Transparent;

            pbBall.Load("Ball.png");
            pbTitleScreen.Controls.Add(pbBall);
            _ball.Texture = pbBall;
            pbBall.BackColor = Color.Transparent;
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
            }
        }

        private bool _isGameRunning;
        private void DrawScene()
        {
            if (_isGameRunning)
            {
                _player1.Draw();
                _player2.Draw();
                _ball.Draw();
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
        

        //TODO: !! Add select if you are p1 or p2
        //TODO: Allow start only when two are connected
        private void UpdatePlayer()
        {
            //--------P2
            if (Keyboard.IsKeyDown(Key.S))
            {
                if (_player2.Texture.Bottom >= ScreenHeight)
                {
                    _currentYP2 -= 0;
                }
                else
                {
                    _currentYP2 += 30;
                }
                var newPosition = new Point(ScreenWidth - 30, _currentYP2);
                _player2.Position = newPosition;
                SendPlayer2Position(newPosition);
            }
            else if (Keyboard.IsKeyDown(Key.W))
            {
                if (_player2.Texture.Top <= 0)
                {
                    _currentYP2 += 0;
                }
                else
                {
                    _currentYP2 -= 30;
                }

                int player2X = ScreenWidth - 30;
                //_player2.Position = new Point(player2X, player2Y);
                var newPosition = new Point(player2X, _currentYP2);
                _player2.Position = newPosition;
                SendPlayer2Position(newPosition);

            }
        }



        private void ResetBall()
        {
            _level = 7;
            int velocityY = GenerateBallY();
            int velocityX = GenerateBallX();

            gameLogger.Write(LOG_SENDER,"reset ball");
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
            //P2 goals
            if (pbBall.Left < 0)
            {
                ResetBall();
                _scorePlayer2 += 1;
                lblScore2.Text = _scorePlayer2.ToString();
                gameLogger.Write(LOG_SENDER,"score");
                SendScoreSignal(_scorePlayer2, 1);
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
        }
        #endregion

        #region SignalRMessages

        private async void connectButton_Click(object sender, EventArgs e)
        {
            connection.On<int>("RecievePowerUpChange", (random) =>
            {
                thePowerUp = PowerUpFactory.MakePowerUp(random);
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
    }
}
