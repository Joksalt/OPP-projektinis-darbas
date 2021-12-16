using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class Lexer
    {
        public String text;
        public int pos;
        public char current_char;

        public Lexer(String text)
        {
            this.text = text;
            pos = -1;
            current_char = '\0';
            advance();
        }

        public void advance()
        {
            pos++;
            if(pos < text.Length)
            {
                current_char = text[pos];
            }
            else
            {
                current_char = '\0';
            }
        }

        public LexResult make_tokens()
        {
            List<Token> tokens = new List<Token>();
            while(current_char != '\0')
            {
                if (current_char == '\t' || current_char == ' ' || current_char == '\n')
                { 
                    advance(); 
                }
                else if (Token.DIGITS.Contains(current_char))
                {
                    tokens.Add(make_number());
                }
                else if(Token.LETTERS.Contains(current_char))
                {
                    tokens.Add(make_identifier());
                }
                else if (current_char == '+')
                {
                    tokens.Add(new Token(Token.TT_PLUS));
                    advance();
                }
                else if (current_char == '-')
                {
                    tokens.Add(new Token(Token.TT_MINUS));
                    advance();
                }
                else if (current_char == '*')
                {
                    tokens.Add(new Token(Token.TT_MUL));
                    advance();
                }
                else if (current_char == '/')
                {
                    tokens.Add(new Token(Token.TT_DIV));
                    advance();
                }
                else if (current_char == '(')
                {
                    tokens.Add(new Token(Token.TT_LPAREN));
                    advance();
                }
                else if (current_char == ')')
                {
                    tokens.Add(new Token(Token.TT_RPAREN));
                    advance();
                }
                else if (current_char == '=')
                {
                    tokens.Add(new Token(Token.TT_EQ));
                    advance();
                }
                else
                {
                    char c = current_char;
                    advance();
                    return new LexResult(null, new Error("Illegal character: ", "'" + c + "'"));
                }
            }
            tokens.Add(new Token(Token.TT_EOF));
            return new LexResult(tokens, null);
        }

        public Token make_number()
        {
            String num_str = "";
            int dot_count = 0;
            while(current_char != '\0' && (Token.DIGITS + '.').Contains(current_char))
            {
                if (current_char == '.')
                {
                    if (dot_count == 1)
                        break;
                    dot_count++;
                    num_str += '.';
                }
                else
                    num_str += current_char;
                advance();   
            }
            if (dot_count == 0)
                return new Token(Token.TT_INT, int.Parse(num_str));
            else
                return new Token(Token.TT_FLOAT, float.Parse(num_str));
        }
        public Token make_identifier()
        {
            String str = "";
            while (current_char != '\0' && (Token.LETTERS + Token.DIGITS).Contains(current_char))
            {
                str += current_char;
                advance();
            }
            if(Token.PLAYERS.Contains(str))
            {
                if(str.Contains("1"))
                    return new Token(Token.TT_PLAYER, 1);
                else
                    return new Token(Token.TT_PLAYER, 2);
            }
            else
            {
                return new Token(Token.TT_IDENTIFIER, str);
            }
        }
    }
}
