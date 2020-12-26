using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noduri
{
    class CommandExit : Command
    {
        public CommandExit(string commandName) : base(commandName) { }

        public override string Process(string[] arguments)
        {
            string output = "Bye";
            CommandManager.Done = true;
            return output;
        }
    }
}
