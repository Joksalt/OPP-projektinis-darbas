using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Visitor
{
    public interface IVisitorPowerUp
    {
        void ChangeRepresentation(BackgroundRepresentationElement backgroundRepresentation);
    }
}
