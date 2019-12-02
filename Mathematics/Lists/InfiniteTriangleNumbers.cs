using System;
using System.Linq;
using System.Collections.Generic;

namespace Mathematics.Lists
{
	/// <summary>
	/// Represents an enumerable list of infinite triangle numbers, starting at <see cref="StartIndex"/>.
	/// </summary>
	/// <remarks>Currently the list is actually limited to <see cref="long.MaxValue"/>.</remarks>
	public static class InfiniteTriangleNumbers
	{
		/// <summary>
		/// Gets an infinite long list of <see cref="Int64"/> triangle numbers, starting with <see cref="StartIndex"/>.
		/// </summary>
		/// <remarks>
		/// Note: reversing this enumeration or instantiating it to a list using Linq will result in a infinite loop.
		/// This can be worked around by first using Take() to specify a maximum number of items.
		/// </remarks>
		public static IEnumerable<Int64> Items
		{
			get
			{
				Int64 curIndex = 1;
				Int64 curTriangleNumber = 0;
				while (true)
				{
					// Move to next triangle
					curTriangleNumber += curIndex++;

					yield return curTriangleNumber;
				}
			}
		}
	}
}