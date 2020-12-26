using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noduri
{
    class CommandGroup : Command
    {
        public CommandGroup(string commandName) : base(commandName) { }

        public override string Process(string[] arguments)
        {
            string output = "";

            if (arguments.Length == 3)
            {
                TransformNode node1 = TransformNode.Find(arguments[1]) as TransformNode;
                TransformNode node2 = TransformNode.Find(arguments[2]) as TransformNode;

                if (node1 != null && node2 != null)
                    TransformNode.Group(node1, node2);
                else
                    output = "One or both nodes are invalid";
            }
            else if (arguments.Length == 2)
            {
                TransformNode node1 = TransformNode.Find(arguments[1]) as TransformNode;                

                if (node1 != null)
                    TransformNode.Group(node1);
                else
                    output = "Invalid node";
            }
            else
                output = "You must specify one or two nodes in order to group";

            return output;
        }
    }
}
