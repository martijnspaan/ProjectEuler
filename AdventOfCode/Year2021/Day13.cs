using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Extensions;
using Mathematics.Extentions;

namespace AdventOfCode.Year2021
{
    class Day13 : IDay
    {
        public string ExampleInput => "6,10\n0,14\n9,10\n0,3\n10,4\n4,11\n6,0\n6,12\n4,1\n0,13\n10,12\n3,4\n3,0\n8,4\n1,10\n2,14\n8,10\n9,0\n\nfold along y=7\nfold along x=5";

        public long SolvePart1(string puzzleInput)
        {
            var (dotMatrix, foldLines) = puzzleInput.ToDotMatrix();

            var line = foldLines.First();

            foreach (var (x, y) in dotMatrix.Positions())
            {
                if (dotMatrix[x, y] > 0)
                {
                    if (x > line.X && line.X > 0)
                    {
                        dotMatrix[x, y] = 0;
                        dotMatrix[x - (x - line.X) * 2, y] = 1;
                    }
                    else if (y > line.Y && line.Y > 0)
                    {
                        dotMatrix[x, y] = 0;
                        dotMatrix[x, y - (y - line.Y) * 2] = 1;
                    }
                }
            }

            return dotMatrix.Positions().Count(pos => dotMatrix.At(pos) == 1);
        }

        public long SolvePart2(string puzzleInput)
        {
            var (dotMatrix, foldLines) = puzzleInput.ToDotMatrix();

            int finalWidth = dotMatrix.GetLength(0);
            int finalHeight = dotMatrix.GetLength(1);

            foldLines.ForEach(line =>
            {
                foreach (var (x, y) in dotMatrix.Positions())
                {
                    if (dotMatrix[x, y] > 0)
                    {
                        if (x > line.X && line.X > 0)
                        {
                            dotMatrix[x, y] = 0;
                            dotMatrix[x - (x - line.X) * 2, y] = 1;

                            finalWidth = finalWidth - (finalWidth - line.X);
                        }
                        else if (y > line.Y && line.Y > 0)
                        {
                            dotMatrix[x, y] = 0;
                            dotMatrix[x, y - (y - line.Y) * 2] = 1;

                            finalHeight = finalHeight - (finalHeight - line.Y);
                        }
                    }
                }
            });

            dotMatrix.WriteToConsole(finalWidth, finalHeight);

            return 1;
        }
    }
}

namespace AdventOfCode.Extensions
{
    public static class Day13StringExtensions
    {
        public static (int[,], ICollection<(int X, int Y)>) ToDotMatrix(this string input)
        {
            var puzzleParts = input.Split("\n\n");

            var dots = puzzleParts[0].Split('\n').Select(line => (X: int.Parse(line.Split(',')[0]), Y: int.Parse(line.Split(',')[1]))).ToList();

            int width = dots.Max(dot => dot.X) + 1;
            int height = dots.Max(dot => dot.Y) + 1;

            int[,] dotMatrix = new int[width, height];
            foreach (var dot in dots)
            {
                dotMatrix[dot.X, dot.Y] = 1;
            }

            var foldLines = puzzleParts[1].Split('\n').Select(line =>
            {
                var xMatch = Regex.Match(line, @"x=(\d+)");
                var yMatch = Regex.Match(line, @"y=(\d+)");

                return (X: xMatch.Success ? int.Parse(xMatch.Groups[1].Value) : 0, Y: yMatch.Success ? int.Parse(yMatch.Groups[1].Value) : 0);
            }).ToList();

            return (dotMatrix, foldLines);
        }
    }

    public static partial class MultiDimensionArrayExtensions
    {
        public static void WriteToConsole(this int[,] matrix, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(matrix[x, y] > 0 ? '#' : '.');
                }
                Console.WriteLine();
            }
        }
    }
}