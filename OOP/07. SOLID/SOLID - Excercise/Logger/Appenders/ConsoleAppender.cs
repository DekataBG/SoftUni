using Logger.ErrorLevels;
using Logger.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, 
            ErrorLevel errorThreshold) : base(layout, errorThreshold)
        {
        }

        public override void ProcessResult()
        {
            Console.WriteLine(LogFile.Message);
        }
    }
}
