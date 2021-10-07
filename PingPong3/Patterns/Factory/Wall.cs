using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Factory
{
    public abstract class Wall
    {
        private string name;
        public string GetName()
        {
            return name;
        }
        public void SetName(string NewName)
        {
            this.name = NewName;
        }
    }
}
