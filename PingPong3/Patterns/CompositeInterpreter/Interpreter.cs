using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class Interpreter
    {
        public Interpreter()
        {

        }
        public InterpretResult visit(Node node)
        {
            if(node is NumberNode)
            {
                return visitNumberNode(node as NumberNode);
            }
            else if (node is BinOpNode)
            {
                return visitBinOpNode(node as BinOpNode);
            }
            else if (node is UnOpNode)
            {
                return visitUnOpNode(node as UnOpNode);
            }
            else
            {
                return visitUnknownNode(node);
            }
        }
        public InterpretResult visitNumberNode(NumberNode node)
        {
            return new InterpretResult().success(new Number(Convert.ToSingle(node.token.value)));
        }
        public InterpretResult visitBinOpNode(BinOpNode node)
        {
            InterpretResult res = new InterpretResult();
            Number left = res.register(visit(node.left_node));
            if (res.error != null)
                return res;
            Number right = res.register(visit(node.right_node));
            InterpretResult result = new InterpretResult();
            if (res.error != null)
                return res;
            if (node.token.type == Token.TT_PLUS)
            {
                result = left.added_to(right);
            }
            else if (node.token.type == Token.TT_MINUS)
            {
                result = left.subbed_by(right);
            }
            else if (node.token.type == Token.TT_MUL)
            {
                result = left.multed_by(right);
            }
            else if (node.token.type == Token.TT_DIV)
            {
                result = left.dived_by(right);
            }
            if (result.error != null)
                return res.failure(result.error);
            else
                return res.success(result.value);
        }
        public InterpretResult visitUnOpNode(UnOpNode node)
        {
            InterpretResult res = new InterpretResult();
            Number n = res.register(visit(node.node));
            InterpretResult result = new InterpretResult();
            if (res.error != null)
                return res;
            if (node.token.type == Token.TT_MINUS)
            {
                result = n.multed_by(new Number(-1));
            }
            if (result.error != null)
                return res.failure(result.error);
            else
                return res.success(result.value);
        }
        public InterpretResult visitUnknownNode(Node node)
        {
            return null;
        }
    }
}
