using System;
using System.Linq;
using System.Collections.Generic;

namespace Mathematics.Lists
{
	/// <summary>
	/// Represents a enumerable list of al products for a mathematical table, starting at <see cref="StartX"/> and <see cref="StartY"/>.
	/// </summary>
	public static class MathematicalTableList
	{
		/// <summary>
		/// Specifies the start index for the X factor where to start.
		/// </summary>
		public static Int64 StartX { get; set;}

        /// <summary>
        /// Specifies the start index for the Y factor where to start.
        /// </summary>
        public static Int64 StartY { get; set; }

        /// <summary>
        /// The X factor used in the calculation of the mathimatical table.
        /// </summary>
        public static Int64 XFactor { get; set; }

        /// <summary>
        /// The Y factor used in the calculation of the mathimatical table.
        /// </summary>
        public static Int64 YFactor { get; set; }

		/// <summary>
        /// Gets a list of <see cref="Int64"/> natural numbers, which is the product of X and Y, starting with <see cref="StartX"/> and <see cref="StartY"/>.
		/// </summary>
		public static IEnumerable<Int64> Items
		{
			get
			{
                return UnsortedItems.Distinct().OrderBy(x => x);
			}
		}

        /// <summary>
        /// Gets a reversed list of <see cref="Int64"/> natural numbers, which is the product of X and Y, starting with <see cref="StartX"/> and <see cref="StartY"/>.
        /// </summary>
		public static IEnumerable<Int64> ReverseItems
		{
			get
			{
                return UnsortedItems.Distinct().OrderByDescending(x => x);
			}
		}

        private static IEnumerable<Int64> UnsortedItems
        {
            get
            {
                for (Int64 x = Math.Max(StartX, 1); x <= XFactor; x++)
                {
                    for (Int64 y = Math.Max(StartY, 1); y <= YFactor; y++)
                    {
                        yield return (x * y);
                    }
                }
            }
        }
	}
}