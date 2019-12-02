using System;
using System.Linq;

using Mathematics.Lists;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    /// 
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>
	class Exercise5
	{
		private const Int32 First = 1;
        private const Int32 Last = 20;

        public static Object Solve()
        {
            InfiniteMultiplicationList.StartFactor = 1;
            return InfiniteMultiplicationList.Items(Last) // First get a list of all multiplictions of 20 to make big steps
											 .First(x => InfiniteIntList.Items.Skip(First).Take(Last - First)
																			  .All(y => x % y == 0));
		}
	}
}
