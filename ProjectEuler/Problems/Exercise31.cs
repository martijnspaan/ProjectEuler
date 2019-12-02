using System;
using System.Linq;

using Mathematics.Lists;

namespace ProjectEuler.Problems
{
	/// <summary>
	/// In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
	/// 
	/// 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
	/// 
	/// It is possible to make £2 in the following way:
	/// 
	///	1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
	/// 
	/// How many different ways can £2 be made using any number of coins?
	/// </summary>
	class Exercise31
	{
		private const int Money = 200;

		public static Object Solve()
		{
			return FiniteIntList.GetItems(Money, 0, 200).SelectMany(
					a => FiniteIntList.GetItems(a, 0, 100).SelectMany(
						b => FiniteIntList.GetItems(b, 0, 50).SelectMany(
							c => FiniteIntList.GetItems(c, 0, 20).SelectMany(
								d => FiniteIntList.GetItems(d, 0, 10).SelectMany(
									e => FiniteIntList.GetItems(e, 0, 5).SelectMany(
										f => FiniteIntList.GetItems(f, 0, 2).Select(
												counter => 1))))))).Count();
		}
	}
}
