using System;
using System.Linq;
using System.Collections.Generic;
using Oyster.Math;

namespace Mathematics.Lists
{
	/// <summary>
	/// Represents a enumerable list of al exponentiations for a mathematical table, starting at <see cref="StartX"/> and <see cref="StartY"/>.
	/// </summary>
	public static class MathematicalPowerTableList
	{
		/// <summary>
		/// Specifies the first integer.
		/// </summary>
		public static Int64 First { get; set;}

        /// <summary>
        /// Specifies the last integer.
        /// </summary>
        public static Int64 Last { get; set; }

		/// <summary>
        /// Gets a list of <see cref="Int64"/> natural numbers, which is the exponentiation of X and Y, starting with <see cref="StartX"/> and <see cref="StartY"/>.
		/// </summary>
		public static IEnumerable<double> Items
		{
			get
			{
                return UnsortedItems.Distinct().OrderBy(x => x);
			}
		}

        /// <summary>
        /// Gets a reversed list of <see cref="Int64"/> natural numbers, which is the product of X and Y, starting with <see cref="StartX"/> and <see cref="StartY"/>.
        /// </summary>
		public static IEnumerable<double> ReverseItems
		{
			get
			{
                return UnsortedItems.Distinct().OrderByDescending(x => x);
			}
		}

        private static IEnumerable<double> UnsortedItems
        {
            get
            {
                for (Int64 x = First; x <= Last; x++)
                {
                    for (Int64 y = Math.Max(First, 1); y <= Last; y++)
                    {
						yield return (Math.Pow(x, y));
                    }
                }
            }
        }
	}
}