using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode.Extensions;

namespace AdventOfCode.Year2021
{
    class Day9 : IDay
    {
        public string ExampleInput => "2199943210\n3987894921\n9856789892\n8767896789\n9899965678";

        public long SolvePart1(string puzzleInput)
        {
            int[,] heightMap = puzzleInput.ToIntMatrix();

            LowPoint[] lowPoints = heightMap.GetLowPoints().ToArray();

            return lowPoints.Select(lowPoint => lowPoint.Value).Sum() + lowPoints.Length;
        }

        public long SolvePart2(string puzzleInput)
        {
            int[,] heightMap = puzzleInput.ToIntMatrix();

            LowPoint[] lowPoints = heightMap.GetLowPoints().ToArray();

            return heightMap.GetBasinSizes(lowPoints).OrderByDescending(size => size).Take(3).Aggregate(1, (a, b)=> a * b);
        }
    }
}

namespace AdventOfCode.Extensions
{
    public static partial class StringExtensions
    {
        public static int[,] ToIntMatrix(this string input)
        {
            var heightMapLines = input.Split('\n');
            int[,] heightMap = new int[heightMapLines.First().Length, heightMapLines.Length];

            for (int y = 0; y < heightMap.GetLength(1); y++)
            {
                string line = heightMapLines[y];
                for (int x = 0; x < heightMap.GetLength(0); x++)
                {
                    heightMap[x, y] = int.Parse(line[x].ToString());
                }
            }

            return heightMap;
        }
    }

    public record LowPoint(int X, int Y, int Value);

    public static partial class MultiDimensionArrayExtensions
    {
        public static IEnumerable<LowPoint> GetLowPoints(this int[,] heightMap)
        {
            int width = heightMap.GetLength(0);
            int height = heightMap.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int current = heightMap[x, y];

                    if (x == 0 || current < heightMap[x - 1, y])
                        if (x == width - 1 || current < heightMap[x + 1, y])
                            if (y == 0 || current < heightMap[x, y - 1])
                                if (y == height - 1 || current < heightMap[x, y + 1])
                                    yield return new LowPoint(x, y, current);
                }
            }
        }

        public static IEnumerable<int> GetBasinSizes(this int[,] heightMap, LowPoint[] lowPoints)
        {
            foreach (LowPoint lowPoint in lowPoints)
            {
                var start = new Point(lowPoint.X, lowPoint.Y);
                yield return start.GetFlowPoints(heightMap, new List<Point> { start });
            }
        }
    }

    public static partial class LowPointExtensions
    {
        public static int GetFlowPoints(this Point lowPoint, int[,] heightMap, List<Point> basinPoints)
        {
            int width = heightMap.GetLength(0);
            int height = heightMap.GetLength(1);

            int flowPoints = 1;

            basinPoints.Add(lowPoint);

            Point next = new Point(lowPoint.X - 1, lowPoint.Y);
            if (next.X >= 0 && heightMap[next.X, next.Y] != 9 && basinPoints.Contains(next) is false)
            {
                flowPoints += next.GetFlowPoints(heightMap, basinPoints);
            }

            next = new Point(lowPoint.X + 1, lowPoint.Y);
            if (next.X < width && heightMap[next.X, next.Y] != 9 && basinPoints.Contains(next) is false)
            {
                flowPoints += next.GetFlowPoints(heightMap, basinPoints);
            }

            next = new Point(lowPoint.X, lowPoint.Y - 1);
            if (next.Y >= 0 && heightMap[next.X, next.Y] != 9 && basinPoints.Contains(next) is false)
            {
                flowPoints += next.GetFlowPoints(heightMap, basinPoints);
            }

            next = new Point(lowPoint.X, lowPoint.Y + 1);
            if (next.Y < height && heightMap[next.X, next.Y] != 9 && basinPoints.Contains(next) is false)
            {
                flowPoints += next.GetFlowPoints(heightMap, basinPoints);
            }

            return flowPoints;
        }
    }
}