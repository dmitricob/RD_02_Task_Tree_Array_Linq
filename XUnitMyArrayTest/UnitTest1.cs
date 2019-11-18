using System;
using Xunit;
using MyArray;

namespace XUnitMyArrayTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_CreateArrayWithWrongRange_TrowArgumentOutOfRangeException(int size)
        {
            // arrange
            // act
            Action action = () => new MyArray<int>(size, -1);
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(-4)]
        [InlineData(0)]
        [InlineData(4)]
        public void GetStartIndex_CreateArrayWithNStartIndex_ReturnN(int N)
        {
            // arrange
            // act
            var testArr = new MyArray<int>(1, N);
            // assert
            Assert.Equal(N,testArr.StartIndex);
        }

        [Theory]
        [InlineData(1,-1,-2)]
        [InlineData(1,1,0)]
        public void Indexator_CallIndexOutOfRange_TrowIndexOutOfRangeException(int size, int startIndex,int index)
        {
            // arrange
            var testArr = new MyArray<int>(size, startIndex);
            Func<MyArray<int>,int,int> func = (arr,i)=>arr[i];
            // act
            Action action = () => func(testArr, index);
            // assert
            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Fact]
        public void Indexator_Add10OnIndexMinus3_Return10OnIndexMinus3()
        {
            // arrange
            var testArr = new MyArray<int>(1, -3);
            int index = -3;
            int target = 10;
            int expected = 10;
            int actual;
            // act
            testArr[index] = target;
            actual = testArr[index];
            // assert
            Assert.Equal(expected, actual);
        }
    }
}