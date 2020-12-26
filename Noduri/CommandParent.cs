using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noduri
{
    class CommandParent : Command
    {
        public CommandParent(string commandName) : base(commandName) { }

        public override string Process(string[] arguments)
        {
            string output = "";

            if (arguments.Length == 3)
            {
                TransformNode childNode = TransformNode.Find(arguments[1]) as TransformNode;
                TransformNode parentNode = TransformNode.Find(arguments[2]) as TransformNode;

                if (childNode != null && parentNode != null)
                {
                    if (childNode.FindNode(parentNode.Name) == null)
                        childNode.SetParent(parentNode);
                    else
                        output = "Cannot parent a node to one of its children";
                }
                else
                    output = "Parenting failed - could not find parent or child node";
            }
            else
                output = "You must specify two nodes";

            return output;
        }
    }
}
