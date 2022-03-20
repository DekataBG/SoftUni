using Logger.ErrorLevels;
using Logger.Layouts;
using Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout, ErrorLevel errorThreshold)
        {
            Layout = layout;
            ErrorThreshold = errorThreshold;
            LogFile = new LogFile();
        }

        public ILayout Layout { get; }

        public ErrorLevel ErrorThreshold { get; set; }

        public LogFile LogFile { get; set; }

        public virtual void Append(string[] data)
        {
            if (ErrorFilter.FiltrateError(data[1], ErrorThreshold.ToString()))
            {
                LogFile.AddMessage(string.Format(Layout.Format, data));
            }
        }

        public abstract void ProcessResult();

        public override string ToString()
        {
            return  $"Appender type: {GetType().Name}" +
                    $", Layout type: {Layout.GetType().Name}" +
                    $", Report level: {ErrorThreshold.ToString().ToUpper()}" +
                    $", Messages appended: {LogFile.Messages}";
        }
    }
}
