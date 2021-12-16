using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class Interpreter
    {
        AbstractExpression interpreter;
        public Interpreter(HubConnection connection)
        {
            interpreter = new CheckNodeInterpreter(connection);
        }

        public InterpretResult interpret(Node node)
        {
            return interpreter.interpret(node);
        }
        public abstract class AbstractExpression
        {
            public abstract InterpretResult interpret(Node context);
        }
        public class CheckNodeInterpreter : AbstractExpression
        {
            AbstractExpression numberInterpreter;
            AbstractExpression binOpInterpreter;
            AbstractExpression unOpInterpreter;
            AbstractExpression commandNodeInterpreter;
            public CheckNodeInterpreter(HubConnection connection)
            {
                numberInterpreter = new NumberNodeInterpreter();
                binOpInterpreter = new BinOpNodeInterpreter(this);
                unOpInterpreter = new UnOpNodeInterpreter(this);
                commandNodeInterpreter = new CommandNodeInterpreter(this, connection);
            }
            public override InterpretResult interpret(Node context)
            {
                if (context is NumberNode)
                {
                    return numberInterpreter.interpret(context);
                }
                else if (context is BinOpNode)
                {
                    return binOpInterpreter.interpret(context);
                }
                else if (context is UnOpNode)
                {
                    return unOpInterpreter.interpret(context);
                }
                else if (context is CommandNode)
                {
                    return commandNodeInterpreter.interpret(context);
                }
                else
                {
                    throw new Exception("Unknown node");
                }
            }
        }
        public class NumberNodeInterpreter : AbstractExpression
        {
            public override InterpretResult interpret(Node context)
            {
                NumberNode node = (context as NumberNode);
                return new InterpretResult().success(new Number(Convert.ToSingle(node.token.value)));
            }
        }
        public class BinOpNodeInterpreter : AbstractExpression
        {
            CheckNodeInterpreter interpreter;
            public BinOpNodeInterpreter(CheckNodeInterpreter interpreter)
            {
                this.interpreter = interpreter;
            }
            public override InterpretResult interpret(Node context)
            {
                BinOpNode node = (context as BinOpNode);
                InterpretResult res = new InterpretResult();
                Number left = res.register(interpreter.interpret(node.left_node));
                if (res.error != null)
                    return res;
                Number right = res.register(interpreter.interpret(node.right_node));
                InterpretResult result = new InterpretResult();
                if (res.error != null)
                    return res;
                if (node.token.type == Token.TT_PLUS)
                    result = left.added_to(right);
                else if (node.token.type == Token.TT_MINUS)
                    result = left.subbed_by(right);
                else if (node.token.type == Token.TT_MUL)
                    result = left.multed_by(right);
                else if (node.token.type == Token.TT_DIV)
                    result = left.dived_by(right);
                if (result.error != null)
                    return res.failure(result.error);
                else
                    return res.success(result.value);
            }
        }
        public class UnOpNodeInterpreter : AbstractExpression
        {
            CheckNodeInterpreter interpreter;
            public UnOpNodeInterpreter(CheckNodeInterpreter interpreter)
            {
                this.interpreter = interpreter;
            }
            public override InterpretResult interpret(Node context)
            {
                UnOpNode node = (context as UnOpNode);
                InterpretResult res = new InterpretResult();
                Number n = res.register(interpreter.interpret(node.node));
                InterpretResult result = new InterpretResult();
                if (res.error != null)
                    return res;
                if (node.token.type == Token.TT_MINUS)
                    result = n.multed_by(new Number(-1));
                if (result.error != null)
                    return res.failure(result.error);
                else
                    return res.success(result.value);
            }
        }
        public class CommandNodeInterpreter : AbstractExpression
        {
            HubConnection connection;
            CheckNodeInterpreter interpreter;
            public CommandNodeInterpreter(CheckNodeInterpreter interpreter, HubConnection connection)
            {
                this.interpreter = interpreter;
                this.connection = connection;
            }
            public override InterpretResult interpret(Node context)
            {
                CommandNode node = (context as CommandNode);
                InterpretResult res = new InterpretResult();
                Number n = res.register(interpreter.interpret(node.node));
                if (res.error != null)
                    return res;
                if (Convert.ToSingle(node.player.value) == 1)
                {
                    if (Token.SPEED.Contains(node.identifier.value))
                        SendPlayerSpeed((int)n.value, 0);
                    else if (Token.SIZE.Contains(node.identifier.value))
                        SendPlayerSize((int)n.value, 0);
                    else if (Token.SCORE.Contains(node.identifier.value))
                        SendPlayerScore((int)n.value, 0);
                    else
                        res.failure(new Error("Runtime error: ", "Idk, player 1 was found tho"));
                }
                else
                {
                    if (Token.SPEED.Contains(node.identifier.value))
                        SendPlayerSpeed((int)n.value, 1);
                    else if (Token.SIZE.Contains(node.identifier.value))
                        SendPlayerSize((int)n.value, 1);
                    else if (Token.SCORE.Contains(node.identifier.value))
                        SendPlayerScore((int)n.value, 1);
                    else
                        res.failure(new Error("Runtime error: ", "Idk, player 2 was found tho"));
                }
                return res.success(n);
            }
            private async void SendPlayerScore(int score, int player)
            {
                try
                {
                    await connection.InvokeAsync("SendScoreSignal", score, player);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            private async void SendPlayerSize(int size, int player)
            {
                try
                {
                    await connection.InvokeAsync("SendPlayerSize", size, player);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            private async void SendPlayerSpeed(int speed, int player)
            {
                try
                {
                    await connection.InvokeAsync("SendPlayerSpeed", speed, player);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
