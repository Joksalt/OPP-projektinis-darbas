using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Adapter
{
    public abstract class Sound
    {
        protected string soundID;
        public Sound()
        {

        }
        public abstract void RequestSound();
    }
}
