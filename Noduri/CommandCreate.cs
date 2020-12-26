using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noduri
{
    class CommandCreate : Command
    {
        public CommandCreate(string commandName) : base(commandName) { }

        public override string Process(string[] arguments)
        {
            string output = "";
            string nodeName;

            if (arguments.Length > 1)
                nodeName = arguments[1];
            else
                nodeName = arguments[0];

            switch (arguments[0])
            {
                case "sphere":
                    output = new GeometryNode(nodeName).TransformNode.Name;
                    break;
                case "box":
                    output = new GeometryNode(nodeName).TransformNode.Name;
                    break;
                case "light":
                    output = new LightNode(nodeName).TransformNode.Name;
                    break;
            }

            return "Result: " + output;
        }
    }
}
