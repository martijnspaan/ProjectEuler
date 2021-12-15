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

            // Init x = 0 and y = 0 lines
            for (int y = 1; y < height; y++)
            {
                matrix[0, y] += matrix[0, y - 1];
            }
            for (int x = 1; x < width; x++)
            {
                matrix[x, 0] += matrix[x - 1, 0];
            }

            // Iterate rest of the matrix with x > 0 and y > 0
            for (int i = 1; i < width; i++)
            {
                for (int y = i; y < height; y++)
                {
                    matrix[i, y] += Math.Min(matrix[i, y - 1], matrix[i - 1, y]);
                }

                for (int x = i + 1; x < width; x++)
                {
                    matrix[x, i] += Math.Min(matrix[x - 1, i], matrix[x, i - 1]);
                }
            }

            return matrix[width-1, height-1];
        }
    }
}