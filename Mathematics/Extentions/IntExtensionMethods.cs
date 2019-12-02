using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Mathematics.Lists;
using Oyster.Math;

namespace Mathematics.Extentions
{
	public static class IntExtensionMethods
	{
		public static IntX Sum(this IEnumerable<IntX> source)
		{
			return source.Aggregate<IntX, IntX>(0, (current, value) => current + value);
		}
		public static IntX SumDigits(this IntX source)
		{
			return Digits(source).Aggregate(0, (current, value) => current + value);
		}
		public static double SquareRoot(this Int64 source)
		{
			return Math.Sqrt(source);
		}
		public static double SquareRoot(this IntX source)
		{
			return Math.Sqrt((Int64)source);
		}
		public static string FractionRecurringCycle2(this long source)
		{
			long rest = 1;
			for (int i = 0; i < source; i++) rest = (rest * 10) % source;
			long r0 = rest;
			do
			{
				rest = (rest * 10) % source;
			} while (rest != r0);
			return rest.ToString();
		}

		public static string FractionRecurringCycle(this long source)
		{
			bool foundStart = false;
			String cycle = String.Empty;
			long numerator = 1;
			long devisor = source;
			long remainder = numerator % source;
			var foundNumerators = new List<long>();
			while (remainder != 0)
			{
				if (numerator / devisor > 0)
				{
					foundNumerators.Add(numerator);
					cycle += (numerator / devisor);
					numerator = remainder * 10;
				}
				else
				{
					numerator *= 10;
				}

				remainder = numerator % devisor;

				if (foundNumerators.Contains(numerator))
				{
					if (foundStart)
						return cycle;

					foundStart = true;
					cycle = String.Empty;
					foundNumerators.Clear();
				}

			}
			return String.Empty;
		}

		public static IEnumerable<int> Digits(this IntX source)
		{
			return source.ToString().Select(x => Convert.ToInt32("" + x));
		}

		public static bool IsPalindrome(this Int64 source)
		{
			return source.ToString().IsPalindrome();
		}

		public static bool IsPalindrome(this String source)
		{
			return source.IsEqualTo(source.Reverse());
		}

		public static bool IsReversableNumber(this Int64 source)
		{
		    if (source.ToString().EndsWith("0") || source.AllDigitsAreEven())
		        return false;

			var reversedSource = Int64.Parse(new string(source.ToString().Reverse().ToArray()));
		    var isReversableNumber = (source + reversedSource).AllDigitsAreOdd();
		    return isReversableNumber;
		}

		public static bool IsEven(this double source)
		{
		    return Convert.ToInt64(source).IsEven();
		}

		public static bool IsOdd(this double source)
		{
            return Convert.ToInt64(source).IsOdd();
        }

		public static bool IsEven(this Int64 source)
		{
		    return source %2 == 0;
		}

		public static bool IsOdd(this Int64 source)
		{
            return source % 2 == 1;
        }

		public static bool AllDigitsAreOdd(this Int64 source)
		{
		    return source.ToString().All(x => x%2 == 1);
		}

		public static bool AllDigitsAreEven(this Int64 source)
		{
		    return source.ToString().All(x => x%2 == 1);
		}

		public static bool IsPandigital<T>(this T source)
		{
			String stringSource = source.ToString();
			return stringSource.Length == stringSource.Distinct().Count() &&
				   stringSource.Distinct().OrderByDescending(x => x).First().ToString() == stringSource.Length.ToString();
		}

		public static Int64 ProductConcatenate(this Int64 value, int maxLength)
		{
			Int64 productValue = 1;
			string concatedValue = string.Empty;
			while (true)
			{
				var newValue = (value*productValue++).ToString();
				if (newValue.Length + concatedValue.Length > maxLength)
					break;
				concatedValue += newValue;
			}
			
			return Convert.ToInt64(concatedValue);
		}

		public static Int64 Factorial(this Int32 source)
		{
			return ((Int64)source).Factorial();
		}

		public static Int64 Factorial(this Int64 source)
		{
			if (source == 0) return 1;
			return FiniteIntList.GetItems(1, source).Aggregate((result, item) => result *= item);
		}

		public static IEnumerable<Int64> ToIntList(this String source)
		{
			return source.Select(x => Int64.Parse(x.ToString()));
		}

		public static Int64 ToNumber(this IEnumerable<char> chars)
		{
			return Convert.ToInt64(new String(chars.ToArray()));
		}

		public static Int64 Product(this IEnumerable<Int64> values)
		{
			return values.Aggregate<long, long>(1, (product, value) => product * value);
		}

		public static Int64 Product(this IEnumerable<char> values)
		{
			return values.Select(x => Int64.Parse(x.ToString())).Product();
		}

		public static int FactorsCount(this Int64 x)
		{
			Int64 limit = x;
			int numberOfDivisors = 0;

			for (int i = 1; i < limit; ++i)
			{
				if (x % i == 0)
				{
					limit = x / i;
					numberOfDivisors++;
				}
			}

			return numberOfDivisors * 2;

		}

		public static bool IsNumber<T>(this T value)
		{
			int outValue;
			return Int32.TryParse(value.ToString(), out outValue);
		}

		public static bool IsAmicableNumber(this Int64 value)
		{
			var firstSum = value.ProperDevisors().Sum();
			return firstSum != value && firstSum.ProperDevisors().Sum() == value;
		}

		public static bool IsPerfectNumber(this Int64 value)
		{
			return value.ProperDevisors().Sum() == value;
		}

		public static bool IsDeficientNumber(this Int64 value)
		{
			return value.ProperDevisors().Sum() < value;
		}

		public static bool IsAbundantNumber(this Int64 value)
		{
			return value.ProperDevisors().Sum() > value;
		}

		public static IEnumerable<Int64> ProperDevisors(this Int64 value)
		{
			for (int i = 1; i <= value / 2; i++)
			{
				if (value % i == 0) yield return i;
			}
		}

		public static String WrittenNumber(this Int64 value)
		{
			var builder = new StringBuilder();
			Int64 current = value;

			AddTensWrittenNumber(ref current, builder, 1000000, "million");
			AddTensWrittenNumber(ref current, builder, 1000, "thousand");
			AddTensWrittenNumber(ref current, builder, 100, "hundred");

			if ((value > 100) && (value % 100 != 0))
			{
				builder.Append("and ");
			}

			AddWrittenNumber(ref current, builder, 90, "ninety");
			AddWrittenNumber(ref current, builder, 80, "eighty");
			AddWrittenNumber(ref current, builder, 70, "seventy");
			AddWrittenNumber(ref current, builder, 60, "sixty");
			AddWrittenNumber(ref current, builder, 50, "fifty");
			AddWrittenNumber(ref current, builder, 40, "forty");
			AddWrittenNumber(ref current, builder, 30, "thirty");
			AddWrittenNumber(ref current, builder, 20, "twenty");

			switch (current)
			{
				case 1:
					builder.AppendFormat("one");
					break;
				case 2:
					builder.AppendFormat("two");
					break;
				case 3:
					builder.AppendFormat("three");
					break;
				case 4:
					builder.AppendFormat("four");
					break;
				case 5:
					builder.AppendFormat("five");
					break;
				case 6:
					builder.AppendFormat("six");
					break;
				case 7:
					builder.AppendFormat("seven");
					break;
				case 8:
					builder.AppendFormat("eight");
					break;
				case 9:
					builder.AppendFormat("nine");
					break;
				case 10:
					builder.AppendFormat("ten");
					break;
				case 11:
					builder.AppendFormat("eleven");
					break;
				case 12:
					builder.AppendFormat("twelve");
					break;
				case 13:
					builder.AppendFormat("thirteen");
					break;
				case 14:
					builder.AppendFormat("fourteen");
					break;
				case 15:
					builder.AppendFormat("fifteen");
					break;
				case 16:
					builder.AppendFormat("sixteen");
					break;
				case 17:
					builder.AppendFormat("seventeen");
					break;
				case 18:
					builder.AppendFormat("eighteen");
					break;
				case 19:
					builder.AppendFormat("nineteen");
					break;

			}
			return builder.ToString();
		}

		private static void AddTensWrittenNumber(ref Int64 current, StringBuilder builder, Int64 range, String name)
		{
			if (current >= range)
			{
				builder.AppendFormat("{0} {1} ", (current / range).WrittenNumber(), name);
				current %= range;
			}
		}

		private static void AddWrittenNumber(ref Int64 current, StringBuilder builder, Int64 range, String name)
		{
			if (current >= range)
			{
				builder.AppendFormat("{0}{1}", name, (current % range == 0 ? String.Empty : "-"));
				current %= range;
			}
		}
	}
}