using System;
using System.Linq;

using Mathematics.Lists;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    ///
    /// Find the sum of all the primes below two million.
    /// </summary>
	class Exercise10
	{
        private const int MaxPrimevalue = 2000000;		

        public static Object Solve()
		{
			return InfinitePrimeNumbers.Items.TakeWhile(x => x < MaxPrimevalue).Sum();
		}
	}
}
