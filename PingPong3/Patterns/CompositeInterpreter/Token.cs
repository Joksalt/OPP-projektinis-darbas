
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class Token
    {

        public static String DIGITS = "0123456789";
        public static String TT_INT = "INT";
        public static String TT_FLOAT = "FLOAT";
        public static String TT_DOUBLE = "DOUBLE";
        public static String TT_PLUS = "PLUS";
        public static String TT_MINUS = "MINUS";
        public static String TT_MUL = "MUL";
        public static String TT_DIV = "DIV";
        public static String TT_LPAREN = "LPAREN";
        public static String TT_RPAREN = "RPAREN";
        public static String TT_EOF = "EOF";
        public static String TT_SCORE = "SCORE_KEY";
        public static String TT_SPEED = "SPEED_KEY";
        public static String TT_SIZE = "SIZE_KEY";
        public static String TT_PLAYER = "SIZE_KEY";

        public String type;
        public object value;
        public Token(String type)
        {
            this.type = type;
            this.value = type;
        }
        public Token(String type, object value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
