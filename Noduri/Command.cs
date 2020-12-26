using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noduri
{
    abstract class Command
    {
        private string commandName;

        public string CommandName
        {
            get { return commandName; }
        }

        public Command(string commandName)
        {
            this.commandName = commandName;
        }

        public abstract string Process(string[] arguments);        
    }
}
