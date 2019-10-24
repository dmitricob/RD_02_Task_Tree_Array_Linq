﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyArray;
using MyTree;

namespace RD_02_Task_Tree_Array_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArray<int> newArr = new MyArray<int>(10,-5);
            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i - 5] = i;
            }
            foreach (var item in newArr)
            {
                Debug.WriteLine(item);
            }
            Debug.WriteLine(newArr[-5]);

            MyTree<int> tree = new MyTree<int>(100);
            tree.AddNode(50);
            tree.AddNode(150);
            tree.AddNode(25);
            tree.AddNode(75);
            tree.AddNode(15);
            tree.AddNode(35);
            tree.AddNode(65);
            tree.AddNode(85);
            var f = tree.FindNode(25);
            var f1 = tree.FindNode(5);
            tree.PrintTree();
            //foreach (var item in tree)
            //{
            //    Debug.WriteLine(((MyNode<int>)item).Value);
            //}
            MyTree<Student> studTree = new MyTree<Student>();
            studTree.AddNode(new Student("Name1", "SecondName1", 50));
            studTree.AddNode(new Student("Name2", "SecondName2", 25));
            studTree.AddNode(new Student("Name3", "SecondName3", 75));
            studTree.AddNode(new Student("Name4", "SecondName4", 50));
            studTree.AddNode(new Student("Name5", "SecondName5", 50));
            studTree.AddNode(new Student("Name6", "SecondName6", 15));
            studTree.AddNode(new Student("Name7", "SecondName7", 35));
            studTree.AddNode(new Student("Name8", "SecondName8", 99));
            studTree.AddNode(new Student("Name9", "SecondName9", 5));
            studTree.AddNode(new Student("Name9", "SecondName9", 65));
            studTree.AddNode(new Student("Name9", "SecondName9", 5));
        }
    }
}
