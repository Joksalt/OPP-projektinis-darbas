using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class NumberNode : Node
    {
        public Token token;
        public NumberNode(Token token)
        {
            this.token = token;
        }
    }
}
