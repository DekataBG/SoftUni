using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.ErrorLevels
{
    public static class ErrorFilter
    {
        public static bool FiltrateError(string givenLevel, string givenErrorThreshold)
        {
            int errorValue = CalculateErrorValue(givenLevel);
            int errorThresholdValue = CalculateErrorThresholdValue(givenErrorThreshold);

            return errorValue >= errorThresholdValue;
        }

        private static int CalculateErrorThresholdValue(string givenErrorThreshold)
        {
            string info = ErrorLevel.Info.ToString().ToLower();
            string warning = ErrorLevel.Warning.ToString().ToLower();
            string errorr = ErrorLevel.Error.ToString().ToLower();
            string critical = ErrorLevel.Critical.ToString().ToLower();
            string fatal = ErrorLevel.Fatal.ToString().ToLower();


            string errorThreshold = givenErrorThreshold.ToLower();
            int errorThresholdValue = 0;

            if (errorThreshold == info)
            {
                errorThresholdValue = (int)ErrorLevel.Info;
            }
            else if (errorThreshold == warning)
            {
                errorThresholdValue = (int)ErrorLevel.Warning;
            }
            else if (errorThreshold == errorr)
            {
                errorThresholdValue = (int)ErrorLevel.Error;
            }
            else if (errorThreshold == critical)
            {
                errorThresholdValue = (int)ErrorLevel.Critical;
            }
            else if (errorThreshold == fatal)
            {
                errorThresholdValue = (int)ErrorLevel.Fatal;
            }

            return errorThresholdValue;
        }

        private static int CalculateErrorValue(string givenLevel)
        {
            string level = givenLevel.ToLower();

            int errorValue = 0;

            string info = ErrorLevel.Info.ToString().ToLower();
            string warning = ErrorLevel.Warning.ToString().ToLower();
            string errorr = ErrorLevel.Error.ToString().ToLower();
            string critical = ErrorLevel.Critical.ToString().ToLower();
            string fatal = ErrorLevel.Fatal.ToString().ToLower();

            if (level == info)
            {
                errorValue = (int)ErrorLevel.Info;
            }
            else if (level == warning)
            {
                errorValue = (int)ErrorLevel.Warning;
            }
            else if (level == errorr)
            {
                errorValue = (int)ErrorLevel.Error;
            }
            else if (level == critical)
            {
                errorValue = (int)ErrorLevel.Critical;
            }
            else if (level == fatal)
            {
                errorValue = (int)ErrorLevel.Fatal;
            }

            return errorValue;
        }
    }
}
