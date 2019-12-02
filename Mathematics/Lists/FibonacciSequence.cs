using System;
using System.Collections.Generic;
using Oyster.Math;

namespace Mathematics.Lists
{
	public class FibonacciSequence
	{
		public static IEnumerable<Int64> Items
		{
			get
			{
				Int64 first = 0;
				Int64 second = 1;
				while (true)
				{
					Int64 curFirst = first;
					Int64 curSecond = second;

					first = second;
					second = curFirst + curSecond;
					yield return curFirst + curSecond;
				}
			}
		}

		public static IEnumerable<IntX> ItemsX
		{
			get
			{
				IntX first = 0;
				IntX second = 1;

			    //yield return first;
                yield return second;

				while (true)
				{
					IntX curFirst = first;
					IntX curSecond = second;

					first = second;
					second = curFirst + curSecond;
					yield return curFirst + curSecond;
				}
			}
		}
	}
}