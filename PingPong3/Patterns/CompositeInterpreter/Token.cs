
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
        public static String LETTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_";
        public static String[] PLAYERS = { "player1", "player2", "p1", "p2", "pl1", "pl2" };
        public static String[] IDENTIFIERS = { "speed", "Speed", "SPEED", "SPD", "spd",
                                                "size", "Size", "SIZE", "sz", "SZ",
                                                "score", "Score", "SCORE", "scr", "SCR"};
        public static String[] SPEED = { "speed", "Speed", "SPEED", "SPD", "spd" };
        public static String[] SIZE = { "size", "Size", "SIZE", "sz", "SZ" };
        public static String[] SCORE = { "score", "Score", "SCORE", "scr", "SCR" };

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
        public static String TT_EQ = "EQ";
        public static String TT_PLAYER = "PLAYER";
        public static String TT_IDENTIFIER = "IDENTIFIER";

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
