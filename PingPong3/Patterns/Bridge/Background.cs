using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Bridge
{
    public abstract class Background
    {
        public string theme;

        public abstract string setBackgroundTheme();        
    }
}
