using System;
using System.Linq;
using Mathematics.Common;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectEuler.Problems
{
	/// <summary>
	/// The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.
	/// 
	/// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
	/// 
	/// (Please note that the palindromic number, in either base, may not include leading zeros.)
	/// </summary>
	class Exercise36
	{
		public static Object Solve()
		{
			return InfiniteIntList.Items.Take(1000000)
										.Where(x => x.IsPalindrome() && 
													Convert.ToString(x, 2).TrimStart('0').IsPalindrome())
										.Sum();
		}
	}
}
