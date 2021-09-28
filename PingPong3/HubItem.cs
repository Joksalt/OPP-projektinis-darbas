using System.Drawing;
using System.Windows.Forms;

namespace PingPong3
{
    public class HubItem
    {

        #region properties
        public Point Position { get; set; }
        public PictureBox Texture { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        #endregion

        public void Draw()
        {
            Texture.Left = Position.X;
            Texture.Top = Position.Y;
            Texture.Height = Height;
            Texture.Width = Width;
        }
    }
}
