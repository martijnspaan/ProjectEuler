using System;
using System.Linq;
using System.Collections.Generic;

namespace Mathematics.Lists
{
	/// <summary>
	/// Represents a enumerable list of infinite natural numbers, starting at <see cref="StartIndex"/>.
	/// </summary>
	/// <remarks>Currently the list is actually limited to <see cref="long.MaxValue"/>.</remarks>
	public static class InfiniteIntList
	{
		/// <summary>
		/// Specifies the start index from where to start the infinite list.
		/// </summary>
		public static Int64 StartIndex { get; set;}

		private static Int64 _step = 1;

		/// <summary>
		/// Gets or sets the amount that is used to increment or decrement each iteration.
		/// </summary>
		public static Int64 Step
		{
			get { return _step; }
			set { _step = value; }
		}

		/// <summary>
		/// Gets an infinite long list of <see cref="Int64"/> natural numbers, starting with <see cref="StartIndex"/>.
		/// </summary>
		/// <remarks>
		/// Note: reversing this enumeration or instantiating it to a list using Linq will result in a infinite loop.
		/// This can be worked around by first using Take() to specify a maximum number of items.
		/// </remarks>
		public static IEnumerable<Int64> Items
		{
			get
			{
                return GetItems(StartIndex, _step);
			}
		}

		public static IEnumerable<Int64> GetItems(Int64 startIndex)
		{
			Int64 number = startIndex;

			yield return number;
			while (true)
			{
				yield return number += _step;
			}
		}

		/// <summary>
		/// Gets an infinite long list of <see cref="Int64"/> natural numbers, starting with <paramref name="startIndex"/>.
		/// </summary>
		/// <param name="startIndex">The index to start with.</param>
		/// <param name="step">The amount to step between each iteration.</param>
		/// <remarks>
		/// Note: reversing this enumeration or instantiating it to a list using Linq will result in a infinite loop.
		/// This can be worked around by first using Take() to specify a maximum number of items.
		/// </remarks>
		public static IEnumerable<Int64> GetItems(Int64 startIndex, Int64 step)
		{
			_step = step;
			return GetItems(startIndex);
		}

		/// <summary>
		/// Gets an infinite long list of <see cref="Int64"/> natural numbers in reversed order, starting with <see cref="StartIndex"/>. When specifying 0 as startindex, only negative numbers are returned.
		/// </summary>
		/// <remarks>
		/// Note: reversing this enumeration or instantiating it to a list using Linq will result in a infinite loop.
		/// This can be worked around by first using Take() to specify a maximum number of items.
		/// </remarks>
		public static IEnumerable<Int64> ReverseItems
		{
			get
			{
				Int64 number = StartIndex;

                yield return number;
				while (true)
				{
					yield return number -= _step;
				}
			}
		}
	}
}