using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventOfCode.Extensions;
using Mathematics.Extentions;

namespace AdventOfCode.Year2021
{
    class Day18 : IDay
    {
        public string ExampleInput => "[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]\n[[[5,[2, 8]],4],[5,[[9,9],0]]]\n[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]\n[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]\n[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]\n[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]\n[[[[5,4],[7,7]],8],[[8,3],8]]\n[[9,3],[[9,9],[6,[4,9]]]]\n[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]\n[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

        // public string ExampleInput => "[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]\n[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]\n[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]\n[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]\n[7,[5,[[3,8],[1,4]]]]\n[[2,[2,2]],[8,[8,1]]]\n[2,9]\n[1,[[[9,3],9],[[9,0],[0,7]]]]\n[[[5,[7,4]],7],1]\n[[[[4,2],2],6],[8,7]]";

        //public string ExampleInput => "[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]";

        public long SolvePart1(string puzzleInput)
        {
            Queue<string> snailLines = new Queue<string>(puzzleInput.Replace(" ", "").Split('\n'));

            string equation = snailLines.Dequeue();

            if (snailLines.Count == 0)
            {
                Console.WriteLine(Reduce(equation));
                return 0;
            }

            do
            {
                var nextLine = snailLines.Dequeue();

                equation = $"[{equation},{nextLine}]";

                equation = Reduce(equation);

            } while (snailLines.Count > 0);

            return CalculateMagnitude(equation);
        }

        private static long CalculateMagnitude(string equation)
        {
            do
            {
                var match = Regex.Match(equation, @"\[(?<left>\d+),(?<right>\d+)\]");
                int left = int.Parse(match.Groups["left"].Value);
                int right = int.Parse(match.Groups["right"].Value);

                equation = equation.Replace(match.Value, (3 * left + 2 * right).ToString());
            } while (equation.Contains('['));

            return Int64.Parse(equation); 
        }

        private string Reduce(string equation)
        {
            do
            {
            } while (Explode(ref equation) || Split(ref equation));

            return equation;
        }


        private static bool Split(ref string equation)
        {
            Match match = Regex.Match(equation, @"\d\d+");
            if (match.Success is false) return false;

            int value = int.Parse(match.Value);

            int left = value / 2;
            int right = value / 2 + value % 2;

            int index = equation.IndexOf(match.Value);
            equation = equation.Remove(index, match.Value.Length).Insert(index, $"[{left},{right}]");

            return true;
        }

        private static bool Explode(ref string equation)
        {
            int open = 0;
            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '[') open++;
                if (equation[i] == ']') open--;

                if (open == 5)
                {
                    var match = Regex.Match(equation.Substring(i), @"\[(?<left>\d+),(?<right>\d+)\]");
                    int left = int.Parse(match.Groups["left"].Value);
                    int right = int.Parse(match.Groups["right"].Value);

                    for (int j = i + match.Value.Length; j < equation.Length; j++)
                    {
                        if (equation[j].IsNumber())
                        {
                            Match innerMatch = Regex.Match(equation.Substring(j), @"\d+");
                            int value = int.Parse(innerMatch.Value);
                            equation = equation.Remove(j, innerMatch.Value.Length)
                                .Insert(j, (value + right).ToString());
                            break;
                        }
                    }

                    equation = equation.Remove(i, match.Value.Length).Insert(i, "0");

                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (equation[j].IsNumber())
                        {
                            while (equation[j].IsNumber()) j--;

                            Match innerMatch = Regex.Match(equation.Substring(j), @"\d+");
                            int value = int.Parse(innerMatch.Value);
                            equation = equation.Remove(j+1, innerMatch.Value.Length)
                                .Insert(j+1, (value + left).ToString());
                            break;
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        public long SolvePart2(string puzzleInput)
        {
            var lines = puzzleInput.Replace(" ", "").Split('\n');

            long maxMagnitude = 0;

            for (int x = 0; x < lines.Length; x++)
            {
                for (int y = 0; y < lines.Length; y++)
                {
                    var magnitude = CalculateMagnitude(Reduce($"[{lines[x]},{lines[y]}]"));
                    maxMagnitude = Math.Max(magnitude, maxMagnitude);
                }
            }

            return maxMagnitude;
        }
    }

    public class SnailPair
    {
    }
}

namespace AdventOfCode.Extensions
{
}