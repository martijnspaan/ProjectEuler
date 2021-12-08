using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Models;

namespace AdventOfCode.Year2021
{
    class Day8 : IDay
    {
        public string ExampleInput => "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe\nedbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc\nfgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg\nfbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb\naecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea\nfgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb\ndbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe\nbdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef\negadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb\ngcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce";

        public int SolvePart1(string puzzleInput)
        {
             var input = puzzleInput.Split("\n").Select(x => x.Split(" | ")[1]);

             return input.SelectMany(x => x.Split(" ")).Count(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7);
        }

        public int SolvePart2(string puzzleInput)
        {
            var input = puzzleInput.Split("\n").Select(x => new SignalWire(x)).ToList();

            return input.Select(x => x.Value).Sum();
        }
    }
}

namespace AdventOfCode.Models
{
    public class SignalWire
    {
        private Dictionary<string, int> Map = new();
        private Dictionary<int, string> RMap = new();

        public SignalWire(string input)
        {
            string[] inputTokens = input.Split(" | ");
            SignalPatterns = inputTokens[0].Split(" ").Select(token => new string(token.OrderBy(c => c).ToArray())).ToList();
            ValuePatterns = inputTokens[1].Split(" ").Select(token => new string(token.OrderBy(c => c).ToArray())).ToArray();

            RMap.Add(1, SignalPatterns.Single(x => x.Length == 2));
            Map.Add(RMap[1], 1);

            RMap.Add(4, SignalPatterns.Single(x => x.Length == 4));
            Map.Add(RMap[4], 4);

            RMap.Add(7, SignalPatterns.Single(x => x.Length == 3));
            Map.Add(RMap[7], 7);

            RMap.Add(8, SignalPatterns.Single(x => x.Length == 7));
            Map.Add(RMap[8], 8);

            RMap.Add(9, SignalPatterns.Single(x => x.Length == 6 && RMap[4].All(x.Contains)));
            Map.Add(RMap[9], 9);

            RMap.Add(0, SignalPatterns.Single(x => x.Length == 6 && x != RMap[9] && RMap[7].All(x.Contains)));
            Map.Add(RMap[0], 0);

            RMap.Add(6, SignalPatterns.Single(x => x.Length == 6 && x != RMap[9] && x != RMap[0]));
            Map.Add(RMap[6], 6);

            RMap.Add(3, SignalPatterns.Single(x => x.Length == 5 && RMap[7].All(x.Contains)));
            Map.Add(RMap[3], 3);

            RMap.Add(5, SignalPatterns.Single(x => x.Length == 5 && x != RMap[3] && x.Count(y => RMap[9].Contains(y)) == 5));
            Map.Add(RMap[5], 5);

            RMap.Add(2, SignalPatterns.Single(x => x.Length == 5 && x != RMap[3] && x != RMap[5]));
            Map.Add(RMap[2], 2);
        }

        public ICollection<string> SignalPatterns { get; set; }
        public string[] ValuePatterns { get; set; }

        public int Value => Map[ValuePatterns[0]] * 1000 + Map[ValuePatterns[1]] * 100 + Map[ValuePatterns[2]] * 10 + Map[ValuePatterns[3]];
    }
}