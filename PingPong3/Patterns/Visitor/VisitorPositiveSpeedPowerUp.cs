using PingPong3.Patterns.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Visitor
{
    public class VisitorPositiveSpeedPowerUp : IVisitorPowerUp
    {
        public void ChangeRepresentation(BackgroundRepresentationElement backgroundRepresentation)
        {
            backgroundRepresentation.RepresentationBackground = new DynamicBackground();
        }
    }
}
