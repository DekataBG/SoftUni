using CommandPattern.Core.Contracts;
using P01.CommandPattern.Core.CommandInterpreters;
using P01.CommandPattern.Core.Engines;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
