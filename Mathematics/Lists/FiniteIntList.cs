using System;
using System.Collections.Generic;

namespace Mathematics.Lists
{
	/// <summary>
	/// Represents an enumerable list of finite natural numbers.
	/// </summary>
	public static class FiniteIntList
	{
		public static IEnumerable<Int64> GetItems(Int64 end)
		{
			return GetItems(0, end, 1);
		}

		public static IEnumerable<Int64> GetItems(Int64 start, Int64 end)
		{
			return GetItems(start, end, 1);
		}

		public static IEnumerable<Int64> GetItems(Int64 start, Int64 end, Int64 step)
		{
			if (start == end)
			{
				yield return start;
			}
			else if (start > end)
			{
				for (Int64 i = start; i >= end; i -= step)
				{
					yield return i;
				}
			}
			else
			{
				for (Int64 i = start; i <= end; i += step)
				{
					yield return i;
				}
			}
		}
	}
}