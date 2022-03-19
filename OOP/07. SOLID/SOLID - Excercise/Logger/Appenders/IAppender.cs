using Logger.Layouts;
using Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ErrorLevel ErrorThreshold { get; set; }

        LogFile LogFile { get; set; }

        void Append(string[] data);

        void ProcessResult();
    }
}
