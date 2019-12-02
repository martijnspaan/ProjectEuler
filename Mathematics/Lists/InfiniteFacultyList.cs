using System;
using System.Linq;
using System.Collections.Generic;
using Oyster.Math;

namespace Mathematics.Lists
{
	/// <summary>
	/// Represents a enumerable list of infinite faculty numbers, starting at 1!.
	/// </summary>
	/// <remarks>Currently the list is actually limited to <see cref="long.MaxValue"/>.</remarks>
	public static class InfiniteFacultyList
	{
		public static IntX GetFaculty(int faculty)
		{
			return Items.Skip(faculty-1).First();
		}

		/// <summary>
		/// Gets an infinite long list of <see cref="Int64"/> faculty numbers.
		/// </summary>
		/// <remarks>
		/// Note: reversing this enumeration or instantiating it to a list using Linq will result in a infinite loop.
		/// This can be worked around by first using Take() to specify a maximum number of items.
		/// </remarks>
		public static IEnumerable<IntX> Items
		{
			get
			{
				IntX indexer = 1;
				IntX number = 1;

				while (true)
				{
					number *= indexer++;
					yield return number;
				}
			}
		}
	}
}