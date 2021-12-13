using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Extensions;
using Mathematics.Extentions;

namespace AdventOfCode.Year2021
{
    class Day11 : IDay
    {
        public string ExampleInput => "5483143223\n2745854711\n5264556173\n6141336146\n6357385478\n4167524645\n2176841721\n6882881134\n4846848554\n5283751526";

        public List<(int X, int Y)> Offsets = new()
        {
            (0, -1),
            (1, -1),
            (1, 0),
            (1, 1),
            (0, 1),
            (-1, 1),
            (-1, 0),
            (-1, -1),
        };

        public long SolvePart1(string puzzleInput)
        {
            int[,] input = puzzleInput.ToIntMatrix();

            long flashes = 0;

            List<(int X, int Y)> hasFlashed = new();

            for (int i = 0; i < 100; i++)
            {
                int newFlashes;

                input.Positions().ForEach(pos => { input[pos.X, pos.Y]++; });

                do
                {
                    newFlashes = 0;

                    input.Positions().ForEach(pos => {
                        if (hasFlashed.Contains(pos))
                            return;

                        if (input.At(pos) > 9)
                        {
                            newFlashes++;
                            hasFlashed.Add(pos);

                            Offsets.Select(offset => (X: pos.X + offset.X, Y: pos.Y + offset.Y))
                                .Where(pos => input.Includes(pos))
                                .ForEach(pos => input[pos.X, pos.Y]++);
                        }
                    });

                } while (newFlashes != 0);

                foreach (var pos in hasFlashed)
                {
                    input.Set(pos, 0);
                }
                flashes += hasFlashed.Count;
                hasFlashed = new();
            }

            return flashes;
        }

        public long SolvePart2(string puzzleInput)
        {
            int[,] input = puzzleInput.ToIntMatrix();

            long flashes = 0;

            List<(int X, int Y)> hasFlashed = new ();

            for (int i = 1; i < 1000; i++)
            {
                int newFlashes;

                input.Positions().ForEach(pos => { input[pos.X, pos.Y]++; });

                do
                {
                    newFlashes = 0;

                    input.Positions().ForEach(pos => {
                        if (hasFlashed.Contains(pos))
                            return;

                        if (input.At(pos) > 9)
                        {
                            newFlashes++;
                            hasFlashed.Add(pos);

                            Offsets.Select(offset => (X: pos.X + offset.X, Y: pos.Y + offset.Y))
                                .Where(pos => input.Includes(pos))
                                .ForEach(pos => input[pos.X, pos.Y]++);
                        }
                    });

                } while (newFlashes != 0);

                if (hasFlashed.Count == 100)
                    return i;

                foreach (var pos in hasFlashed)
                {
                    input.Set(pos, 0);
                }
                flashes += hasFlashed.Count;
                hasFlashed = new();
            }

            return flashes;
        }
    }
}

namespace AdventOfCode.Extensions
{
    public static partial class MultiDimensionArrayExtensions
    {
        public static bool Includes<T>(this T[,] matrix, (int X, int Y) position)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            return position.X >= 0 && position.X < width && position.Y >= 0 && position.Y < height;
        }

        public static IEnumerable<(int X, int Y)> Positions<T>(this T[,] matrix)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    yield return (x, y);
                }
            }
        }

        public static T At<T>(this T[,] matrix, (int X, int Y) position)
        {
            return matrix[position.X, position.Y];
        }

        public static void Set<T>(this T[,] matrix, (int X, int Y) position, T value)
        {
            matrix[position.X, position.Y] = value;
        }
    }
}