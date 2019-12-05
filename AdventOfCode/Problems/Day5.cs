using System;
using System.Linq;
using Mathematics.Extentions;

namespace AdventOfCode.Problems.Day5
{
    /// <summary>
    /// </summary>
    class Part1
	{
        public static Object Solve()
        {
            return SolveInternal();
        }

        public static int SolveInternal()
        {
            int opcodeIndex = 0;

            int[] computerState = new int[] { 3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1102, 27, 28, 225, 1, 113, 14, 224, 1001, 224, -34, 224, 4, 224, 102, 8, 223, 223, 101, 7, 224, 224, 1, 224, 223, 223, 1102, 52, 34, 224, 101, -1768, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 6, 224, 224, 1, 223, 224, 223, 1002, 187, 14, 224, 1001, 224, -126, 224, 4, 224, 102, 8, 223, 223, 101, 2, 224, 224, 1, 224, 223, 223, 1102, 54, 74, 225, 1101, 75, 66, 225, 101, 20, 161, 224, 101, -54, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 7, 224, 1, 224, 223, 223, 1101, 6, 30, 225, 2, 88, 84, 224, 101, -4884, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 2, 224, 224, 1, 224, 223, 223, 1001, 214, 55, 224, 1001, 224, -89, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 4, 224, 1, 224, 223, 223, 1101, 34, 69, 225, 1101, 45, 67, 224, 101, -112, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 2, 224, 1, 223, 224, 223, 1102, 9, 81, 225, 102, 81, 218, 224, 101, -7290, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 5, 224, 224, 1, 223, 224, 223, 1101, 84, 34, 225, 1102, 94, 90, 225, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 1007, 677, 677, 224, 102, 2, 223, 223, 1005, 224, 329, 101, 1, 223, 223, 1108, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 344, 101, 1, 223, 223, 1008, 677, 677, 224, 102, 2, 223, 223, 1005, 224, 359, 101, 1, 223, 223, 8, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 374, 101, 1, 223, 223, 108, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 389, 1001, 223, 1, 223, 1107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 404, 1001, 223, 1, 223, 7, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 419, 101, 1, 223, 223, 1107, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 434, 1001, 223, 1, 223, 1107, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 449, 101, 1, 223, 223, 1108, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 464, 101, 1, 223, 223, 8, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 479, 101, 1, 223, 223, 8, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 494, 1001, 223, 1, 223, 1007, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 509, 1001, 223, 1, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 524, 1001, 223, 1, 223, 1108, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 539, 101, 1, 223, 223, 1008, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 554, 101, 1, 223, 223, 107, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 569, 101, 1, 223, 223, 107, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 584, 101, 1, 223, 223, 7, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 599, 101, 1, 223, 223, 1008, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 614, 1001, 223, 1, 223, 107, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 629, 101, 1, 223, 223, 7, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 644, 1001, 223, 1, 223, 1007, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 659, 101, 1, 223, 223, 108, 677, 677, 224, 102, 2, 223, 223, 1005, 224, 674, 1001, 223, 1, 223, 4, 223, 99, 226 };

            do
            {
                var opcode = computerState[opcodeIndex] % 100;

                var opcodeString = ((computerState[opcodeIndex] - opcode) / 100).ToString().PadLeft(3, '0');
                var immidiateMode1 = int.Parse(opcodeString[2].ToString());
                var immidiateMode2 = int.Parse(opcodeString[1].ToString());
                var immidiateMode3 = int.Parse(opcodeString[0].ToString());

                if (opcode == 1)
                    ProcessAddOpcode(ref opcodeIndex, ref computerState, immidiateMode1 == 1, immidiateMode2 == 1);
                else if (opcode == 2)
                    ProcessMultiplyOpcode(ref opcodeIndex, ref computerState, immidiateMode1 == 1, immidiateMode2 == 1);
                else if (opcode == 3)
                    ProcessInputOpcode(ref opcodeIndex, ref computerState);
                else if (opcode == 4)
                    ProcessOutputOpcode(ref opcodeIndex, ref computerState, immidiateMode1 == 1);
                else if (opcode == 5)
                    ProcessJumpIfTrueOpcode(ref opcodeIndex, ref computerState, immidiateMode1 == 1, immidiateMode2 == 1);
                else if (opcode == 6)
                    ProcessJumpIfFalseOpcode(ref opcodeIndex, ref computerState, immidiateMode1 == 1, immidiateMode2 == 1);
                else if (opcode == 7)
                    ProcessLessThanOpcode(ref opcodeIndex, ref computerState, immidiateMode1 == 1, immidiateMode2 == 1);
                else if (opcode == 8)
                    ProcessEqualsOpcode(ref opcodeIndex, ref computerState, immidiateMode1 == 1, immidiateMode2 == 1);

            } while (computerState[opcodeIndex] != 99);
            
            return computerState[0];
		}

        private static void ProcessAddOpcode(ref int opcodeIndex, ref int[] computerState, bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? computerState[opcodeIndex + 1] : computerState[computerState[opcodeIndex + 1]];
            var param2 = immidiateMode2 ? computerState[opcodeIndex + 2] : computerState[computerState[opcodeIndex + 2]];
            computerState[computerState[opcodeIndex + 3]] = param1 + param2;
            opcodeIndex += 4;
        }

        private static void ProcessMultiplyOpcode(ref int opcodeIndex, ref int[] computerState, bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? computerState[opcodeIndex + 1] : computerState[computerState[opcodeIndex + 1]];
            var param2 = immidiateMode2 ? computerState[opcodeIndex + 2] : computerState[computerState[opcodeIndex + 2]];
            computerState[computerState[opcodeIndex + 3]] = param1 * param2;
            opcodeIndex += 4;
        }

        private static void ProcessInputOpcode(ref int opcodeIndex, ref int[] computerState)
        {
            Console.WriteLine("Give number input:");
            var input = Console.ReadLine();
            computerState[computerState[opcodeIndex + 1]] = int.Parse(input);
            opcodeIndex += 2;
        }

        private static void ProcessOutputOpcode(ref int opcodeIndex, ref int[] computerState, bool immidiateMode1)
        {
            var value = immidiateMode1 ? computerState[opcodeIndex + 1] : computerState[computerState[opcodeIndex + 1]];
            Console.WriteLine($"Output value: {value}");
            Console.WriteLine();
            opcodeIndex += 2;
        }

        private static void ProcessJumpIfTrueOpcode(ref int opcodeIndex, ref int[] computerState, bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? computerState[opcodeIndex + 1] : computerState[computerState[opcodeIndex + 1]];
            var param2 = immidiateMode2 ? computerState[opcodeIndex + 2] : computerState[computerState[opcodeIndex + 2]];
            if (param1 != 0) opcodeIndex = param2;
            else opcodeIndex += 3;
        }

        private static void ProcessJumpIfFalseOpcode(ref int opcodeIndex, ref int[] computerState, bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? computerState[opcodeIndex + 1] : computerState[computerState[opcodeIndex + 1]];
            var param2 = immidiateMode2 ? computerState[opcodeIndex + 2] : computerState[computerState[opcodeIndex + 2]];
            if (param1 == 0) opcodeIndex = param2;
            else opcodeIndex += 3;
        }

        private static void ProcessLessThanOpcode(ref int opcodeIndex, ref int[] computerState, bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? computerState[opcodeIndex + 1] : computerState[computerState[opcodeIndex + 1]];
            var param2 = immidiateMode2 ? computerState[opcodeIndex + 2] : computerState[computerState[opcodeIndex + 2]];
            
            computerState[computerState[opcodeIndex + 3]] = param1 < param2 ? 1 : 0;
            opcodeIndex += 4;
        }

        private static void ProcessEqualsOpcode(ref int opcodeIndex, ref int[] computerState, bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? computerState[opcodeIndex + 1] : computerState[computerState[opcodeIndex + 1]];
            var param2 = immidiateMode2 ? computerState[opcodeIndex + 2] : computerState[computerState[opcodeIndex + 2]];

            computerState[computerState[opcodeIndex + 3]] = param1 == param2 ? 1 : 0;
            opcodeIndex += 4;
        }
    }

    /// <summary>
    /// </summary>
    class Part2
    {
        public static Object Solve()
        {
            return 0;
        }
    }
}