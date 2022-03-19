using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Loggers;

namespace Logger.Managers
{
    public static class ErrorLevelsManager
    {
        public static void LogErrors(Loggers.Logger logger, string error, string date, string message)
        {
            switch (error)
            {
                case "INFO":
                    logger.Info(date, message);
                    break;
                case "WARNING":
                    logger.Warning(date, message);
                    break;
                case "ERROR":
                    logger.Error(date, message);
                    break;
                case "CRITICAL":
                    logger.Critical(date, message);
                    break;
                case "FATAL":
                    logger.Fatal(date, message);
                    break;
            }
        }
    }
}
