using CommandPattern.Core.Contracts;
using P01.CommandPattern.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P01.CommandPattern.Core.CommandInterpreters
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var input = args.Split();
            var commandName = input[0] + "Command";
            var arguments = input.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(c => c.Name == commandName);

            if (type == null)
            {
                throw new ArgumentException("Invalid command");
            }

            var command = Activator.CreateInstance(type) as ICommand;

            if(command == null)
            {
                throw new ArgumentException("Not an executable command");
            }

            return command.Execute(arguments);
        }
    }
}
