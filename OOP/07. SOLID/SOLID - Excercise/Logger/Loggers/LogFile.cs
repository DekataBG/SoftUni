using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Loggers
{
    public class LogFile
    {
        public StringBuilder Message { get; set; } = new StringBuilder();
        public int Messages { get; set; } = 0;
        public int Size => Message.ToString().Sum(ch => (int)ch);

        public void AddMessage(string message)
        {
            Message.AppendLine(message);
            Messages++;
        }
    }
}
