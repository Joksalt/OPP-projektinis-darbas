using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class ParseResult
    {
        public Node node;
        public Error error;
        public ParseResult()
        {

        }
        public ParseResult(Node node, Error error)
        {
            this.node = node;
            this.error = error;
        }
        public Node register(ParseResult parseResult)
        {
            if(parseResult.error != null)
            {
                this.error = parseResult.error;
            }
            return parseResult.node;
        }
        public ParseResult success(Node node)
        {
            this.node = node;
            return this;
        }
        public ParseResult failure(Error error)
        {
            this.error = error;
            return this;
        }
    }
}
