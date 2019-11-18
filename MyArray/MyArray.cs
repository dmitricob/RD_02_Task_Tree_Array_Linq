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
        //public int EndIndex { get; private set; }

        public int Length
        {
            get { return arr.Length; }
        }

        public MyArray(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException("Invalid array size");
            arr = new ArrayType[size];
            this.StartIndex = 0;
        }
        public MyArray(int size, int startIndex) : this(size)
        {
            this.StartIndex = startIndex;
        }
        //public MyArray(int startIndex, int endIndex) : this(endIndex - startIndex + 1)
        //{
        //    if (endIndex <= StartIndex)
        //        throw new ArgumentOutOfRangeException($"end index {endIndex} start index {startIndex}");
        //    this.StartIndex = startIndex;
        //    this.EndIndex = endIndex;

        //}

        public ArrayType this[int index]
        {
            get
            {
                var realIndex = index - this.StartIndex;
                if (realIndex < 0 || realIndex >= this.Length)
                    throw new IndexOutOfRangeException($"array range {this.StartIndex} .. {this.StartIndex + this.Length - 1} index in custom array : {index} array");
                return arr[realIndex];
            }
            set
            {
                var realIndex = index - this.StartIndex;
                if (realIndex < 0 || realIndex >= this.Length)
                    throw new IndexOutOfRangeException($"array range {this.StartIndex} .. {this.StartIndex + this.Length - 1} index in custom array : {index} array");
                arr[realIndex] = value;
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
