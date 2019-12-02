using System;
using System.Linq;
using Mathematics.Common;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectEuler.Problems
{
	/// <summary>
	/// The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
	/// 
	/// There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
	/// 
	/// How many circular primes are there below one million?
	/// </summary>
	class Exercise35
	{
		public static Object Solve()
		{
			return InfinitePrimeNumbers.Items.TakeWhile(x => x <= 1000000)
											 .Where(x => x < 10 || x.ToString().All( y => y == '1' || y == '3' || y == '7' || y == '9'))
											 .Where(x => x.CircularList().All(y => y.IsPrime()))
											 .Count();
		}
	}
}
