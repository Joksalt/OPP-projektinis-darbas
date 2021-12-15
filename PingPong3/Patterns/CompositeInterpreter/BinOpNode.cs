using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class BinOpNode : Node
    {
        public Token token;
        public Node left_node, right_node;
        public BinOpNode()
        {

        }
        public BinOpNode(Node left_node, Token token, Node right_node)
        {
            this.left_node = left_node;
            this.token = token;
            this.right_node = right_node;
        }
        public override Node add(Node node)
        {
            if(left_node == null)
            {
                left_node = node;
                return null;
            }
            else if(right_node == null)
            {
                right_node = node;
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
                return left_node;
            else if (i == 1)
                return right_node;
            else
                return null;
        }
        public override Node remove(Node node)
        {
            if (node.Equals(left_node))
            {
                left_node = null;
                return node;
            }
            else if (node.Equals(right_node))
            {
                right_node = null;
                return node;
            }
            else
                return null;
        }
    }
}
