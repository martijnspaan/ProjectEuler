using System;
using System.Linq;
using Mathematics.Common;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectEuler.Problems
{
	/// <summary>
	/// The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.
	/// 
	/// Find the sum of the only eleven primes that are both truncatable from left to right and right to left.
	/// 
	/// NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
	/// </summary>
	class Exercise37
	{
		public static Object Solve()
		{
			return InfinitePrimeNumbers.Items.SkipWhile(x => x < 10)
											 .Where(x => x.IsTruncatablePrime())
											 .Take(11)
											 .Sum();
		}
	}
}
