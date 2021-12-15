using PingPong3.Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong3.Patterns.Factory
{
    public class StaticWall : Wall
    {
        public StaticWall(int i, IMediator medi) : base(medi)
        {
            Position = new Point(500, 500);
            Texture = new PictureBox
            {
                Name = "pbWall" + i.ToString(),
                Size = new Size(100, 10),
                BackColor = Color.White
            };
        }

        public override ColleagueType GetColleagueType()
        {
            return ColleagueType.racket;
        }

        public override void ReceiveMessage(string msg)
        {
            throw new NotImplementedException();
        }

        public override void SendMessage(string msg)
        {
            throw new NotImplementedException();
        }

        public override Wall SetData(Point position, Size size, Color color)
        {
            Position = position;
            Texture.Size = size;
            Texture.BackColor = color;
            return this;
        }
    }
}
