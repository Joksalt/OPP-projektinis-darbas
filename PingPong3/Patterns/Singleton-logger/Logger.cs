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

        public static Logger LoggerInstance { get { return NestedLogger.instance; } }

        private class NestedLogger
        {
            static NestedLogger()
            {
            }

            internal static readonly Logger instance = new Logger();
        }

        public void Write(string sender, string message)
        {
            StartForm._StartForm.messagesLog.AppendText($"{sender}:{message}\n");
        }
    }
}
