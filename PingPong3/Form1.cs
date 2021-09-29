using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static PingPong3.Models.Game;

namespace PingPong3
{
    public partial class Form1 : Form
    {
        HubConnection connection;

        private const int ScreenWidth = 1024;
        private const int ScreenHeight = 768;

        private const int BaseBallSpeed = 2;
        private int _level = 7;

        private GameItem _player1;
        private GameItem _player2;
        private BallItem _ball;

        private HubItem _titleScreen;

        private Random _random;

        private int _scorePlayer1;
        private int _scorePlayer2;

        public Form1()
        {
            InitializeComponent();

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
            ResetBall();

            pbTitleScreen.Hide();

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
            pbPlayer1.Load("Paddle1.png");
            _player1.Texture = pbPlayer1;


            pbPlayer2.Load("Paddle2.png");
            _player2.Texture = pbPlayer2;

            pbBall.Load("Ball.png");
            _ball.Texture = pbBall;

            pbTitleScreen.Load("Fondo.png");
            _titleScreen.Texture = pbTitleScreen;
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
            }
            else
            {
                _titleScreen.Draw();
            }
        }

        #endregion

        #region Mechanics

        private int _currentY;

        

        //TODO: Add select if you are p1 or p2
        //TODO: Allow start only when two are connected
        private void UpdatePlayer()
        {
            int playerX = 0 + 30;
            int playerY = PointToClient(MousePosition).Y;
            //_player1.Position = new Point(playerX, playerY);

            

            if (_player1.Texture.Bottom >= ScreenHeight)
            {
                //_player1.Position = new Point(playerX, ScreenHeight - _player1.Origin.Y - 1);
                var newPosition1 = new Point(playerX, ScreenHeight - _player1.Origin.Y - 1);
                _player1.Position = newPosition1;
                SendPlayer1Position(newPosition1);
            }
            else if (_player1.Texture.Top <= 0)
            {
                //_player1.Position = new Point(playerX, _player1.Origin.Y + 1);
                var newPosition1 = new Point(playerX, _player1.Origin.Y + 1);
                _player1.Position = newPosition1;
                SendPlayer1Position(newPosition1);
            }
            else
            {
                var newPosition1 = new Point(playerX, playerY);
                _player1.Position = newPosition1;
                SendPlayer1Position(newPosition1);
            }

            if (Keyboard.IsKeyDown(Key.S))
            {
                SendMessage("s");
                if (_player2.Texture.Bottom >= ScreenHeight)
                {
                    _currentY -= 0;
                }
                else
                {
                    _currentY += 30;
                }
                var newPosition = new Point(ScreenWidth - 30, _currentY);
                _player2.Position = newPosition;
                SendPlayer2Position(newPosition);
            }
            else if (Keyboard.IsKeyDown(Key.W))
            {
                SendMessage("W");
                if (_player2.Texture.Top <= 0)
                {
                    _currentY += 0;
                }
                else
                {
                    _currentY -= 30;
                }

                int player2X = ScreenWidth - 30;
                int player2Y = _currentY;
                //_player2.Position = new Point(player2X, player2Y);
                var newPosition = new Point(player2X, player2Y);
                _player2.Position = newPosition;
                SendPlayer2Position(newPosition);

            }
        }



        private void ResetBall()
        {
            _level = 7;
            int velocityY = GenerateBallY();
            int velocityX = GenerateBallX();


            _ball.Position = new Point(ScreenWidth / 2, ScreenHeight / 2);
            _ball.Velocity = new Point(velocityX, velocityY);

            _currentBallX = velocityX;
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
            if (pbBall.Left < 0)
            {
                ResetBall();
                _scorePlayer2 += 1;
                lblScore2.Text = _scorePlayer2.ToString();
            }
            else if (pbBall.Right > ScreenWidth)
            {
                ResetBall();
                _scorePlayer1 += 1;
                lblScore1.Text = _scorePlayer1.ToString();
            }
        }

        private void CheckPaddleCollision()
        {
            if (_ball.LeftUpCorner.X < _player1.RightUpCorner.X &&
                _ball.LeftBottomCorner.Y > _player1.RightUpCorner.Y &&
                _ball.LeftUpCorner.Y < _player1.RightBottomCorner.Y)
            {
                _currentBallX = GenerateBallX();
                if (_currentBallX < 0)
                {
                    _currentBallX *= -1;
                }
                _ball.Velocity = new Point(_currentBallX, GenerateBallY());
            }

            if (_ball.RightUpCorner.X > _player2.LeftUpCorner.X &&
                _ball.RightBottomCorner.Y > _player2.LeftUpCorner.Y &&
                _ball.RightUpCorner.Y < _player2.LeftBottomCorner.Y)
            {
                _currentBallX = GenerateBallX();
                if (_currentBallX > 0)
                {
                    _currentBallX *= -1;
                }
                _ball.Velocity = new Point(_currentBallX, GenerateBallY());
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
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                //resultTextBox.Text += message;
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

            try
            {
                await connection.StartAsync();
                //connectButton.Visible = false;
            }
            catch (Exception ex)
            {
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

        #endregion

        private void pbPlayer2_Click(object sender, EventArgs e)
        {
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!_isGameRunning)
            {
                SendStartSignal(GameMode.Basic);
                BeginGame();
                //TODO: allow to change game mode
                
            }   
        }
    }
}
