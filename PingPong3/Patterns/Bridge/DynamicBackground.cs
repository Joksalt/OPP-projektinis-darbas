using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Bridge
{
    public class DynamicBackground : Background
    {
        public override string setBackgroundTheme()
        {
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("bin\\Debug"));
            path = path + "Images\\";
            path = path + "matrix.gif";
            return path;
        }
    }
}
