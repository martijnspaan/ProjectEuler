using System;
using System.Collections.Generic;
using System.Linq;

namespace Mathematics.Lists
{
	// Apply http://en.wikipedia.org/wiki/Sieve_of_Atkin
	public static class InfinitePrimeNumbers
	{
        public static IEnumerable<Int64> Items
        {
            get
            {
                // Skip all even numbers
                InfiniteIntList.StartIndex = 7;
                InfiniteIntList.Step = 2;

                // Return list of prime numbers, start with 2, 3 and 5
                return new List<Int64> { 2, 3, 5 }.Concat(InfiniteIntList.Items.Where(x => x.IsPrime()));
            }
        }

        public static bool IsPrime(this Int64 number)
        {
			if (number <= 0)
				return false;

            if (number % 2 == 0 || number % 5 == 0)
                return number == 2 || number == 5;

            Int64 r = number % 60;
            if (r % 2 == 0 || r % 3 == 0 || r % 5 == 0)
                return number == 3;

            Int64 sqrt = (Int64)Math.Sqrt(number);
            for (Int64 t = 3; t <= sqrt; t = t + 2)
            {
                if (number % t == 0) { return false; }
            }

            return number != 1;
        }

		public static bool IsTruncatablePrime(this Int64 number)
		{
			string primeNumber = number.ToString();
			for (int i = 0; i < primeNumber.Length; i++ )
			{
				if (!Convert.ToInt64(primeNumber.Substring(i)).IsPrime())
					return false;
			}

			for (int i = 0; i < primeNumber.Length; i++)
			{
				if (!Convert.ToInt64(primeNumber.Substring(0, primeNumber.Length - i)).IsPrime())
					return false;
			}
			return true;
		}
	}
}