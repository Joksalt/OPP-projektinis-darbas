using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class CommandNode : Node
    {
        public Token player;
        public Token identifier;
        public Node node;
        public CommandNode(Token player, Token identifier, Node node)
        {
            this.player = player;
            this.identifier = identifier;
            this.node = node;
        }
    }
}
