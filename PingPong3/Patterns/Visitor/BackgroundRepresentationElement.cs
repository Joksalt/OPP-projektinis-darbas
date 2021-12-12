using PingPong3.Patterns.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Visitor
{
    public class BackgroundRepresentationElement : IFormRepresentationElement
    {
        public Background RepresentationBackground { get; set; }

        public BackgroundRepresentationElement()
        {
            RepresentationBackground = null;
        }
        public void AcceptRepresentationVisitor(IVisitorPowerUp powerUp)
        {
            powerUp.ChangeRepresentation(this);
        }

        public Background ReturnBackground()
        {
            return RepresentationBackground;
        }
    }
}
