using System.Collections.Generic;
using AdventOfCode.Extensions;

namespace AdventOfCode.Year2021
{
    class Day12 : IDay
    {
        public string ExampleInput => "start-A\nstart-b\nA-c\nA-b\nb-d\nA-end\nb-end";

        public long SolvePart1(string puzzleInput)
        {
            IDictionary<string, ICollection<string>> map = puzzleInput.PlotMap();

            return FindRoutes(map, "start", "", null);
        }

        public long SolvePart2(string puzzleInput)
        {
            IDictionary<string, ICollection<string>> map = puzzleInput.PlotMap();

            return FindRoutes(map, "start");
        }

        private int FindRoutes(IDictionary<string, ICollection<string>> map, string current, string route = "", bool? visitedSmallCave = false)
        {
            int routes = 0;

            route += $",{current}";

            var possibleCaves = map[current];
            foreach (var next in possibleCaves)
            {
                if (next == "end")
                    routes++;
                else if (route.Contains("," + next.ToLower()) is true)
                {
                    if (visitedSmallCave is false && next != "start")
                        routes += FindRoutes(map, next, route, true);
                }
                else
                    routes += FindRoutes(map, next, route, visitedSmallCave);
            }

            return routes;
        }
    }
}

namespace AdventOfCode.Extensions
{
    public static partial class StringExtensions
    {
        public static IDictionary<string, ICollection<string>> PlotMap(this string input)
        {
            IDictionary<string, ICollection<string>> map = new Dictionary<string, ICollection<string>>();

            foreach (var connection in input.Split('\n'))
            {
                var caves = connection.Split('-');
                if (map.ContainsKey(caves[0]) is not true)
                    map.Add(caves[0], new List<string>());
                if (map.ContainsKey(caves[1]) is not true)
                    map.Add(caves[1], new List<string>());

                map[caves[0]].AddDistinct(caves[1]);
                map[caves[1]].AddDistinct(caves[0]);
            }

            return map;
        }
    }

    public static partial class CollectionExtensions
    {
        public static ICollection<T> AddDistinct<T>(this ICollection<T> source, T value)
        {
            if (source.Contains(value) is not true)
                source.Add(value);
            return source;
        }
    }
}