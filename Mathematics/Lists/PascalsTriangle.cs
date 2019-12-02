using System;
using System.Linq;
using Mathematics.Extentions;

namespace Mathematics.Lists
{
	public class PascalsTriangle
	{
		public static Int64 GetEntry(int row, int column)
		{
			// the L suffix on "Entry = 1L" is to force Entry to have a long type
			return List.Infinite(new { Entry = 1L, Column = 1 },
									 previous =>
									 new
									 {
										 Entry = (previous.Entry * (row + 1 - previous.Column)) / previous.Column,
										 Column = previous.Column + 1
									 })
				.SkipWhile(item => item.Column <= column)
				.First()
				.Entry;
		}
	}
}