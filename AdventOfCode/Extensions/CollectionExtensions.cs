using System.Collections.Generic;

namespace AdventOfCode.Extensions
{
    public static class Extensions
    {
        public static void Deconstruct<T>(this IList<T> list, out T first)
        {
            first = list.Count > 0 ? list[0] : default;
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second)
        {
            list.Deconstruct(out first);
            second = list.Count > 1 ? list[1] : default;
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out T third)
        {
            list.Deconstruct(out first, out second);
            third = list.Count > 2 ? list[2] : default;
        }
    }
}
