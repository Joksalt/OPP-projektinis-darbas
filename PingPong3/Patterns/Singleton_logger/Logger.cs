using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Singleton_logger
{

    public sealed class LoggerSingleton
    {
        private LoggerSingleton()
        {
            //var rand = new Random();
            //id = rand.Next();
        }

        public int id;

        public static LoggerSingleton LoggerInstance { get { return NestedLogger.instance; } }

        private class NestedLogger
        {
            static NestedLogger()
            {
            }

            internal static readonly LoggerSingleton instance = new LoggerSingleton();
        }

        public void Write(string sender, string message)
        {
            //StartForm._StartForm.messagesLog.AppendText($"{sender}:{message}\n"); //comment this to debug
        }
    }
}