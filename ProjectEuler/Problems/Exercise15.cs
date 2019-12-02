using System;
using System.Linq;

using Mathematics.Lists;

namespace ProjectEuler.Problems
{
    /// <summary>
	/// Starting in the top left corner of a 2×2 grid, there are 6 routes (without backtracking) to the bottom right corner.
	///
	/// How many routes are there through a 20×20 grid?
    /// </summary>
	class Exercise15
	{
    	private const int GridSize = 20;
        public static Object Solve()
		{
			return PascalsTriangle.GetEntry(GridSize * 2, GridSize);
		}
	}
}