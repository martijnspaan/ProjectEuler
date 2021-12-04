using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;
using AdventOfCode.Extensions;

namespace AdventOfCode.Year2021.Day4
{
    public class Part1
    {
        public static object Solve()
        {
            int[] calledNumbers = { 68, 30, 65, 69, 5, 78, 41, 73, 55, 0, 76, 98, 79, 42, 37, 21, 9, 34, 56, 33, 64, 54, 24, 43, 15, 58, 61, 38, 12, 20, 4, 26, 87, 95, 94, 89, 83, 74, 97, 77, 67, 40, 63, 88, 19, 31, 81, 80, 60, 14, 18, 47, 93, 57, 17, 90, 84, 85, 48, 6, 91, 7, 86, 13, 51, 53, 8, 16, 23, 66, 36, 39, 32, 82, 72, 11, 52, 28, 62, 70, 59, 50, 1, 46, 96, 71, 35, 10, 25, 22, 27, 99, 29, 45, 44, 3, 75, 92, 49, 2 };

            List<BingoCard> bingoCards = File.ReadAllLines(@"Year2021\input\Day4.txt").ToBingoCards();

            foreach (int calledNumber in calledNumbers)
            {
                foreach (BingoCard card in bingoCards)
                {
                    card.MarkCalledNumber(calledNumber);

                    if (card.HasBingo())
                    {
                        return card.UncalledNumbers().Sum() * calledNumber;
                    }
                }
            }

            return 0;
        }
    }

    public class Part2
    {
        public static object Solve()
        {
            int[] calledNumbers = { 68, 30, 65, 69, 5, 78, 41, 73, 55, 0, 76, 98, 79, 42, 37, 21, 9, 34, 56, 33, 64, 54, 24, 43, 15, 58, 61, 38, 12, 20, 4, 26, 87, 95, 94, 89, 83, 74, 97, 77, 67, 40, 63, 88, 19, 31, 81, 80, 60, 14, 18, 47, 93, 57, 17, 90, 84, 85, 48, 6, 91, 7, 86, 13, 51, 53, 8, 16, 23, 66, 36, 39, 32, 82, 72, 11, 52, 28, 62, 70, 59, 50, 1, 46, 96, 71, 35, 10, 25, 22, 27, 99, 29, 45, 44, 3, 75, 92, 49, 2 };

            List<BingoCard> bingoCards = File.ReadAllLines(@"Year2021\input\Day4.txt").ToBingoCards();

            foreach (int calledNumber in calledNumbers)
            {
                foreach (BingoCard card in bingoCards)
                {
                    card.MarkCalledNumber(calledNumber);

                    if (bingoCards.Count == 1 && bingoCards.First().HasBingo())
                    {
                        return bingoCards.First().UncalledNumbers().Sum() * calledNumber;
                    }
                }

                bingoCards.RemoveAll(card => card.HasBingo());
            }

            return 0;
        }
    }

    public static class BingoExtensions
    {
        public static List<BingoCard> ToBingoCards(this string[] input)
        {
            return input.Split().Select(cardLines => new BingoCard(cardLines.ToArray())).ToList();
        }
    }

    public class BingoCard
    {
        private readonly int[,] _numbers;
        private readonly bool[,] _markedNumbers;

        public BingoCard(string[] cardInput)
        {
            var rows = cardInput.Length;
            var columns = cardInput.First().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

            _numbers = new int[rows, columns];
            _markedNumbers = new bool[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] lineNumbers = cardInput.ElementAt(row).Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int column = 0; column < lineNumbers.Length; column++)
                {
                    _numbers[row, column] = lineNumbers[column];
                }
            }
        }

        public bool HasBingo()
        {
            return _markedNumbers.AnyRow(row => row.All(called => called)) || _markedNumbers.AnyColumn(row => row.All(called => called));
        }

        public void MarkCalledNumber(int calledNumber)
        {
            var (row, column, found) = _numbers.First(number => number == calledNumber);
            if (found)
                _markedNumbers[column, row] = true;
        }

        public IEnumerable<int> UncalledNumbers()
        {
            return _numbers.Where((row, column) => _markedNumbers[row, column] == false);
        }
    }
}

namespace AdventOfCode.Extensions
{
    public static partial class MultiDimensionArrayExtensions
    {
        public static (int, int, bool) First<T>(this T[,] source, Func<T, bool> predicate)
        {
            for (int row = 0; row < source.GetLength(0); row++)
            {
                for (int column = 0; column < source.GetLength(1); column++)
                {
                    if (predicate(source[column, row]))
                    {
                        return (row, column, true);
                    }
                }
            }
            return (-1, -1, false);
        }

        public static bool AnyRow<T>(this T[,] source, Func<IEnumerable<T>, bool> predicate)
        {
            return Enumerable.Range(0, source.GetLength(0))
                .Any(row => predicate(source.GetRow(row)));
        }

        public static bool AnyColumn<T>(this T[,] source, Func<IEnumerable<T>, bool> predicate)
        {
            return Enumerable.Range(0, source.GetLength(1))
                .Any(column => predicate(source.GetColumn(column)));
        }

        public static IEnumerable<T> GetColumn<T>(this T[,] source, int column)
        {
            return Enumerable.Range(0, source.GetLength(0))
                .Select(row => source[row, column]);
        }

        public static IEnumerable<T> GetRow<T>(this T[,] source, int row)
        {
            return Enumerable.Range(0, source.GetLength(1))
                .Select(column => source[row, column]);
        }

        public static IEnumerable<T> Where<T>(this T[,] source, Func<int, int, bool> predicate)
        {
            for (int row = 0; row < source.GetLength(0); row++)
            {
                for (int column = 0; column < source.GetLength(1); column++)
                {
                    if (predicate(row, column))
                        yield return source[row, column];
                }
            }
        }
    }

    public static partial class StringExtensions
    {
        public static IEnumerable<IEnumerable<string>> Split(this IEnumerable<string> input, string separator = "")
        {
            List<string> group = new();
            foreach (var line in input)
            {
                if (line.Equals(separator) is false)
                    group.Add(line);
                else
                {
                    yield return group;
                    group = new();
                }
            }
        }
    }
}