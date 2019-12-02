using System;
using System.Linq;

using Mathematics.Lists;
using Mathematics.Extentions;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    ///
    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
	class Exercise4
	{
		private const Int64 firstProduct = 999;
		private const Int64 secondProduct = 999;

        public static Object Solve()
		{
            MathematicalTableList.XFactor = firstProduct;
            MathematicalTableList.YFactor = secondProduct;

            var solution = MathematicalTableList.ReverseItems.First(x => x.IsPalindrome());

            return solution;
		}
	}
}
