using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2021.Day5
{
    class Part1
    {
        public static object Solve()
        {
            List<Line> lines = File.ReadAllLines(@"Year2021\input\Day5.txt").ToLines();

            int width = lines.Max(line => Math.Max(line.From.X, line.To.X));
            int height = lines.Max(line => Math.Max(line.From.Y, line.To.Y));

            int overlappingLines = 0;
            for (int y = 0; y <= height; y++)
            {
                for (int x = 0; x <= width; x++)
                {
                    if (lines.Count(line => line.Includes(x, y)) >= 2)
                        overlappingLines++;
                }
            }

            return overlappingLines;
        }
    }
    
    class Part2
    {
        public static object Solve()
        {
            List<Line> lines = File.ReadAllLines(@"Year2021\input\Day5.txt").ToLines(includeDiagonal: true);

            int width = lines.Max(line => Math.Max(line.From.X, line.To.X));
            int height = lines.Max(line => Math.Max(line.From.Y, line.To.Y));

            int overlappingLines = 0;
            for (int y = 0; y <= height; y++)
            {
                for (int x = 0; x <= width; x++)
                {
                    if (lines.Count(line => line.Includes(x, y)) >= 2)
                        overlappingLines++;
                }
            }

            return overlappingLines;
        }
    }
    public static class LineExtensions
    {
        public static List<Line> ToLines(this string[] input, bool includeDiagonal = false)
        {
            return input.Select(lineInput => new Line(lineInput))
                .Where(line => includeDiagonal || line.IsStraight()).ToList();
        }
    }

    public class Line
    {
        public readonly Point From;
        public readonly Point To;

        private readonly Regex _matcher = new(@"(?<x1>\d{1,3}),(?<y1>\d{1,3}) -> (?<x2>\d{1,3}),(?<y2>\d{1,3})", RegexOptions.Compiled);

        public Line(string input)
        {
            Match match = _matcher.Match(input);

            From = new Point(int.Parse(match.Groups["x1"].Value), int.Parse(match.Groups["y1"].Value));
            To = new Point(int.Parse(match.Groups["x2"].Value), int.Parse(match.Groups["y2"].Value));
        }
        public bool IsStraight()
        {
            return From.X == To.X || From.Y == To.Y;
        }

        public bool Includes(int x, int y)
        {
            if (From.X == To.X && (x == From.X || x == To.X))
            {
                if (y >= Math.Min(From.Y, To.Y) && y <= Math.Max(From.Y, To.Y))
                    return true;
            }
            
            else if (From.Y == To.Y && (y == From.Y || y == To.Y))
            {
                if (x >= Math.Min(From.X, To.X) && x <= Math.Max(From.X, To.X))
                    return true;
            }

            else
            {
                if (From.X < To.X && From.Y < To.Y)
                {
                    // to lower right
                    int xi = From.X;
                    int yi = From.Y;
                    do
                    {
                        if (xi == x && yi == y)
                            return true;

                        xi++;
                        yi++;
                    } while (xi <= To.X && yi <= To.Y);
                }

                else if (From.X < To.X && From.Y > To.Y)
                {
                    // to upper right
                    int xi = From.X;
                    int yi = From.Y;
                    do
                    {
                        if (xi == x && yi == y)
                            return true;

                        xi++;
                        yi--;
                    } while (xi <= To.X && yi >= To.Y);
                }
                else if (From.X > To.X && From.Y < To.Y)
                {
                    // to lower left
                    int xi = From.X;
                    int yi = From.Y;
                    do
                    {
                        if (xi == x && yi == y)
                            return true;

                        xi--;
                        yi++;
                    } while (xi >= To.X && yi <= To.Y);
                }

                else if (From.X > To.X && From.Y > To.Y)
                {
                    // to upper left
                    int xi = From.X;
                    int yi = From.Y;
                    do
                    {
                        if (xi == x && yi == y)
                            return true;

                        xi--;
                        yi--;
                    } while (xi >= To.X && yi >= To.Y);
                }
            }

            return false;
        }
    }
}

namespace AdventOfCode.Extensions
{
}