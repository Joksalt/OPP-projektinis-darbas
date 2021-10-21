using System.Drawing;
using System.Windows.Forms;

namespace PingPong3
{
    public class GameItem
    {
        public Point Position { get; set; }
        public Point Velocity { get; set; }
        public PictureBox Texture { get; set; }
        public Point Origin
        {
            get
            {
                return new Point(Texture.Width / 2, Texture.Height / 2);
            }
        }
        public Point LeftUpCorner
        {
            get { return new Point(Position.X - Origin.X, Position.Y - Origin.Y); }
        }
        public Point RightUpCorner
        {
            get { return new Point(Position.X + Origin.X, Position.Y - Origin.Y); }
        }
        public Point LeftBottomCorner
        {
            get { return new Point(Position.X - Origin.X, Position.Y + Origin.Y); }
        }
        public Point RightBottomCorner
        {
            get { return new Point(Position.X + Origin.X, Position.Y + Origin.Y); }
        }
        public void Draw()
        {
            Texture.Location = new Point(Position.X - Origin.X,
                Position.Y - Origin.Y);
        }
        public void Remove()
        {
            Texture.Hide();
        }
    }
}
