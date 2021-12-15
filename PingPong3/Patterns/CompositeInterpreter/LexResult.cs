using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class LexResult
    {
        public List<Token> tokens;
        public Error error;
        public LexResult(List<Token> tokens, Error error)
        {
            this.tokens = tokens;
            this.error = error;
        }
    }
}
