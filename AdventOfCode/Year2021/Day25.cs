using System;
using System.Collections.Generic;
using AdventOfCode.Extensions;
using Mathematics.Extentions;

namespace AdventOfCode.Year2021
{
    class Day25 : IDay
    {
        public string ExampleInput => "v...>>.vv>\n.vv>>.vv..\n>>.>v>...v\n>>v>>.>.v.\nv>v.vv.v..\n>.>>..v...\n.vv..>.>v.\nv.v..>>v.v\n....v..v.>";

        public long SolvePart1(string puzzleInput)
        {
            (char[,] matrix, int width, int height) = puzzleInput.ToCucumberMatrix();

            int step = 0;

            bool anyHasMoved;
            
            List<(int X, int Y, int toX, int toY)> canMove;

            do
            {
                //Print(matrix, width, height);

                step++;

                anyHasMoved = false;
                canMove = new();

                foreach (var (x, y) in matrix.Positions())
                {
                    if (matrix[x,y] != '>') continue;
                    
                    if (x >= width - 1 && matrix[0, y] == '.')
                        canMove.Add((x, y, 0, y));
                    else if (x < width - 1 && matrix[x + 1, y] == '.')
                        canMove.Add((x, y, x + 1, y));
                }

                foreach (var (x, y, toX, toY) in canMove)
                {
                    matrix[x, y] = '.';
                    matrix[toX, toY] = '>';
                }

                anyHasMoved |= canMove.Count > 0;

                canMove = new();

                foreach (var (x, y) in matrix.Positions())
                {
                    if (matrix[x, y] != 'v') continue;
                    
                    if (y >= height - 1 && matrix[x, 0] == '.')
                        canMove.Add((x, y, x, 0));
                    else if (y < height - 1 && matrix[x, y + 1] == '.')
                        canMove.Add((x, y, x, y + 1));
                }

                foreach (var (x, y, toX, toY) in canMove)
                {
                    matrix[x, y] = '.';
                    matrix[toX, toY] = 'v';
                }

                anyHasMoved |= canMove.Count > 0;

            } while (anyHasMoved);

            return step;
        }

        public void Print(char[,] matrix, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(matrix[x, y]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public long SolvePart2(string puzzleInput)
        {
            (char[,] matrix, int width, int height) = puzzleInput.ToCucumberMatrix();

            return 0;
        }
    }
}

namespace AdventOfCode.Extensions
{
    public static class Day25Etensions
    {
        public static (char[,], int, int) ToCucumberMatrix(this string input)
        {
            var lines = input.Split('\n');

            int height = lines.Length;
            int width = lines[0].Length;

            char[,] matrix = new char[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    matrix[x, y] = lines[y][x];
                }
            }

            return (matrix, width, height);
        }
    }
}