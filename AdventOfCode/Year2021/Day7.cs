using System;
using System.Linq;
using AdventOfCode.Extensions;

namespace AdventOfCode.Year2021
{
    class Day7 : IDay
    {
        public string ExampleInput => "16,1,2,0,4,2,7,1,2,14";

        public int SolvePart1(string puzzleInput)
        {
            int[] input = puzzleInput.ToIntArray();

            return Enumerable.Range(input.Min(), input.Max()).Select(position =>
            {
                return input.Select(crabPosition => Math.Abs(position - crabPosition)).Sum();
            }).Min();
        }

        public int SolvePart2(string puzzleInput)
        {
            int[] input = puzzleInput.ToIntArray();

            return Enumerable.Range(input.Min(), input.Max()).Select(position =>
            {
                return input.Select(crabPosition =>
                {
                    int steps = Math.Abs(position - crabPosition);
                    return steps*(steps+1)/2;
                }).Sum();
            }).Min();
        }
    }
}