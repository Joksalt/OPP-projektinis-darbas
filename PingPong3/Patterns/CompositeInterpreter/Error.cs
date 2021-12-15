using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class Error
    {
        String name;
        String details;
        public Error(String name, String details)
        {
            this.name = name;
            this.details = details;
        }
        public override string ToString()
        {
            return name + details;
        }
    }
}
