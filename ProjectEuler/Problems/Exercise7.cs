using System;
using System.Linq;

using Mathematics.Lists;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    ///
    /// What is the 10001st prime number?
    /// </summary>
	class Exercise7
	{
		private const Int32 SelectedPrime = 10001;

        public static Object Solve()
		{
            return InfinitePrimeNumbers.Items.Skip(SelectedPrime-1).First();
		}
	}
}
