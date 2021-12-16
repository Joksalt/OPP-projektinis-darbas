using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class Parser
    {
        List<Token> tokens;
        int token_index;
        Token current_token;
        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            token_index = -1;
            advance();
        }
        public ParseResult parse()
        {
            ParseResult res = command();
            if(res.error == null && current_token.type != Token.TT_EOF)
            {
                return res.failure(new Error("Invalid syntax error: ", "Expected '+', '-', '*' or '/'"));
            }
            return res;
        }
        public Token advance()
        {
            token_index++;
            if(token_index < tokens.Count)
            {
                current_token = tokens[token_index];
            }
            return current_token;
        }
        public ParseResult factor()
        {
            ParseResult parseResult = new ParseResult();
            Token tok = current_token;
            if(tok.type == Token.TT_PLUS || tok.type == Token.TT_MINUS)
            {
                advance();
                Node f = parseResult.register(factor());
                if (parseResult.error != null)
                    return parseResult;
                return parseResult.success(new UnOpNode(tok, f));
            }
            else if(tok.type == Token.TT_FLOAT || tok.type == Token.TT_INT)
            {
                advance();
                return parseResult.success(new NumberNode(tok));
            }
            else if (tok.type == Token.TT_LPAREN)
            {
                advance();
                Node e = parseResult.register(expression());
                if (parseResult.error != null)
                    return parseResult;
                if(current_token.type == Token.TT_RPAREN)
                {
                    advance();
                    return parseResult.success(e);
                }
                else
                {
                    return parseResult.failure(new Error("Invalid syntax error: ", "Expected ')'"));
                }
            }
            return parseResult.failure(new Error("Invalid syntax error: ", "Expected int or float"));
        }
        public ParseResult term()
        {
            ParseResult parseResult = new ParseResult();
            Node left = parseResult.register(factor());
            if(parseResult.error != null)
                return parseResult;
            while(current_token.type == Token.TT_DIV || current_token.type == Token.TT_MUL)
            {
                Token op_tok = current_token;
                advance();
                Node right = parseResult.register(factor());
                if (parseResult.error != null)
                    return parseResult;
                left = new BinOpNode(left, op_tok, right);
            }
            return parseResult.success(left);
        }
        public ParseResult expression()
        {
            ParseResult parseResult = new ParseResult();
            Node left = parseResult.register(term());
            if (parseResult.error != null)
                return parseResult;
            while (current_token.type == Token.TT_PLUS || current_token.type == Token.TT_MINUS)
            {
                Token op_tok = current_token;
                advance();
                Node right = parseResult.register(term());
                if (parseResult.error != null)
                    return parseResult;
                left = new BinOpNode(left, op_tok, right);
            }
            return parseResult.success(left);
        }
        public ParseResult command()
        {
            ParseResult parseResult = new ParseResult();
            if (current_token.type == Token.TT_PLAYER)
            {
                Token player = current_token;
                advance();
                if (current_token.type != Token.TT_IDENTIFIER || !Token.IDENTIFIERS.Contains(current_token.value))
                    return parseResult.failure(new Error("Invalid syntax error: ", "Expected an identifier"));
                Token identifier = current_token;
                advance();
                if(current_token.type != Token.TT_EQ)
                    return parseResult.failure(new Error("Invalid syntax error: ", "Expected '='"));
                advance();
                Node expr = parseResult.register(expression());
                if (parseResult.error != null)
                    return parseResult;
                return parseResult.success(new CommandNode(player, identifier, expr));
            }
            else
            {
                Node expr = parseResult.register(expression());
                if (parseResult.error != null)
                    return parseResult;
                return parseResult.success(expr);
            }
        }
    }
}
