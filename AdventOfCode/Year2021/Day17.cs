using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Extensions;
using Mathematics.Extentions;

namespace AdventOfCode.Year2021
{
    class Day17 : IDay
    {
        public string ExampleInput => "target area: x=20..30, y=-10..-5";

        public Regex PuzzleRegex = new(@"x=(?<x1>[\-0-9]+)..(?<x2>[\-0-9]+), y=(?<y1>[\-0-9]+)..(?<y2>[\0-9]+)");

        public long SolvePart1(string puzzleInput)
        {
            var match = PuzzleRegex.Match(puzzleInput);
            int x1 = int.Parse(match.Groups["x1"].Value);
            int x2 = int.Parse(match.Groups["x2"].Value);
            int y1 = int.Parse(match.Groups["y1"].Value);
            int y2 = int.Parse(match.Groups["y2"].Value);

            int minXVelocity = 1;
            int maxXVelocity = x2;
            int minYVelocity = 1;
            int maxYVelocity = 100;

            int highestPoint = 0;

            Enumerable.Range(minYVelocity, maxYVelocity).ForEach(y =>
                Enumerable.Range(minXVelocity, maxXVelocity).ForEach(x =>
                    {
                        (int X, int Y) position = (0, 0);
                        (int X, int Y) velocity = (x, y);
                        int maxY = 0;

                        do
                        {
                            position = (position.X + velocity.X, position.Y + velocity.Y);

                            maxY = Math.Max(maxY, position.Y);

                            if (position.X >= x1 && position.X <= x2 && position.Y >= y1 && position.Y <= y2)
                            {
                                highestPoint = Math.Max(highestPoint, maxY);
                                break;
                            }

                            velocity = (X: Math.Max(0, Math.Abs(velocity.X) - 1), Y: velocity.Y - 1);
                        } while (position.X <= x2 && position.Y >= y1);
                    }
                ));

            return highestPoint;
        }

        public long SolvePart2(string puzzleInput)
        {
            var match = PuzzleRegex.Match(puzzleInput);
            int x1 = int.Parse(match.Groups["x1"].Value);
            int x2 = int.Parse(match.Groups["x2"].Value);
            int y1 = int.Parse(match.Groups["y1"].Value);
            int y2 = int.Parse(match.Groups["y2"].Value);

            int minXVelocity = 1;
            int maxXVelocity = 1000;
            int minYVelocity = -1000;
            int maxYVelocity = 1000;

            int hits = 0;

            Enumerable.Range(minYVelocity, maxYVelocity * 2).ForEach(y =>
                Enumerable.Range(minXVelocity, maxXVelocity * 2).ForEach(x =>
                    {
                        (int X, int Y) position = (0, 0);
                        (int X, int Y) velocity = (x, y);

                        do
                        {
                            position = (position.X + velocity.X, position.Y + velocity.Y);

                            if (position.X >= x1 && position.X <= x2 && position.Y >= y1 && position.Y <= y2)
                            {
                                hits++;
                                break;
                            }

                            velocity = (X: Math.Max(0, Math.Abs(velocity.X) - 1), Y: velocity.Y - 1);
                        } while (position.X <= x2 && position.Y >= y1);
                    }
                ));

            return hits;
        }
    }
}