using System;
using System.Linq;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectEuler.Problems
{
	/// <summary>
	/// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example,
	/// the 5-digit number, 15234, is 1 through 5 pandigital.
	/// 
	/// The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
	/// 
	/// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
	/// HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
	/// </summary>
	class Exercise32
	{
		private const String PandigitalStart = "123456789";
		public static Object Solve()
		{
			return PandigitalStart.PermutationsList().ToCached()
								  .Select( x => new {
														X = x.Take(2).ToNumber(),
														Y = x.Skip(2).Take(3).ToNumber(),
														Product = x.Skip(5).Take(4).ToNumber()
													})
								  .Concat( PandigitalStart.PermutationsList().ToCached()
														  .Select( x => new
								                							{
								                								X = x.Take(1).ToNumber(),
																				Y = x.Skip(1).Take(4).ToNumber(),
																				Product = x.Skip(5).Take(4).ToNumber()
								                							})
																 )
								  .Where(eq => eq.X * eq.Y == eq.Product)
								  .Select(eq => eq.Product)
								  .Distinct()
								  .Sum();
		}
	}
}
