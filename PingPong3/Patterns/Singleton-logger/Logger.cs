using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Singleton_logger
{

    public sealed class Logger
    {
        private Logger()
        {
            //var rand = new Random();
            //id = rand.Next();
        }

        public int id;

        public static Logger LoggerInstance { get { return Nested.instance; } }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly Logger instance = new Logger();
        }

        public void Write(String message)
        {
            StartForm._StartForm.messagesLog.AppendText($"{message}\n");
        }
    }
}
