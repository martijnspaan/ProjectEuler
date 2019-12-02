using System;
using System.Linq;

using Mathematics.Lists;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// The sum of the squares of the first ten natural numbers is,
    /// 1 to the power of (2) + 2 to the power of (2) + ... + 10 to the power of (2) = 385
    ///
    /// The square of the sum of the first ten natural numbers is,
    /// (1 + 2 + ... + 10) to the power of (2) = 55 to the power of (2) = 3025
    ///
    /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
    ///
    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary>
	class Exercise6
	{
		private const Int32 NumberOfItems = 100;

        public static Object Solve()
		{
            InfiniteIntList.StartIndex = 1;
            InfiniteSquareList.StartIndex = 1;

            return Math.Pow(InfiniteIntList.Items.Take(NumberOfItems).Sum(), 2) - InfiniteSquareList.Items.Take(NumberOfItems).Sum();
		}
	}
}
