using System;
using System.Linq;

using Mathematics.Lists;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
	/// 
    /// 1634 = 1^4 + 6^4 + 3^4 + 4^4
    /// 8208 = 8^4 + 2^4 + 0^4 + 8^4
    /// 9474 = 9^4 + 4^4 + 7^4 + 4^4
	/// 
	/// As 1 = 1^4 is not a sum it is not included.
	/// 
	/// The sum of these numbers is 1634 + 8208 + 9474 = 19316.
	/// 
	/// Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
	/// 
    /// </summary>
	class Exercise30
    {
    	private const Int32 Power = 5;
		public static Object Solve()
		{
			InfiniteIntList.StartIndex = 10;
			return InfiniteIntList.Items.Select( x => new { Number = x, Sum = x.ToString()
																			   .Select(y => Int64.Parse(y.ToString()))
																			   .Skip(1)
																			   .Aggregate((Int64)Math.Pow(Int64.Parse(x.ToString().First().ToString()), Power), (sum, digit) => sum += (Int64) Math.Pow(digit, Power))
															})
										.TakeWhile(x => x.Number.ToString().Length*Math.Pow(9, 5) > x.Number) // Stop when nr_digits * max_digit ^ power > number
										.Where(x => x.Sum == x.Number) // Only take items where the numer is equal to it's calculated value
										.Sum(x => x.Number);
		}
	}
}
