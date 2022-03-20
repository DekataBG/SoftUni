using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.CommandPattern.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            System.Environment.Exit(0);

            return null;
        }
    }
}
