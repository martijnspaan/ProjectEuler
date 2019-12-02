using System;
using System.Collections.Generic;

namespace Mathematics.Lists
{
	/// <summary>
	/// Represents a enumerable list of infinite <see cref="DateTime"/> objects, starting at <see cref="StartDate"/>.
	/// </summary>
	public static class InfiniteDateList
	{
		/// <summary>
		/// Specifies the start date from where to start the infinite list.
		/// </summary>
		public static DateTime StartDate { get; set; }

		private static Int32 _step = 1;

		/// <summary>
		/// Gets or sets the amount that is used to increment or decrement each iteration.
		/// </summary>
		public static Int32 Step
		{
			get { return _step; }
			set { _step = value; }
		}

		/// <summary>
		/// Gets an infinite long list of <see cref="DateTime"/> objects, starting with <see cref="StartDate"/> and incrementing each month.
		/// </summary>
		/// <remarks>
		/// Note: reversing this enumeration or instantiating it to a list using Linq will result in a infinite loop.
		/// This can be worked around by first using Take() to specify a maximum number of items.
		/// </remarks>
		public static IEnumerable<DateTime> Months
		{
			get
			{
				DateTime curDate = StartDate;
				do
				{
					curDate = curDate.AddMonths(Step);
					yield return curDate;
				} while (true);
			}
		}

		/// <summary>
		/// Gets an infinite long list of <see cref="DateTime"/> objects, starting with <see cref="StartDate"/> anbd incrementing each year.
		/// </summary>
		/// <remarks>
		/// Note: reversing this enumeration or instantiating it to a list using Linq will result in a infinite loop.
		/// This can be worked around by first using Take() to specify a maximum number of items.
		/// </remarks>
		public static IEnumerable<DateTime> Years
		{
			get
			{
				DateTime curDate = StartDate;
				do
				{
					curDate = curDate.AddYears(Step);
					yield return curDate;
				} while (true);
			}
		}

		/// <summary>
		/// Gets an infinite long list of <see cref="DateTime"/> objects, starting with <see cref="StartDate"/> anbd incrementing each year.
		/// </summary>
		/// <remarks>
		/// Note: reversing this enumeration or instantiating it to a list using Linq will result in a infinite loop.
		/// This can be worked around by first using Take() to specify a maximum number of items.
		/// </remarks>
		public static IEnumerable<DateTime> Days
		{
			get
			{
				DateTime curDate = StartDate;
				do
				{
					curDate = curDate.AddDays(Step);
					yield return curDate;
				} while (true);
			}
		}
	}
}