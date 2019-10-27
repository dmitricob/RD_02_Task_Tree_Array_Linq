using System;
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
                newArr[i - 5] = i;
            foreach (var item in newArr)
                Debug.WriteLine(item);
            Debug.WriteLine(newArr[-5]);


            Action<string> SPrint = x => Console.WriteLine(x);
            Action<Student> Print = x => SPrint(x.ToString());

            MyTree<Student> studTree = new MyTree<Student>();
            studTree.ElementAddEvent += StudTree_ElementAddEvent;

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

            SPrint("InorderPrint");
            studTree.InorderPrint(studTree.RootNode, Print);

            SPrint("PreorderedPrint");
            studTree.PreorderPrint(studTree.RootNode, Print);

            SPrint("\nforeach print");
            foreach (var item in studTree)
            {
                SPrint(item.ToString());
            }
            SPrint("\nConverted to list");
            var a = studTree.ToList();
            foreach (var item in a)
            {
                SPrint(item.ToString());
            }
            Console.ReadLine();
        }

        private static void StudTree_ElementAddEvent(object sender, EventArgs ergs)
        {
            Debug.WriteLine("element added to " + sender);
        }
    }
}
