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

        public delegate void ElementAddEventHandler(object sender, EventArgs ergs);
        public event ElementAddEventHandler ElementAddEvent;

        public MyTree()
        {

        }
        public MyTree(NodeType rootNodeValue)
        {
            this.RootNode = new MyNode<NodeType>(rootNodeValue);
        }


        public void AddNode(NodeType value)
        {
            ElementAddEvent?.Invoke(this,null);
            if (ReferenceEquals(this.RootNode, null))
            {
                this.RootNode = new MyNode<NodeType>(value);
                return;
            }
            this.AddNode(this.RootNode,value);
            //if (this.RootNode == null)
            //    this.RootNode = new MyNode<NodeType>(value);
            //else
            //    RootNode.AddNode(value);
        }
        private void AddNode(MyNode<NodeType> root, NodeType value)
        {
            if (ReferenceEquals(root, null))
                throw new ArgumentNullException("one of passed params are null");

            if (root == value)
                return;
            else if (value < root)
            {
                if (!root.ExistLeftChild())
                    root.LeftNode = new MyNode<NodeType>(value);
                else
                    AddNode(root.LeftNode,value);
            }
            else //if(root.CompareTo(node) > 0)
            {
                if (!root.ExistRightChild())
                    root.RightNode= new MyNode<NodeType>(value);
                else
                    AddNode(root.RightNode, value);
            }
        }
        

        public MyNode<NodeType> GetMin(MyNode<NodeType> root)
        {
            if (!root.ExistLeftChild())
                return root;
            return this.GetMax(root.LeftNode);
        }
        public MyNode<NodeType> GetMax(MyNode<NodeType> root)
        {
            if (!root.ExistRightChild())
                return root;
            return this.GetMin(root.RightNode);
        }


        // return branch from root with deleted min node
        private MyNode<NodeType> DeleteMin(MyNode<NodeType> root) 
        {
            if (root.ExistLeftChild())
                root.LeftNode = this.DeleteMin(root.LeftNode);
            else
                root = root.RightNode;
            return root;

            if (!root.ExistLeftChild())
                return root = root.RightNode;
            root.LeftNode = this.DeleteMin(root.LeftNode);
            return root;
        }
        public void DeleteNode(NodeType value) // ToDo
        {
            var target =  this.FindNode(value);
            if (ReferenceEquals(target, null))
                return;
            target.ReplaceWith(this.GetMin(target.RightNode));
            target.RightNode = this.DeleteMin(target.RightNode);
        }


        public MyNode<NodeType> FindNode(NodeType value) => this.FindNode(this.RootNode,value);
        private MyNode<NodeType> FindNode(MyNode<NodeType> root, NodeType value)
        {
            if(ReferenceEquals(root, null)) 
                return default(MyNode<NodeType>);
            else if(root == value)
                return root;
            else if (value < root)
                return this.FindNode(root.LeftNode, value);
            else //if (value > root)
                return this.FindNode(root.RightNode, value);
            
        }


        public void PreorderPrint(MyNode<NodeType> root, Action<NodeType> Print)
        {
            if (ReferenceEquals(root,null))   // Базовый случай
                return;
            Print(root.Value);
            PreorderPrint(root.LeftNode,Print);   //рекурсивный вызов левого поддерева
            PreorderPrint(root.RightNode,Print);  //рекурсивный вызов правого поддерева
        }
        public void InorderPrint(MyNode<NodeType> root,Action<NodeType> Print)
        {
            if (ReferenceEquals(root, null))   // Базовый случай
                return;
            InorderPrint(root.LeftNode,Print);   //рекурсивный вызов левого поддерева
            Print(root.Value);
            InorderPrint(root.RightNode,Print);  //рекурсивный вызов правого поддерева
        }
        public void StackPrint()
        {
            Action<string> Print;
            Print = x => Debug.Write(x+" ");
            Stack<MyNode<NodeType>> nodeStack = new Stack<MyNode<NodeType>>();
            nodeStack.Push(this.RootNode);
            while (nodeStack.Count > 0)
            {
                var current = nodeStack.Pop();
                Print(current.Value.ToString());
                if(current.ExistRightChild())
                    nodeStack.Push(current.RightNode);
                if(current.ExistLeftChild())
                    nodeStack.Push(current.LeftNode);
            }
        }

        public List<NodeType> ToList()
        {
            List<NodeType> lst = new List<NodeType>();
            Action<NodeType> alst = a => lst.Add(a);
            this.InorderPrint(this.RootNode,alst);
            return lst;
        }

        public IEnumerator GetEnumerator()
        {
            Action<string> Print;
            Print = x => Debug.Write(x + " ");
            Stack<MyNode<NodeType>> nodeStack = new Stack<MyNode<NodeType>>();
            nodeStack.Push(this.RootNode);
            while (nodeStack.Count > 0)
            {
                var current = nodeStack.Pop();
                yield return current;
                if (current.ExistRightChild())
                    nodeStack.Push(current.RightNode);
                if (current.ExistLeftChild())
                    nodeStack.Push(current.LeftNode);
            }
        }
    }
    
}
