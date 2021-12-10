using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021
{
    class Day10 : IDay
    {
        public string ExampleInput => "[({(<(())[]>[[{[]{<()<>>\n[(()[<>])]({[<{<<[]>>(\n{([(<{}[<>[]}>{[]{[(<()>\n(((({<>}<{<{<>}{[]{[]{}\n[[<[([]))<([[{}[[()]]]\n[{[{({}]{}}([{[{{{}}([]\n{<[[]]>}<{[{[{[]{()[[[]\n[<(<(<(<{}))><([]([]()\n<{([([[(<>()){}]>(<<{{\n<{([{{}}[<[[[<>{}]]]>[]]";
        
        public long SolvePart1(string puzzleInput)
        {
            var input = puzzleInput.Split('\n').Select(line => new Chunk(line));

            return input.Select(chunk => chunk.GetIllegalCharacter()).Select(Chunk.Score).Sum();
        }

        public long SolvePart2(string puzzleInput)
        {
            var input = puzzleInput.Split('\n').Select(line => new Chunk(line));

            long[] scores = input.Where(chunk => chunk.GetIllegalCharacter() == ' ').Select(chunk => chunk.AutoCompleteScore()).OrderBy(score => score).ToArray();

            return scores[scores.Length / 2];
        }
    }

    class Chunk
    {
        private readonly string _chunk;

        public static Dictionary<char, int> ClosingScore = new()
        {
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 },
        };

        public static Dictionary<char, int> CompletingScore = new()
        {
            { ')', 1},
            { ']', 2 },
            { '}', 3 },
            { '>', 4 },
        };

        public static Dictionary<char, char> OpeningMatch = new()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
            { '<', '>' },
        };

        public static Dictionary<char, char> ClosingMatch = new()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' },
            { '>', '<' },
        };

        public Chunk(string chunk)
        {
            _chunk = chunk;
        }

        public static int Score(char c)
        {
            if (ClosingScore.ContainsKey(c))
                return ClosingScore[c];

            return 0;
        }

        readonly Stack<char> _stack = new();

        public char GetIllegalCharacter()
        {
            foreach (char c in _chunk)
            {
                if (OpeningMatch.ContainsKey(c))
                    _stack.Push(c);
                else if (_stack.Peek() == ClosingMatch[c])
                    _stack.Pop();
                else
                    return c; // illegal
            }

            if (_stack.Count == 0)
                return '\r'; // finished

            return ' '; // not finished
        }

        public long AutoCompleteScore()
        {
            long score = 0;

            foreach (var c in _stack)
            {
                score *= 5;
                score += CompletingScore[OpeningMatch[c]];
            }

            return score;
        }
    }
}

namespace AdventOfCode.Extensions
{

}