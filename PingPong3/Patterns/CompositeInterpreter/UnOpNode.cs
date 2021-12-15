using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class UnOpNode : Node
    {
        public Token token;
        public Node node;
        public UnOpNode(Token token, Node node)
        {
            this.token = token;
            this.node = node;
        }
        public override Node add(Node node)
        {
            if (node == null)
            {
                this.node = node;
                return null;
            }
            else
            {
                return node;
            }
        }
        public override Node get(int i)
        {
            if (i == 0)
                return node;
            else
                return null;
        }
        public override Node remove(Node node)
        {
            if (node.Equals(this.node))
            {
                this.node = null;
                return node;
            }
            else
                return null;
        }
    }
}
