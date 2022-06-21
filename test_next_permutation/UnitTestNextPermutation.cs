using System;
using Xunit;
using NextPermutation.Service;

namespace TestNextPermutation
{
    public class UnitTestNextPermutation
    {
        [Theory]
        [InlineData(new int[]{0, 2, 1}, new int[]{1, 0, 2})]
        [InlineData(new int[]{0, 1, 2}, new int[]{ 0, 2, 1 })]
        [InlineData(new int[]{2, 1, 0}, new int[]{ 0, 1, 2 })]
        [InlineData(new int[]{ 0, 1, 2, 5, 3, 3, 0 }, new int[]{ 0, 1, 3, 0, 2, 3, 5 })]
        [InlineData(new int[]{ 0, 1, 0, 0, 0, 0, 0 }, new int[]{ 1, 0, 0, 0, 0, 0, 0 })]
        [InlineData(new int[]{ 0, 0, 0, 0, 0, 0, 1 }, new int[]{ 0, 0, 0, 0, 0, 1, 0 })]
        [InlineData(new int[]{ 1, 1, 0, 0, 0, 0, 0 }, new int[]{ 0, 0, 0, 0, 0, 1, 1 })]
        public void TestNextPerm(int[] array, int[] result)
        {
            IPermutation objToTest = new Permutation();
            int[] toTest = objToTest.GetNextPermutation(array);
            Console.WriteLine(toTest);
            Assert.Equal(result, toTest);
        }
    }
}
