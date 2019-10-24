using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTree
{
    public class MyTree<NodeType>
        : IEnumerable
        where NodeType : IComparable
    {
        public MyNode<NodeType> RootNode { get; private set; }

        public MyTree()
        {

        }
        public MyTree(NodeType rootNodeValue)
        {
            this.RootNode = new MyNode<NodeType>(rootNodeValue);
        }

        public void AddNode(NodeType value)
        {
            if (this.RootNode == null)
                this.RootNode = new MyNode<NodeType>(value);
            else
                RootNode.AddNode(value);
        }

        public void DeleteNode(NodeType value)
        {
            var target = RootNode.FindInNode(value);
            if (target == null)
                return;
        }

        public MyNode<NodeType> FindNode(NodeType value)
        {
            return RootNode.FindInNode(value);
        }

        public IEnumerator GetEnumerator() //TODO
        {
            return this.GetChilds(this.RootNode);
        }
        private IEnumerator GetChilds(MyNode<NodeType> node) //
        {
            if (node.ExistLeftChild())
                yield return this.GetChilds(node.LeftNode);
            if (node.ExistRightChild())
                yield return this.GetChilds(node.RightNode);
            yield return node;
        }
        private void PrintChilds(MyNode<NodeType> node) //
        {
            if (node.ExistLeftChild())
                this.PrintChilds(node.LeftNode);
            if (node.ExistRightChild())
                this.PrintChilds(node.RightNode);
            Debug.WriteLine(node.Value);
        }
        public void PrintTree()
        {
            this.PrintChilds(this.RootNode);
        }
    }
}
