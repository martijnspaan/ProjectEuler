using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Mathematics.Common;

namespace Mathematics.Extentions
{
	public static class List
	{
		/// <summary>
		/// Returns an infinite list of T using the specified generator.
		/// </summary>
		/// <typeparam name="T">The type of object to return.</typeparam>
		/// <param name="seed">The first item to return.</param>
		/// <param name="generator">Generator function iterate to each next item.</param>
		public static IEnumerable<T> Infinite<T>(T seed, Func<T, T> generator)
		{
			// include seed in the sequence
			yield return seed;

			T current = seed;

			// now continue the sequence
			while (true)
			{
				current = generator(current);
				yield return current;
			}
		}
	}

    public static class EnumerableExtensionMethods
    {
		private static readonly Hashtable CachedLists = new Hashtable();
		public static IList<T> ToCached<T>(this IEnumerable<T> enumerable)
		{
			return enumerable.ToCached("default");
		}
		public static IList<T> ToCached<T>(this IEnumerable<T> enumerable, String cacheName)
		{
			cacheName = cacheName + typeof(T).Name;

			// If the cached list does not exist, create it
			if (!CachedLists.ContainsKey(cacheName))
			{
				CachedLists.Add(cacheName, enumerable.ToList());
			}

			// If the available cached list is of a different type, overwrite it
			if (!(CachedLists[cacheName] is IList<T>))
			{
				CachedLists[cacheName] = enumerable.ToList();
			}

			// Return the cached list
			  return (IList<T>)CachedLists[cacheName];
		}

        /// <summary>
        /// Performs the specified action for all members of the enumeration list and returns the items.
        /// </summary>
        /// <typeparam name="T">The type of the input objects.</typeparam>
        /// <param name="enumberable">The enumerable list.</param>
        /// <param name="action">The action to perform.</param>
		public static IEnumerable<T> Each<T>(this IEnumerable<T> enumberable, Action<T> action)
        {
            foreach (var item in enumberable)
            {
                action(item);
            	yield return item;
            }
        }

		/// <summary>
		/// Performs the specified action for all members of the enumeration list.
		/// </summary>
		/// <typeparam name="T">The type of the input objects.</typeparam>
		/// <param name="enumberable">The enumerable list.</param>
		/// <param name="action">The action to perform.</param>
		public static void ForEach<T>(this IEnumerable<T> enumberable, Action<T> action)
		{
			foreach (var item in enumberable)
			{
				action(item);
			}
		}

        /// <summary>
        /// Checks whether a collection is the same as another collection
        /// </summary>
        /// <param name="value">The current instance object</param>
        /// <param name="compareList">The collection to compare with</param>
        /// <param name="comparer">The comparer object to use to compare each item in the collection.  If null uses EqualityComparer(T).Default</param>
        /// <returns>True if the two collections contain all the same items in the same order</returns>
        public static bool IsEqualTo<TSource>(this IEnumerable<TSource> value, IEnumerable<TSource> compareList, IEqualityComparer<TSource> comparer)
        {
            if (value == compareList)
				return true;
            if (value == null || compareList == null)
				return false;

			if (comparer == null)
			{
				comparer = EqualityComparer<TSource>.Default;
			}

			IEnumerator<TSource> enumerator1 = value.GetEnumerator();
			IEnumerator<TSource> enumerator2 = compareList.GetEnumerator();

			bool enum1HasValue = enumerator1.MoveNext();
			bool enum2HasValue = enumerator2.MoveNext();

			try
			{
				while (enum1HasValue && enum2HasValue)
				{
					if (!comparer.Equals(enumerator1.Current, enumerator2.Current))
					{
						return false;
					}

					enum1HasValue = enumerator1.MoveNext();
					enum2HasValue = enumerator2.MoveNext();
				}

				return !(enum1HasValue || enum2HasValue);
			}
			finally
			{
				enumerator1.Dispose();
				enumerator2.Dispose();
			}
        }

        /// <summary>
        /// Checks whether a collection is the same as another collection
        /// </summary>
        /// <param name="value">The current instance object</param>
        /// <param name="compareList">The collection to compare with</param>
        /// <returns>True if the two collections contain all the same items in the same order</returns>
        public static bool IsEqualTo<TSource>(this IEnumerable<TSource> value, IEnumerable<TSource> compareList)
        {
            return IsEqualTo(value, compareList, null);
        }

        /// <summary>
        /// Checks whether a collection is the same as another collection
        /// </summary>
        /// <param name="value">The current instance object</param>
        /// <param name="compareList">The collection to compare with</param>
        /// <returns>True if the two collections contain all the same items in the same order</returns>
        public static bool IsEqualTo(this IEnumerable value, IEnumerable compareList)
        {
            return IsEqualTo(value.OfType<object>(), compareList.OfType<object>());
        }

		public static TSource MaxItem<TSource>(this IEnumerable<TSource> value, Func<TSource,Int32> selector)
		{
			TSource maxItem = default(TSource);
			foreach (var source in value)
			{
				if ( maxItem == null || selector(source) > selector(maxItem) )
				{
					maxItem = source;
				}
			}
			return maxItem;
		}

		public static IEnumerable<TSource> MatrixList<TSource>(this IEnumerable<TSource> x, Func<TSource, TSource, TSource> op)
		{
			return x.MatrixList(x, op, true);
		}

		public static IEnumerable<TSource> MatrixList<TSource>(this IEnumerable<TSource> x, IEnumerable<TSource> y, Func<TSource, TSource, TSource> op)
		{
			return x.MatrixList(y, op, true);
		}

		public static IEnumerable<TSource> MatrixList<TSource>(this IEnumerable<TSource> x, IEnumerable<TSource> y, Func<TSource,TSource,TSource> op, bool synchrone)
		{
			foreach (var sourceX in x)
			{
				foreach (var sourceY in y)
				{
					yield return op(sourceX, sourceY);
				}
			}

			if (!synchrone)
			{
				foreach (var sourceY in y)
				{
					foreach (var sourceX in x)
					{
						yield return op(sourceY, sourceX);
					}
				}
			}
		}

		public static IEnumerable<Int64> CircularList(this Int64 source)
		{
			return source.ToString().CircularList().Select(x => x.ToNumber());
		}

		public static IEnumerable<String> CircularList(this IEnumerable<Int64> source)
		{
			return source.Select(x => ((char)(x + '0'))).CircularList();
		}

		public static IEnumerable<String> CircularList(this IEnumerable<char> source)
		{
			return Permutation.Calc(true, source.ToArray());
		}

		public static IEnumerable<Int64> PermutationsList(this Int64 source)
		{
			return source.ToString().PermutationsList().Select(x => x.ToNumber());
		}

		public static IEnumerable<String> PermutationsList(this IEnumerable<Int64> source)
		{
			return source.Select(x => ((char) (x + '0'))).PermutationsList();
		}

		public static IEnumerable<String> PermutationsList(this IEnumerable<char> source)
		{
			return Permutation.Calc(false, source.ToArray());
		}
    }
}
