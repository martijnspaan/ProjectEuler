using System;
using System.Linq;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// The following iterative sequence is defined for the set of positive integers:
	/// 
    ///			n → n/2 (n is even)
    ///			n → 3n + 1 (n is odd)
    /// 
    /// Using the rule above and starting with 13, we generate the following sequence:
    ///			13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
    /// 
    /// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
    /// 
    /// Which starting number, under one million, produces the longest chain?
    /// 
	/// NOTE: Once the chain starts the terms are allowed to go above one million.
    /// </summary>
	class Exercise14
	{
    	private const Int32 MaxNumber = 1000000;

        public static Object Solve()
		{
			return InfiniteIntList.Items.Take(MaxNumber)
										.Select(x => new {
										             		Index = x,
															Count = CollatzSequence.Items(x).Count()
										             	 })
										.MaxItem(x => x.Count)
										.Index;
		}
	}
}