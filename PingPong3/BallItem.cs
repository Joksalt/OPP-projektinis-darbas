using System.Drawing;
using System.Windows.Forms;
using PingPong3.Patterns.Prototype;

namespace PingPong3
{
    public class BallItem : GameItem, IPrototype
    {

        public BallItem() { }
        
        public BallItem(Point position, Point velocity, PictureBox texture)
        {
            this.Position = position;
            this.Velocity = velocity;
            this.Texture = texture;
        }

        public void Update()
        {
            Position = new Point(Position.X + Velocity.X,
                Position.Y + Velocity.Y);
        }

        public IPrototype DeepCopy()
        {
            BallItem ballItemDeepCopy = new BallItem(this.Position, this.Velocity, this.Texture);
            ballItemDeepCopy.SetOrigin();
            ballItemDeepCopy.SetLeftUpCorner();
            ballItemDeepCopy.SetRightUpCorner();
            ballItemDeepCopy.SetLeftBottomCorner();
            ballItemDeepCopy.SetRightBottomCorner();
            return ballItemDeepCopy;
        }

        public IPrototype ShallowCopy()
        {
            BallItem ballItemShallowCopy = this;
            return ballItemShallowCopy;
        }
    }
}
