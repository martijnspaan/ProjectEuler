namespace AdventOfCode.Year2021
{
    internal interface IDay
    {
        public string ExampleInput { get; }
        public int SolvePart1(string input);
        public int SolvePart2(string input);
    }
}