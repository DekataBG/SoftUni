using Logger.Appenders;
using Logger.ErrorLevels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }

        public IAppender[] Appenders { get; }

        public void Info(string date, string message)
        {
            DisplayMessage(date, message, nameof(Info));
        }

        public void Warning(string date, string message)
        {
            DisplayMessage(date, message, nameof(Warning));
        }

        public void Error(string date, string message)
        {
            DisplayMessage(date, message, nameof(Error));
        }

        public void Critical(string date, string message)
        {
            DisplayMessage(date, message, nameof(Critical));
        }

        public void Fatal(string date, string message)
        {
            DisplayMessage(date, message, nameof(Fatal));
        }

        private void DisplayMessage(string date, string message, string method)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(new string[] { date, method.ToUpper(), message });
            }
        }
    }
}
