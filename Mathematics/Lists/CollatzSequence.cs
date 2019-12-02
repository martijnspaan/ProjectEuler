using System;
using System.Collections.Generic;

namespace Mathematics.Lists
{
	public class CollatzSequence
	{
		public static IEnumerable<Int64> Items(Int64 n)
		{
			while (n > 1)
			{
				yield return n;

				if (n % 2 == 0)
				{
					n = n / 2;
				}
				else
				{
					n = (n * 3) + 1;
				}
			}
			yield return 1;
		}
	}
}