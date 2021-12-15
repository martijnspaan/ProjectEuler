using System;
using AdventOfCode.Extensions;

namespace AdventOfCode.Year2021
{
    class Day15 : IDay
    {
        public string ExampleInput => "1163751742\n1381373672\n2136511328\n3694931569\n7463417111\n1319128137\n1359912421\n3125421639\n1293138521\n2311944581";

        public long SolvePart1(string puzzleInput)
        {
            int[,] input = puzzleInput.ToIntMatrix();

            return input.FindFastestPath();
        }

        public long SolvePart2(string puzzleInput)
        {
            int[,] input = puzzleInput.ToIntMatrix();

            int originalWidth = input.GetLength(0);
            int originalHeight = input.GetLength(1);

            int[,] maxInput = new int[originalWidth * 5, originalHeight * 5];

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int yo = 0; yo < originalWidth; yo++)
                    {
                        for (int xo = 0; xo < originalHeight; xo++)
                        {
                            maxInput[originalWidth * x + xo, originalHeight * y + yo] = input[xo,yo] + x + y;

                            if (maxInput[originalWidth * x + xo, originalHeight * y + yo] > 9)
                                maxInput[originalWidth * x + xo, originalHeight * y + yo] -= 9;
                        }
                    }
                }
            }

            return maxInput.FindFastestPath();
        }
    }
}

namespace AdventOfCode.Extensions
{
    public static partial class MultiDimensionArrayExtensions
    {
        public static int FindFastestPath(this int[,] matrix)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            matrix[0, 0] = 0;

            for (int v = 0; v < width; v++) // Iterate vertices
            {
                for (int y = v; y < height; y++) // Iterate each vertical from vertex
                {
                    if (y > 0) // skip (0,0)
                        matrix[v, y] += v == 0 ? matrix[v, y - 1] : Math.Min(matrix[v, y - 1], matrix[v - 1, y]); // increase with lowest neighbor above or left
                }

                for (int x = v + 1; x < width; x++) // Iterate each horizontal from vertex (skip first, handled vertically)
                {
                    matrix[x, v] += v == 0 ? matrix[x - 1, v] : Math.Min(matrix[x - 1, v], matrix[x, v - 1]); // increase with lowest neighbor above or left
                }
            }

            return matrix[width-1, height-1];
        }
    }
}