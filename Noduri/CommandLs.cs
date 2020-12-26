using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noduri
{
    class CommandLs : Command
    {
        public CommandLs(string commandName) : base(commandName) { }

        public override string Process(string[] arguments)
        {
            string output = "";

            Console.WriteLine();

            if (arguments.Length == 2)
            {
                TransformNode node = TransformNode.Find(arguments[1]) as TransformNode;
                if (node != null)
                    node.ShowTree();
                else
                    output = "Invalid node specified: " + arguments[1];
            }
            else
                TransformNode.ShowAll();

            return output;
        }
    }
}
