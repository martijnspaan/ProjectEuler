using System;
using System.Linq;
using Mathematics.Common;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectEuler.Problems
{
	/// <summary>  
	/// If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.
	/// 
	/// {20,48,52}, {24,45,51}, {30,40,50}
	/// 
	/// For which value of p ≤ 1000, is the number of solutions maximised?
	/// </summary>
	class Exercise39
	{
		/// <summary>
		/// Smallest possible triangle perimiter
		/// </summary>
		public const int SmallestPerimeter = 12;
		public const int MaxSideLength = 500;
		public const int MinSideLength = 3;

		public static Object Solve()
		{
			InfiniteIntList.StartIndex = SmallestPerimeter;
			return InfiniteIntList.Items
								  .TakeWhile(p => p <= 1000)
								  .SelectMany(p => InfiniteIntList.GetItems(MinSideLength)
																  .TakeWhile(a => a <= MaxSideLength)
																  .SelectMany(a => InfiniteIntList.GetItems(MinSideLength)
																								  .Skip((int)a)
																								  .TakeWhile(b => b < (p - a) / 2)
																								  .Select(b => new { p, a, b, c = p - b - a })))
								  .Where(x => Math.Pow(x.a, 2) + Math.Pow(x.b, 2) == Math.Pow(x.c, 2))
								  // Filter out duplicate entries
								  .GroupBy(x => x.p)
								  .OrderByDescending(group => group.Count())
								  .First()
								  .Key;
		}
	}
}
