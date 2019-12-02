using System;
using System.Linq;

using Mathematics.Lists;
using Mathematics.Extentions;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// <![CDATA[
    /// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
    ///         a(2) + b(2) = c(2)
    ///
    /// For example, 3(2) + 4(2) = 9 + 16 = 25 = 5(2).
    ///
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product abc.
    /// ]]>
    /// </summary>
	class Exercise9
    {
    	private const int MaxValueForA = 1000 / 3;

        public static Object Solve()
		{
            InfiniteIntList.StartIndex = 1;
            var solution = InfiniteIntList.Items.Take(MaxValueForA)
                                                .SelectMany(
                                                                a => InfiniteIntList.Items.Skip((int)a)
                                                                                          .TakeWhile(b => b < (1000-a) / 2)
                                                                                          .Select( b => new { a, b, c = 1000 - b - a } )
                                                            )
                                                .Where(x => Math.Pow(x.a, 2) + Math.Pow(x.b, 2) == Math.Pow(x.c, 2))
                                                .Select(x => x.a * x.b * x.c)
                                                .Single();
            return solution;
		}
	}
}
