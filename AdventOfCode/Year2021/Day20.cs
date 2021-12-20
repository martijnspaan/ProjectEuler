using System;
using System.Linq;
using System.Runtime.CompilerServices;
using AdventOfCode.Extensions;

namespace AdventOfCode.Year2021
{
    class Day20 : IDay
    {
        public string ExampleInput => "..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#\n\n#..#.\n#....\n##..#\n..#..\n..###";

        public long SolvePart1(string puzzleInput)
        {
            var input = puzzleInput.Split("\n\n");

            string algorithm = input[0];

            string[] imageLines = input[1].Split('\n');

            int offset = 8;

            int height = imageLines.Length;
            int width = imageLines.First().Length;

            bool[,] matrix = new bool[width + 2 * offset, height + 2 * offset];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    matrix[x + offset, y + offset] = imageLines[y][x] == '#';
                }
            }

            for (int i = 0; i < 2; i++)
            {
                int outside = 0;
                if (algorithm[0] == '#')
                    outside = i % 2;

                matrix = Enhance(matrix, algorithm, outside);
            }

            return matrix.OfType<bool>().Count(x => x);
        }

        private bool[,] Enhance(bool[,] matrix, string algorithm, int outside)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            var newMatrix = new bool[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    string binary = string.Empty;
                    binary += matrix.Includes((x - 1, y - 1)) ? matrix[x - 1, y - 1] ? 1 : 0 : outside;
                    binary += matrix.Includes((x, y - 1)) ? matrix[x, y - 1] ? 1 : 0 : outside;
                    binary += matrix.Includes((x + 1, y - 1)) ? matrix[x + 1, y - 1] ? 1 : 0 : outside;
                    binary += matrix.Includes((x - 1, y)) ? matrix[x - 1, y] ? 1 : 0 : outside;
                    binary += matrix.Includes((x, y)) ? matrix[x, y] ? 1 : 0 : outside;
                    binary += matrix.Includes((x + 1, y)) ? matrix[x + 1, y] ? 1 : 0 : outside;
                    binary += matrix.Includes((x - 1, y + 1)) ? matrix[x - 1, y + 1] ? 1 : 0 : outside;
                    binary += matrix.Includes((x, y + 1)) ? matrix[x, y + 1] ? 1 : 0 : outside;
                    binary += matrix.Includes((x + 1, y + 1)) ? matrix[x + 1, y + 1] ? 1 : 0 : outside;

                    newMatrix[x, y] = IsLightPixel(Convert.ToInt32(binary, 2), algorithm);
                }
            }

            return newMatrix;
        }

        private bool IsLightPixel(int value, string algorithm)
        {
            return algorithm[value] == '#';
        }

        public long SolvePart2(string puzzleInput)
        {
            var input = puzzleInput.Split("\n\n");

            string algorithm = input[0];

            string[] imageLines = input[1].Split('\n');

            int offset = 55;

            int height = imageLines.Length;
            int width = imageLines.First().Length;

            bool[,] matrix = new bool[width + 2 * offset, height + 2 * offset];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    matrix[x + offset, y + offset] = imageLines[y][x] == '#';
                }
            }

            for (int i = 0; i < 50; i++)
            {
                int outside = 0;
                if (algorithm[0] == '#')
                    outside = i % 2;
                matrix = Enhance(matrix, algorithm, outside);
            }

            return matrix.OfType<bool>().Count(x => x);
        }
    }
}