using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.CommandPattern.Core.Engines
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(commandInterpreter.Read(Console.ReadLine()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }         
            }
        }
    }
}
