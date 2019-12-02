using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mathematics.Lists;
using Mathematics.Extentions;
using Oyster.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order.
    /// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
    /// 
    /// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list.
    /// So, COLIN would obtain a score of 938 * 53 = 49714.
    /// 
	/// What is the total of all the name scores in the file?
    /// </summary>
	class Exercise22
    {
    	public static readonly IEnumerable<String> _names = File.ReadAllText(@".\Input\names.txt").Split(',').Select(x => x.Trim('"').ToLower());

		public static Object Solve()
		{
			return _names.OrderBy(x => x)
						  .Select((item, index) => item.Select(x => x - 'a' + 1).Sum()*(index + 1))
						  .Select(x => new IntX(x) )
						  .Sum();
		}
	}
}
