using Logger.ErrorLevels;
using Logger.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        private readonly string path = @"..\..\..\log.txt";

        public FileAppender(ILayout layout,
            ErrorLevel errorThreshold) : base(layout, errorThreshold)
        {
        }

        public override void ProcessResult()
        {
            File.AppendAllText(path, LogFile.Message.ToString());
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {LogFile.Size}";
        }
    }
}
