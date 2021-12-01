using System.Linq;

namespace AdventOfCode.Extensions
{
    public static class StringExtensions
    {
        public static int[] ToIntArray(this string[] lines)
        {
            return lines.Select(int.Parse).ToArray();
        }
    }
}
