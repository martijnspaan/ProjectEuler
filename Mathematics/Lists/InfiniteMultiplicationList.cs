using System;
using System.Collections.Generic;

namespace Mathematics.Lists
{
	/// <summary>
	/// Represents an infinite enumerable list of al products for a multiplication table, starting at <see cref="StartFactor"/>.
	/// </summary>
	public static class InfiniteMultiplicationList
	{
		/// <summary>
		/// Specifies the factor to start the multiplication with.
		/// </summary>
        public static Int64 StartFactor { get; set; }

        /// <summary>
        /// Gets an infinite long list of <see cref="Int64"/> natural numbers that are the product of <paramref name="baseFactor"/>.
        /// </summary>
        /// <remarks>
        /// Note: reversing this enumeration or instantiating it to a list using Linq will result in a infinite loop.
        /// This can be worked around by first using Take() to specify a maximum number of items.
        /// </remarks>
		public static IEnumerable<Int64> Items(Int64 baseFactor)
		{
            Int64 curFactor = StartFactor;
            while (true)
            {
                yield return baseFactor * curFactor++;
            }
		}

        /// <summary>
        /// Gets an infinite long list of <see cref="Int64"/> natural numbers in reversed order that are the product of <paramref name="baseFactor"/>.
        /// </summary>
        /// <remarks>
        /// Note: reversing this enumeration or instantiating it to a list using Linq will result in a infinite loop.
        /// This can be worked around by first using Take() to specify a maximum number of items.
        /// </remarks>
        public static IEnumerable<Int64> ReverseItems(Int64 baseFactor)
		{
			Int64 curFactor = StartFactor;
            while (true)
            {
                yield return baseFactor * curFactor--;
            }
		}
	}
}