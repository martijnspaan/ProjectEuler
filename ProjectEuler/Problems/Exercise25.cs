using System;
using System.Linq;
using Mathematics.Lists;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// The Fibonacci sequence is defined by the recurrence relation:
    /// 
	/// Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
	/// 
    /// The 12th term, F12, is the first term to contain three digits.
    /// 
    /// What is the first term in the Fibonacci sequence to contain 1000 digits?
	/// 
    /// </summary>
	class Exercise25
	{
		private const int MinDigitCount = 1000;
		public static Object Solve()
		{
			return FibonacciSequence.ItemsX.TakeWhile(x => x.ToString().Count() < MinDigitCount).Select((x, index) => index+3).Last();
		}
	}
}
