using System;
using System.IO;
using AdventOfCode.Extensions;

namespace AdventOfCode.Year2021.Day2
{
    class Part1
    {
        public static object Solve()
        {
            int horizontal = 0;
            int depth = 0;

            string[] input = File.ReadAllLines(@"Year2021\input\Day2.txt");
            foreach (var line in input)
            {
                var (direction, amount) = line.Split(' ');
                
                switch (direction)
                {
                    case "forward":
                        horizontal += int.Parse(amount);
                        break;
                    case "down":
                        depth += int.Parse(amount);
                        break;
                    case "up":
                        depth -= int.Parse(amount);
                        break;
                }
            }

            return horizontal * depth;
        }
    }
    
    class Part2
    {
        public static object Solve()
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            string[] input = File.ReadAllLines(@"Year2021\input\Day2.txt");
            foreach (var line in input)
            {
                var (direction, amountString) = line.Split(' ');

                var amount = int.Parse(amountString);
                switch (direction)
                {
                    case "forward":
                        horizontal += amount;
                        depth += aim * amount;
                        break;
                    case "down":
                        aim += amount;
                        break;
                    case "up":
                        aim -= amount;
                        break;
                }
            }

            return horizontal * depth;
        }
    }
}