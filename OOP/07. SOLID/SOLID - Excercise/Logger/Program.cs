namespace Logger
{

    using Appenders;
    using Loggers;
    using Managers;

    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split(' ');

                appenders[i] = AppendersManager.CreateAppender(data);

            }

            var command = Console.ReadLine().Split('|');
            while (command[0] != "END")
            {
                ErrorLevelsManager.LogErrors(new Logger(appenders),
                    command[0], command[1], command[2]);

                command = Console.ReadLine().Split('|');
            }

            foreach (var appender in appenders)
            {
                appender.ProcessResult();
            }

            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }
    }
}