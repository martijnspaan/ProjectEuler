using System;
using System.Collections.Generic;
using System.Drawing;
using AdventOfCode.Extensions;
using Mathematics.Extentions;

namespace AdventOfCode.Year2021
{
    class Day11 : IDay
    {
        public string ExampleInput => "5483143223\n2745854711\n5264556173\n6141336146\n6357385478\n4167524645\n2176841721\n6882881134\n4846848554\n5283751526";

        public long SolvePart1(string puzzleInput)
        {
            int[,] input = puzzleInput.ToIntMatrix();

            long flashes = 0;

            int width = input.GetLength(0);
            int height = input.GetLength(1);

            List<Point> hasFlashed = new List<Point>();

            for (int i = 0; i < 100; i++)
            {
                int newFlashes;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        input[x, y]++;
                    }
                }

                do
                {
                    newFlashes = 0;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            if (hasFlashed.Contains(new Point(x, y)))
                                continue;
                            
                            if (input[x, y] > 9)
                            {
                                newFlashes++;
                                hasFlashed.Add(new Point(x, y));

                                if (x > 0) input[x - 1, y]++; // left
                                if (x < width-1) input[x + 1, y]++; // right
                                if (y > 0) input[x, y - 1]++; // up
                                if (y < height - 1) input[x, y + 1]++; // down

                                if (x > 0 && y > 0) input[x - 1, y - 1]++; // left-up
                                if (x < width - 1 && y > 0) input[x + 1, y - 1]++; // right-up
                                if (x > 0 && y < height - 1) input[x - 1, y + 1]++; // left-down
                                if (x < width - 1 && y < height - 1) input[x + 1, y + 1]++; // right-down
                            }
                        }
                    }

                } while (newFlashes != 0);

                foreach (var point in hasFlashed)
                {
                    input[point.X, point.Y] = 0;
                }
                flashes += hasFlashed.Count;
                hasFlashed = new List<Point>();
            }

            return flashes;
        }

        public long SolvePart2(string puzzleInput)
        {
            int[,] input = puzzleInput.ToIntMatrix();

            long flashes = 0;

            int width = input.GetLength(0);
            int height = input.GetLength(1);

            List<Point> hasFlashed = new List<Point>();

            for (int i = 1; i < 1000; i++)
            {
                int newFlashes;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        input[x, y]++;
                    }
                }

                do
                {
                    newFlashes = 0;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            if (hasFlashed.Contains(new Point(x, y)))
                                continue;

                            if (input[x, y] > 9)
                            {
                                newFlashes++;
                                hasFlashed.Add(new Point(x, y));

                                if (x > 0) input[x - 1, y]++; // left
                                if (x < width - 1) input[x + 1, y]++; // right
                                if (y > 0) input[x, y - 1]++; // up
                                if (y < height - 1) input[x, y + 1]++; // down

                                if (x > 0 && y > 0) input[x - 1, y - 1]++; // left-up
                                if (x < width - 1 && y > 0) input[x + 1, y - 1]++; // right-up
                                if (x > 0 && y < height - 1) input[x - 1, y + 1]++; // left-down
                                if (x < width - 1 && y < height - 1) input[x + 1, y + 1]++; // right-down
                            }
                        }
                    }

                } while (newFlashes != 0);

                if (hasFlashed.Count == 100)
                    return i;

                foreach (var point in hasFlashed)
                {
                    input[point.X, point.Y] = 0;
                }
                flashes += hasFlashed.Count;
                hasFlashed = new List<Point>();
            }

            return flashes;
        }
    }
}

namespace AdventOfCode.Extensions
{
}