namespace AdventOfCode.Year2021
{
    internal interface IDay
    {
        public string ExampleInput { get; }
        public long SolvePart1(string input);
        public long SolvePart2(string input);
    }
}