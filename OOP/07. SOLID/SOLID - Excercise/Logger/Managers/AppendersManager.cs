using Logger.Appenders;
using Logger.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Managers
{
    public static class AppendersManager
    {
        public static IAppender CreateAppender(string[] data)
        {
            string type = data[0];
            string layout = data[1];
            string error = data.Length == 3 ? data[2] : "INFO";

            Type newType;
            ILayout newLayout;
            ErrorLevel newError;

            switch (type)
            {
                case "ConsoleAppender":
                    newType = typeof(ConsoleAppender);
                    break;
                case "FileAppender":
                    newType = typeof(FileAppender);
                    break;
                default:
                    newType = typeof(Appender);
                    break;
            }

            switch (layout)
            {
                case "SimpleLayout":
                    newLayout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    newLayout = new XmlLayout();
                    break;
                default:
                    newLayout = null;
                    break;
            }

            switch (error)
            {
                case "INFO":
                    newError = ErrorLevel.Info;
                    break;
                case "WARNING":
                    newError = ErrorLevel.Warning;
                    break;
                case "ERROR":
                    newError = ErrorLevel.Error;
                    break;
                case "CRITICAL":
                    newError = ErrorLevel.Critical;
                    break;
                case "FATAL":
                    newError = ErrorLevel.Fatal;
                    break;
                default:
                    newError = ErrorLevel.Default;
                    break;
            }

            return Activator.CreateInstance(newType, newLayout, newError) as IAppender;
        }
    }
}
