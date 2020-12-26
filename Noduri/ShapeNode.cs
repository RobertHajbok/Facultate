using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noduri
{
    class ShapeNode : Node
    {
        private static List<ShapeNode> shapes;

        private TransformNode transformNode;

        public TransformNode TransformNode
        {
            get { return this.transformNode; }
        }

        static ShapeNode()
        {
            shapes = new List<ShapeNode>();
        }

        public ShapeNode(string name)
        {
            this.transformNode = new TransformNode(name);
            this.transformNode.SetShape(this);
            this.name = this.transformNode.ToString() + "Shape";
            shapes.Add(this);
        }

        public static void ShowAll()
        {
            foreach (ShapeNode shape in shapes)
                Console.WriteLine(shape + " [" + shape.transformNode + "]");
        }

        public static void RemoveNode(ShapeNode node)
        {
            shapes.Remove(node);
        }
    }
}
