using System;
using System.Linq;

using Mathematics.Lists;
using Mathematics.Extentions;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
    /// If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
    /// 
    /// 012   021   102   120   201   210
    /// 
	/// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
    /// </summary>
	class Exercise24
    {
		public static Object Solve()
		{
			InfiniteIntList.StartIndex = 0;
			return InfiniteIntList.Items.Take(10).PermutationsList().OrderBy(x => x).Skip(999999).First();
		}
	}
}
