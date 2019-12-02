using System;
using System.Linq;

using Mathematics.Lists;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    ///
    /// What is the largest prime factor of the number 600851475143 ?
    /// </summary>
	class Exercise3
	{
		private static readonly Int64 BaseNumber = 600851475143;

        public static Object Solve()
		{
			InfiniteIntList.StartIndex = 1;

			var solution = InfiniteIntList.Items.Take((int)Math.Sqrt(BaseNumber))
											 .Where(x => BaseNumber % x == 0)
											 .Reverse()
											 .First(x => x.IsPrime());

            return solution;
		}
	}
}
