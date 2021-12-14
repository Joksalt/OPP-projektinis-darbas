using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Proxy
{
    public class RealSound : ISound
    {
        protected string ID;

        public RealSound() { }

        public void RequestSound(string s)
        {
            throw new NotImplementedException();
        }
    }
}
