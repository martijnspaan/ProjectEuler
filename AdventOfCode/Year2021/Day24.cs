using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Day24Extensions;
using AdventOfCode.Extensions;

namespace AdventOfCode.Year2021
{
    class Day24 : IDay
    {
        public string ExampleInput => "inp z\ninp x\nmul z 3\neql z x";
        //public string ExampleInput => "inp w\nadd z w\nmod z 2\ndiv w 2\nadd y w\nmod y 2\ndiv w 2\nadd x w\nmod x 2\ndiv w 2\nmod w 2";

        public long SolvePart1(string puzzleInput)
        {
            if (puzzleInput == ExampleInput) return 0;

            Operation[] alu = puzzleInput.ToOperations();

            long maxModelNumber = 0;

            long minResult = long.MaxValue;

            Dictionary<int, int[]> possibleValues = new()
            {
                { 4, new[] { 2, 3, 4, 9 } },
                { 8, new[] { 1, 2, 4, 5, 6, 9 } },
                { 9, new[] { 6, 7, 8, 9 } },
                { 11, new[] { 1, 2, 5, 6, 7, 9 } },
                { 12, new[] { 1, 2, 9 } },
            };

            /*List<long> results = new List<long>
            {
                RunAlu(alu, new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
                RunAlu(alu, new[] { 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
                RunAlu(alu, new[] { 1, 1, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
                RunAlu(alu, new[] { 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
                RunAlu(alu, new[] { 1, 1, 1, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
                RunAlu(alu, new[] { 1, 1, 1, 1, 6, 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
                RunAlu(alu, new[] { 1, 1, 1, 1, 7, 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
                RunAlu(alu, new[] { 1, 1, 1, 1, 8, 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
                RunAlu(alu, new[] { 1, 1, 1, 1, 9, 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
            };

            var discintc = results.Distinct().ToList();*/

            Parallel.For(111111, 999999, new ParallelOptions {  }, (i, state) =>
            {
                var modelNumber = i.ToString();
                if (modelNumber.Contains('0')) return;

                foreach (var value4 in possibleValues[4])
                {
                    foreach (var value8 in possibleValues[8])
                    {
                        foreach (var value9 in possibleValues[9])
                        {
                            foreach (var value11 in possibleValues[11])
                            {
                                foreach (var value12 in possibleValues[12])
                                {
                                    int[] input = new int[14];
                                    int index = 0;
                                    for (int j = 0; j < 14; j++)
                                    {
                                        input[j] = j switch
                                        {
                                            4 => value4,
                                            5 => 9,
                                            7 => 9,
                                            8 => value8,
                                            9 => value9,
                                            10 => 9,
                                            11 => value11,
                                            12 => value12,
                                            _ => int.Parse(modelNumber[index++].ToString())
                                        };
                                    }

                                    long result = RunAlu(alu, input);

                                    if (result < minResult)
                                        minResult = Math.Min(result, minResult);

                                    if (Math.Abs(result) == 0)
                                    {
                                        maxModelNumber = long.Parse(string.Join(string.Empty, input.Select(x => x .ToString())));
                                        Console.Beep();
                                        state.Break();
                                    }
                                }
                            }
                        }
                    }
                }
            });

            return maxModelNumber;
        }

        private static long RunAlu(Operation[] alu, int[] input)
        {
            int inputIndex = 0;
            Dictionary<char, long> variables = new() {{'w', 0}, {'x', 0}, {'y', 0}, {'z', 0}};

            foreach (var operation in alu)
            {
                switch (operation.operation)
                {
                    case 0: // inp
                        variables[operation.a] = input[inputIndex++];
                        break;
                    case 1: // add
                        if (operation.value.HasValue)
                            variables[operation.a] = variables[operation.a] + operation.value.Value;
                        else
                            variables[operation.a] = variables[operation.a] + variables[operation.b];
                        break;
                    case 2: // mul
                        if (operation.value.HasValue)
                            variables[operation.a] = variables[operation.a] * operation.value.Value;
                        else
                            variables[operation.a] = variables[operation.a] * variables[operation.b];
                        break;
                    case 3: // div
                        if (operation.value.HasValue)
                            variables[operation.a] = variables[operation.a] / operation.value.Value;
                        else
                            variables[operation.a] = variables[operation.a] / variables[operation.b];
                        break;
                    case 4: // mod
                        if (operation.value.HasValue)
                            variables[operation.a] = variables[operation.a] % operation.value.Value;
                        else
                            variables[operation.a] = variables[operation.a] % variables[operation.b];
                        break;
                    case 5: // eql
                        if (operation.value.HasValue)
                            variables[operation.a] = variables[operation.a] == operation.value.Value ? 1 : 0;
                        else
                            variables[operation.a] = variables[operation.a] == variables[operation.b] ? 1 : 0;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return variables['z'];
        }

        public long SolvePart2(string puzzleInput)
        {
            string[] alu = puzzleInput.Split('\n');

            return 0;
        }
    }
}

namespace AdventOfCode.Day24Extensions
{
    public struct Operation
    {
        public short operation;
        public char a;
        public char b;
        public short? value;
    }

    public static class Day24Extensions
    {
        public static Operation[] ToOperations(this string input)
        {
            return input.Split('\n').Select(op =>
            {
                string[] opTokens = op.Split(' ');
                short operation = opTokens[0] switch
                {
                    "inp" => 0,
                    "add" => 1,
                    "mul" => 2,
                    "div" => 3,
                    "mod" => 4,
                    "eql" => 5,
                    _ => throw new NotSupportedException()
                };

                if (opTokens.Length == 2)
                {
                    return new Operation
                    {
                        operation = operation,
                        a = opTokens[1][0]
                    };
                }

                if (short.TryParse(opTokens[2], out short value))
                {
                    return new Operation
                    {
                        operation = operation,
                        a = opTokens[1][0],
                        value = value
                    };
                }

                return new Operation
                {
                    operation = operation,
                    a = opTokens[1][0],
                    b = opTokens[2][0]
                };
            }).ToArray();
        }
    }
}