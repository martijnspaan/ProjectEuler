using System;
using System.Linq;

using Mathematics.Lists;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    ///
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
	class Exercise1
	{
        public static Object Solve()
		{
			InfiniteIntList.StartIndex = 1;
			var solution = InfiniteIntList.Items.Take(999)
												.Where(x => x%3 == 0 || x%5 == 0)
												.Sum();
			return solution;
		}
	}
}