using System;
using System.Linq;
using Mathematics.Common;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectEuler.Problems
{
	/// <summary>
	/// 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
	/// 
	/// Find the sum of all numbers which are equal to the sum of the factorial of their digits.
	/// 
	/// Note: as 1! = 1 and 2! = 2 are not sums they are not included.
	/// </summary>
	class Exercise34
	{
		public static Object Solve()
		{
			InfiniteIntList.StartIndex = 10;
			return InfiniteIntList.Items.Take(50000)
										.Where(x => x.ToString().ToIntList().Select(y => y.Factorial()).Sum() == x)
										.Sum();
		}
	}
}
