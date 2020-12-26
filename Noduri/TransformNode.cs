using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noduri
{
    class TransformNode : Node
    {
        private TransformNode parent;
        private ShapeNode shape;
        private static List<TransformNode> rootNodes;
        private List<TransformNode> children;

        static TransformNode()
        {
            rootNodes = new List<TransformNode>();
        }

        public TransformNode() : this("Transform") { }  

        public TransformNode(string name)
        {
            string validatedName = name;
            int counter = 2;
            while (TransformNode.Find(validatedName) != null)
            {
                validatedName = name + counter.ToString();
                counter++;
            }

            children = new List<TransformNode>();
            this.name = validatedName;
            rootNodes.Add(this);
        }

        public void SetParent(TransformNode parent)
        {
            // Remove from old containing list
            if (this.parent == null)            
                rootNodes.Remove(this);            
            else            
                this.parent.children.Remove(this);            

            // Assign new parent
            this.parent = parent;

            if (parent == null)            
                rootNodes.Add(this);            
            else            
                parent.children.Add(this);            
        }

        public void SetShape(ShapeNode shape)
        {
            this.shape = shape;
        }

        public static Node Find(string name)
        {
            foreach (TransformNode node in rootNodes)
            {
                Node result = node.FindNode(name);
                if (result != null)
                    return result;
            }
            return null;
        }

        public Node FindNode(string name)
        {
            Node result = null;
            FindNode(name, ref result);
            return result;
        }

        public void FindNode(string name, ref Node result)
        {
            if (this.name == name)
                result = this;
            else if (this.shape != null && this.shape.Name == name)
                result = this.shape;
            else
                foreach (TransformNode child in children)
                    child.FindNode(name, ref result);
        }


        public static void ShowAll()
        {
            foreach (TransformNode node in rootNodes)
                node.ShowTree(0);
        }

        public void ShowTree()
        {
            ShowTree(0);
        }

        private void ShowTree(int depth)
        {
            string padding = "";
            padding = padding.PadLeft(depth * 2, '-');
            Console.WriteLine(padding + this + " [" + this.shape + "]");

            foreach (TransformNode child in children)            
                child.ShowTree(depth + 1);
            
        }

        public void RemoveNode()
        {
            this.RemoveShape();
            if (this.parent != null)
                parent.children.Remove(this);
            else
                rootNodes.Remove(this);
        }

        private void RemoveShape()
        {
            ShapeNode.RemoveNode(this.shape);
            foreach (TransformNode child in children)
                child.RemoveShape();
        }

        public static void Group(TransformNode node1, TransformNode node2)
        {
            TransformNode groupNode = new TransformNode("Group");
            node1.SetParent(groupNode);
            node2.SetParent(groupNode);
        }

        public static void Group(TransformNode node1)
        {
            TransformNode groupNode = new TransformNode("Group");
            node1.SetParent(groupNode);
        }
    }
}
