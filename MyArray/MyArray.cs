using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArray
{
    public class MyArray<ArrayType> : IEnumerable
    {
        private ArrayType[] arr;
        public int StartIndex { get; private set; }

        public int Length
        {
            get { return arr.Length; }
        }

        public MyArray(int size)
        {
            arr = new ArrayType[size];
            this.StartIndex = 0;
        }
        public MyArray(int size, int startIntex) : this(size)
        {
            this.StartIndex = startIntex;
        }

        public ArrayType this[int index]
        {
            get
            {
                return arr[index - this.StartIndex];
            }
            set
            {
                arr[index - this.StartIndex] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.Length; i++)
            {
                yield return arr[i];
            }
        }
    }
}
