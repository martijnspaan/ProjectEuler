using System;
using System.Linq;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// n! means n * (n - 1) * ... * 3 * 2 * 1
	///
	/// For example, 10! = 10 * 9 * ... * 3 * 2 * 1 = 3628800,
	/// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
	///
	/// Find the sum of the digits in the number 100!
    /// </summary>
	class Exercise20
    {
		public static Object Solve()
		{
			return InfiniteFacultyList.GetFaculty(100).Digits().Sum();
		}
	}
}
