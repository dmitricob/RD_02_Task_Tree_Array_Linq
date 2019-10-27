using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTree
{
    public class MyNode<NodeType>
        : IComparable//,IEquatable<MyNode<NodeType>>,  IEquatable<NodeType>, IComparer<NodeType> 
        where NodeType : IComparable // ToDo make as passed delegate 
    {
        public NodeType Value { get; internal set; }

        //public MyNode<NodeType> ParentNode { get; private set; }
        public MyNode<NodeType> LeftNode { get; internal set; }
        public MyNode<NodeType> RightNode { get; internal set; }

        public MyNode(NodeType value)
        {
            this.Value = value;
        }

        //public MyNode<NodeType> FindRightMin()
        //{
        //    return this.RightNode.GetMin();
        //}
        //private MyNode<NodeType> GetMin()
        //{
        //    if (this.LeftNode == null)
        //        return this;
        //    else
        //        return this.LeftNode.GetMin();
        //}
        //public MyNode<NodeType> FindInNode(NodeType value)
        //{
        //    var compare = this.CompareTo(value);
        //    if (compare == 0)
        //        return this;
        //    else if (compare < 0)
        //        return this.LeftNode?.FindInNode(value);
        //    else
        //        return this.RightNode?.FindInNode(value);
        //}
        //public void AddNode(NodeType value)
        //{
        //    if (this == value)
        //        return;
        //    var comp = this.CompareTo(value);
        //    if (comp > 0)
        //    {
        //        if (this.LeftNode == null)
        //            this.LeftNode = new MyNode<NodeType>(value);
        //        else
        //            this.LeftNode.AddNode(value);
        //    }
        //    else
        //    {
        //        if (this.RightNode == null)
        //            this.RightNode = new MyNode<NodeType>(value);
        //        else
        //            this.RightNode.AddNode(value);
        //    }
        //}
        //public MyNode<NodeType> DellNode(NodeType value)
        //{
        //    return default(MyNode<NodeType>);
        //}

        public bool ExistLeftChild() => !ReferenceEquals(this.LeftNode, null);
        public bool ExistRightChild() => !ReferenceEquals(this.RightNode, null);
        public bool IsLastNode() => this.ExistLeftChild() || this.ExistRightChild();

        public void ReplaceWith(MyNode<NodeType> newNode)
        {
            this.Value = newNode.Value;
        }
        public override string ToString() => this.Value.ToString();
        public int CompareTo(object obj)
        {
            if (obj is MyNode<NodeType>)
            {
                var cobj = (MyNode<NodeType>)obj;
                return this.Value.CompareTo(cobj.Value);
            }
            else if (obj is NodeType)
            {
                var cobj = (NodeType)obj;
                return this.Value.CompareTo(cobj);
            }
            throw new ArgumentException("Error compare to type");
        }
        //public bool Equals(NodeType other)
        //{
        //    return this.Value.Equals(other);
        //}
        //public bool Equals(MyNode<NodeType> other)
        //{
        //    if (System.Object.ReferenceEquals(other, null))
        //        return false;
        //    return this.Equals(other.Value);
        //}

        public static bool operator ==(MyNode<NodeType> left, MyNode<NodeType> right) => left.CompareTo(right) == 0;
        public static bool operator !=(MyNode<NodeType> left, MyNode<NodeType> right) => !(left == right);
        public static bool operator >(MyNode<NodeType> left, MyNode<NodeType> right) => left.CompareTo(right) > 0;
        public static bool operator <(MyNode<NodeType> left, MyNode<NodeType> right) => left.CompareTo(right) < 0;

        public static bool operator ==(MyNode<NodeType> left, NodeType right) => left.CompareTo(right) == 0;
        public static bool operator !=(MyNode<NodeType> left, NodeType right) => !(left == right);
        public static bool operator >(MyNode<NodeType> left, NodeType right) => left.CompareTo(right) > 0;
        public static bool operator <(MyNode<NodeType> left, NodeType right) => left.CompareTo(right) < 0;
        public static bool operator ==( NodeType left, MyNode<NodeType>right) => left.CompareTo(right.Value) == 0;
        public static bool operator !=( NodeType left, MyNode<NodeType>right) => !(left == right);
        public static bool operator >( NodeType left, MyNode<NodeType>right) => left.CompareTo(right.Value) > 0;
        public static bool operator <( NodeType left, MyNode<NodeType>right) => left.CompareTo(right.Value) < 0;

    }
}
