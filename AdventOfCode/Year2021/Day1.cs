using System;
using System.IO;
using AdventOfCode.Extensions;

namespace AdventOfCode.Year2021.Day1
{
    class Part1
    {
        public static object Solve()
        {
            int largerMeasurements = 0;

            int[] input = File.ReadAllLines(@"Year2021\input\Day1.txt").ToIntArray();

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i + 1] > input[i])
                    largerMeasurements++;
            }

            return largerMeasurements;
        }
    }
    
    class Part2
    {
        public static object Solve()
        {
            int largerMeasurements = 0;

            int[] input = File.ReadAllLines(@"Year2021\input\Day1.txt").ToIntArray();

            for (int i = 2; i < input.Length - 1; i++)
            {
                if (input[i - 1] + input[i] + input[i + 1] > input[i - 2] + input[i - 1] + input[i])
                    largerMeasurements++;
            }

            return largerMeasurements;
        }
    }
}