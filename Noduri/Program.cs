using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noduri
{
    class Program
    {
        static void Main(string[] args)
        {
            TransformNode sphereNode = new GeometryNode("sphere").TransformNode;
            TransformNode lightNode = new LightNode("spotLight").TransformNode;

            TransformNode.Group(lightNode, sphereNode);
            TransformNode.ShowAll();

            while (!CommandManager.Done)
            {
                Console.Write(":");
                CommandManager.ProcessCommand(Console.ReadLine());
            }
        }
    }
}
