using System;
using Xunit;
using MyTree;

namespace XUnitMyTreeTest
{
    public class UnitTest1
    {
        [Fact]
        public void Costructor_CreateTreeWithIntRoot3_RootMustBeInt3()
        {
            //arrange
            int expected = 3;
            MyTree<int> tree ;
            int actual;
            //act
            tree = new MyTree<int>(expected);
            actual = tree.RootNode.Value;
            //assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void AddNode_AddNodeInt3LessThenRoot4_CreateLeftChildInt3ToRootNodeInt4()
        {
            //arrange
            MyTree<int> tree;
            int expected = 3;
            int actual;
            //act
            tree = new MyTree<int>(4);
            tree.AddNode(expected);
            actual = tree.RootNode.LeftNode.Value;
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddNode_AddNodeInt5BigerThenRoot4_CreateRightChildInt5ToRootNodeInt4()
        {
            //arrange
            MyTree<int> tree;
            int expected = 5;
            int actual;
            //act
            tree = new MyTree<int>(4);
            tree.AddNode(expected);
            actual = tree.RootNode.RightNode.Value;
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_CreateTreeWithPreDefindeRootAndCreateEmptyTreeAndThenAddRoot_BothRootMustBeEqual()
        {
            //arrange
            MyTree<int> tree1;
            MyTree<int> tree2;
            int value = 5;
            //act
            tree1 = new MyTree<int>(value);
            tree2 = new MyTree<int>();
            tree2.AddNode(value);
            //assert
            Assert.Equal(tree1.RootNode,tree2.RootNode);
        }

        [Fact]
        public void GetMin_GetMinElement2OfTree_Return2()
        {
            //arrange
            MyTree<int> tree = new MyTree<int>(10);
            tree.AddNode(5);
            tree.AddNode(11);
            tree.AddNode(7);
            tree.AddNode(6);
            tree.AddNode(4);
            tree.AddNode(2);
            int expected = 2;
            int actual;
            //act
            actual = tree.GetMin(tree.RootNode).Value;
            //assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void GetMax_GetMaxElement11OfTree_Return11()
        {
            //arrange
            MyTree<int> tree = new MyTree<int>(10);
            tree.AddNode(5);
            tree.AddNode(11);
            tree.AddNode(7);
            tree.AddNode(6);
            tree.AddNode(4);
            tree.AddNode(2);
            int expected = 11;
            int actual;
            //act
            actual = tree.GetMax(tree.RootNode).Value;
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindNode_FindNotInt5_ReturnInt5()
        {
            //arrange
            MyTree<int> tree = new MyTree<int>(10);
            tree.AddNode(11);
            tree.AddNode(7);
            tree.AddNode(6);
            tree.AddNode(4);
            tree.AddNode(2);
            tree.AddNode(5);
            int expected = 5;
            int actual;
            //act
            actual = tree.FindNode(expected).Value;
            //assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void DeleteNode_DeleteNodeInt4_TreeShoudNotContainInt4()
        {
            //arrange
            MyTree<int> tree = new MyTree<int>(10);
            tree.AddNode(11);
            tree.AddNode(7);
            tree.AddNode(6);
            tree.AddNode(4);
            tree.AddNode(3);
            tree.AddNode(2);
            tree.AddNode(5);
            MyNode<int> actual;
            //act
            tree.DeleteNode(4);
            actual = tree.FindNode(4);
            //assert
            Assert.Null(actual);
        }
    }
}
