using System;
using System.Linq;
using Oyster.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
	/// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
	///
	/// What is the sum of the digits of the number 2^1000?
    /// </summary>
	class Exercise16
	{
    	private const int power = 1000;
        public static Object Solve()
		{
        	return IntX.Pow(2, power).ToString().ToCharArray().Sum(x => Int32.Parse(x.ToString()));
		}
	}
}