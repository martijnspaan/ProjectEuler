using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathematics.Extentions;
using Oyster.Math;

namespace AdventOfCode.Problems.Day9
{
    /// <summary>
    /// </summary>
    class Part1
    {
        public static Object Solve()
        {            
            long[] _computerState = new long[] { 1102, 34463338, 34463338, 63, 1007, 63, 34463338, 63, 1005, 63, 53, 1101, 3, 0, 1000, 109, 988, 209, 12, 9, 1000, 209, 6, 209, 3, 203, 0, 1008, 1000, 1, 63, 1005, 63, 65, 1008, 1000, 2, 63, 1005, 63, 904, 1008, 1000, 0, 63, 1005, 63, 58, 4, 25, 104, 0, 99, 4, 0, 104, 0, 99, 4, 17, 104, 0, 99, 0, 0, 1101, 25, 0, 1016, 1102, 760, 1, 1023, 1102, 1, 20, 1003, 1102, 1, 22, 1015, 1102, 1, 34, 1000, 1101, 0, 32, 1006, 1101, 21, 0, 1017, 1102, 39, 1, 1010, 1101, 30, 0, 1005, 1101, 0, 1, 1021, 1101, 0, 0, 1020, 1102, 1, 35, 1007, 1102, 1, 23, 1014, 1102, 1, 29, 1019, 1101, 767, 0, 1022, 1102, 216, 1, 1025, 1102, 38, 1, 1011, 1101, 778, 0, 1029, 1102, 1, 31, 1009, 1101, 0, 28, 1004, 1101, 33, 0, 1008, 1102, 1, 444, 1027, 1102, 221, 1, 1024, 1102, 1, 451, 1026, 1101, 787, 0, 1028, 1101, 27, 0, 1018, 1101, 0, 24, 1013, 1102, 26, 1, 1012, 1101, 0, 36, 1002, 1102, 37, 1, 1001, 109, 28, 21101, 40, 0, -9, 1008, 1019, 41, 63, 1005, 63, 205, 1001, 64, 1, 64, 1105, 1, 207, 4, 187, 1002, 64, 2, 64, 109, -9, 2105, 1, 5, 4, 213, 1106, 0, 225, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -9, 1206, 10, 243, 4, 231, 1001, 64, 1, 64, 1105, 1, 243, 1002, 64, 2, 64, 109, -3, 1208, 2, 31, 63, 1005, 63, 261, 4, 249, 1106, 0, 265, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 5, 21108, 41, 41, 0, 1005, 1012, 287, 4, 271, 1001, 64, 1, 64, 1105, 1, 287, 1002, 64, 2, 64, 109, 6, 21102, 42, 1, -5, 1008, 1013, 45, 63, 1005, 63, 307, 1105, 1, 313, 4, 293, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -9, 1201, 0, 0, 63, 1008, 63, 29, 63, 1005, 63, 333, 1106, 0, 339, 4, 319, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -13, 2102, 1, 4, 63, 1008, 63, 34, 63, 1005, 63, 361, 4, 345, 1105, 1, 365, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 5, 1201, 7, 0, 63, 1008, 63, 33, 63, 1005, 63, 387, 4, 371, 1105, 1, 391, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 7, 1202, 1, 1, 63, 1008, 63, 32, 63, 1005, 63, 411, 1105, 1, 417, 4, 397, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 20, 1205, -7, 431, 4, 423, 1106, 0, 435, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 2, 2106, 0, -3, 1001, 64, 1, 64, 1105, 1, 453, 4, 441, 1002, 64, 2, 64, 109, -7, 21101, 43, 0, -9, 1008, 1014, 43, 63, 1005, 63, 479, 4, 459, 1001, 64, 1, 64, 1105, 1, 479, 1002, 64, 2, 64, 109, -5, 21108, 44, 43, 0, 1005, 1018, 495, 1105, 1, 501, 4, 485, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -7, 1205, 9, 517, 1001, 64, 1, 64, 1105, 1, 519, 4, 507, 1002, 64, 2, 64, 109, 11, 1206, -1, 531, 1106, 0, 537, 4, 525, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -15, 1208, 0, 36, 63, 1005, 63, 557, 1001, 64, 1, 64, 1106, 0, 559, 4, 543, 1002, 64, 2, 64, 109, 7, 2101, 0, -7, 63, 1008, 63, 35, 63, 1005, 63, 581, 4, 565, 1106, 0, 585, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -3, 21107, 45, 46, 4, 1005, 1015, 607, 4, 591, 1001, 64, 1, 64, 1105, 1, 607, 1002, 64, 2, 64, 109, -16, 2102, 1, 10, 63, 1008, 63, 31, 63, 1005, 63, 631, 1001, 64, 1, 64, 1106, 0, 633, 4, 613, 1002, 64, 2, 64, 109, 1, 2107, 33, 10, 63, 1005, 63, 649, 1106, 0, 655, 4, 639, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 17, 2101, 0, -9, 63, 1008, 63, 31, 63, 1005, 63, 679, 1001, 64, 1, 64, 1106, 0, 681, 4, 661, 1002, 64, 2, 64, 109, -6, 2107, 34, 0, 63, 1005, 63, 703, 4, 687, 1001, 64, 1, 64, 1106, 0, 703, 1002, 64, 2, 64, 109, 5, 1207, -5, 34, 63, 1005, 63, 719, 1105, 1, 725, 4, 709, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -15, 1202, 6, 1, 63, 1008, 63, 20, 63, 1005, 63, 751, 4, 731, 1001, 64, 1, 64, 1105, 1, 751, 1002, 64, 2, 64, 109, 21, 2105, 1, 5, 1001, 64, 1, 64, 1106, 0, 769, 4, 757, 1002, 64, 2, 64, 109, 5, 2106, 0, 5, 4, 775, 1001, 64, 1, 64, 1106, 0, 787, 1002, 64, 2, 64, 109, -27, 1207, 4, 35, 63, 1005, 63, 809, 4, 793, 1001, 64, 1, 64, 1106, 0, 809, 1002, 64, 2, 64, 109, 13, 2108, 33, -1, 63, 1005, 63, 831, 4, 815, 1001, 64, 1, 64, 1106, 0, 831, 1002, 64, 2, 64, 109, 4, 21107, 46, 45, 1, 1005, 1014, 851, 1001, 64, 1, 64, 1105, 1, 853, 4, 837, 1002, 64, 2, 64, 109, 3, 21102, 47, 1, -3, 1008, 1013, 47, 63, 1005, 63, 875, 4, 859, 1106, 0, 879, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -9, 2108, 28, 2, 63, 1005, 63, 895, 1106, 0, 901, 4, 885, 1001, 64, 1, 64, 4, 64, 99, 21101, 27, 0, 1, 21102, 1, 915, 0, 1106, 0, 922, 21201, 1, 59074, 1, 204, 1, 99, 109, 3, 1207, -2, 3, 63, 1005, 63, 964, 21201, -2, -1, 1, 21102, 942, 1, 0, 1105, 1, 922, 21201, 1, 0, -1, 21201, -2, -3, 1, 21102, 1, 957, 0, 1105, 1, 922, 22201, 1, -1, -2, 1106, 0, 968, 22102, 1, -2, -2, 109, -3, 2105, 1, 0 };

            var cpu = new OpcodeComputer(_computerState);
            var output = cpu.Process(1);

            return output[0];
        }

        /// <summary>
        /// </summary>
        class Part2
        {
            public static Object Solve()
            {
                long[] _computerState = new long[] { 1102, 34463338, 34463338, 63, 1007, 63, 34463338, 63, 1005, 63, 53, 1101, 3, 0, 1000, 109, 988, 209, 12, 9, 1000, 209, 6, 209, 3, 203, 0, 1008, 1000, 1, 63, 1005, 63, 65, 1008, 1000, 2, 63, 1005, 63, 904, 1008, 1000, 0, 63, 1005, 63, 58, 4, 25, 104, 0, 99, 4, 0, 104, 0, 99, 4, 17, 104, 0, 99, 0, 0, 1101, 25, 0, 1016, 1102, 760, 1, 1023, 1102, 1, 20, 1003, 1102, 1, 22, 1015, 1102, 1, 34, 1000, 1101, 0, 32, 1006, 1101, 21, 0, 1017, 1102, 39, 1, 1010, 1101, 30, 0, 1005, 1101, 0, 1, 1021, 1101, 0, 0, 1020, 1102, 1, 35, 1007, 1102, 1, 23, 1014, 1102, 1, 29, 1019, 1101, 767, 0, 1022, 1102, 216, 1, 1025, 1102, 38, 1, 1011, 1101, 778, 0, 1029, 1102, 1, 31, 1009, 1101, 0, 28, 1004, 1101, 33, 0, 1008, 1102, 1, 444, 1027, 1102, 221, 1, 1024, 1102, 1, 451, 1026, 1101, 787, 0, 1028, 1101, 27, 0, 1018, 1101, 0, 24, 1013, 1102, 26, 1, 1012, 1101, 0, 36, 1002, 1102, 37, 1, 1001, 109, 28, 21101, 40, 0, -9, 1008, 1019, 41, 63, 1005, 63, 205, 1001, 64, 1, 64, 1105, 1, 207, 4, 187, 1002, 64, 2, 64, 109, -9, 2105, 1, 5, 4, 213, 1106, 0, 225, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -9, 1206, 10, 243, 4, 231, 1001, 64, 1, 64, 1105, 1, 243, 1002, 64, 2, 64, 109, -3, 1208, 2, 31, 63, 1005, 63, 261, 4, 249, 1106, 0, 265, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 5, 21108, 41, 41, 0, 1005, 1012, 287, 4, 271, 1001, 64, 1, 64, 1105, 1, 287, 1002, 64, 2, 64, 109, 6, 21102, 42, 1, -5, 1008, 1013, 45, 63, 1005, 63, 307, 1105, 1, 313, 4, 293, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -9, 1201, 0, 0, 63, 1008, 63, 29, 63, 1005, 63, 333, 1106, 0, 339, 4, 319, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -13, 2102, 1, 4, 63, 1008, 63, 34, 63, 1005, 63, 361, 4, 345, 1105, 1, 365, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 5, 1201, 7, 0, 63, 1008, 63, 33, 63, 1005, 63, 387, 4, 371, 1105, 1, 391, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 7, 1202, 1, 1, 63, 1008, 63, 32, 63, 1005, 63, 411, 1105, 1, 417, 4, 397, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 20, 1205, -7, 431, 4, 423, 1106, 0, 435, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 2, 2106, 0, -3, 1001, 64, 1, 64, 1105, 1, 453, 4, 441, 1002, 64, 2, 64, 109, -7, 21101, 43, 0, -9, 1008, 1014, 43, 63, 1005, 63, 479, 4, 459, 1001, 64, 1, 64, 1105, 1, 479, 1002, 64, 2, 64, 109, -5, 21108, 44, 43, 0, 1005, 1018, 495, 1105, 1, 501, 4, 485, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -7, 1205, 9, 517, 1001, 64, 1, 64, 1105, 1, 519, 4, 507, 1002, 64, 2, 64, 109, 11, 1206, -1, 531, 1106, 0, 537, 4, 525, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -15, 1208, 0, 36, 63, 1005, 63, 557, 1001, 64, 1, 64, 1106, 0, 559, 4, 543, 1002, 64, 2, 64, 109, 7, 2101, 0, -7, 63, 1008, 63, 35, 63, 1005, 63, 581, 4, 565, 1106, 0, 585, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -3, 21107, 45, 46, 4, 1005, 1015, 607, 4, 591, 1001, 64, 1, 64, 1105, 1, 607, 1002, 64, 2, 64, 109, -16, 2102, 1, 10, 63, 1008, 63, 31, 63, 1005, 63, 631, 1001, 64, 1, 64, 1106, 0, 633, 4, 613, 1002, 64, 2, 64, 109, 1, 2107, 33, 10, 63, 1005, 63, 649, 1106, 0, 655, 4, 639, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 17, 2101, 0, -9, 63, 1008, 63, 31, 63, 1005, 63, 679, 1001, 64, 1, 64, 1106, 0, 681, 4, 661, 1002, 64, 2, 64, 109, -6, 2107, 34, 0, 63, 1005, 63, 703, 4, 687, 1001, 64, 1, 64, 1106, 0, 703, 1002, 64, 2, 64, 109, 5, 1207, -5, 34, 63, 1005, 63, 719, 1105, 1, 725, 4, 709, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -15, 1202, 6, 1, 63, 1008, 63, 20, 63, 1005, 63, 751, 4, 731, 1001, 64, 1, 64, 1105, 1, 751, 1002, 64, 2, 64, 109, 21, 2105, 1, 5, 1001, 64, 1, 64, 1106, 0, 769, 4, 757, 1002, 64, 2, 64, 109, 5, 2106, 0, 5, 4, 775, 1001, 64, 1, 64, 1106, 0, 787, 1002, 64, 2, 64, 109, -27, 1207, 4, 35, 63, 1005, 63, 809, 4, 793, 1001, 64, 1, 64, 1106, 0, 809, 1002, 64, 2, 64, 109, 13, 2108, 33, -1, 63, 1005, 63, 831, 4, 815, 1001, 64, 1, 64, 1106, 0, 831, 1002, 64, 2, 64, 109, 4, 21107, 46, 45, 1, 1005, 1014, 851, 1001, 64, 1, 64, 1105, 1, 853, 4, 837, 1002, 64, 2, 64, 109, 3, 21102, 47, 1, -3, 1008, 1013, 47, 63, 1005, 63, 875, 4, 859, 1106, 0, 879, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -9, 2108, 28, 2, 63, 1005, 63, 895, 1106, 0, 901, 4, 885, 1001, 64, 1, 64, 4, 64, 99, 21101, 27, 0, 1, 21102, 1, 915, 0, 1106, 0, 922, 21201, 1, 59074, 1, 204, 1, 99, 109, 3, 1207, -2, 3, 63, 1005, 63, 964, 21201, -2, -1, 1, 21102, 942, 1, 0, 1105, 1, 922, 21201, 1, 0, -1, 21201, -2, -3, 1, 21102, 1, 957, 0, 1105, 1, 922, 22201, 1, -1, -2, 1106, 0, 968, 22102, 1, -2, -2, 109, -3, 2105, 1, 0 };

                var cpu = new OpcodeComputer(_computerState);
                var output = cpu.Process(2);

                return output[0];
            }
        }
    }

    public class OpcodeComputer
    {
        private long _iteration = 0;
        private long _opcodeIndex = 0;
        private long[] _computerState;
        private long _relativeBase = 0;

        private enum ParameterMode
        {
            Position = 0,
            Immediate = 1,
            Relative = 2
        }

        public OpcodeComputer(long[] initial_computerState)
        {
            _computerState = (long[])initial_computerState.Clone();
        }

        private long GetParam(long index, ParameterMode parameterMode, bool raw = false)
        {
            if (raw)
            {
                switch (parameterMode)
                {
                    case ParameterMode.Position:
                        return GetAddressValue(_opcodeIndex + index);
                    case ParameterMode.Immediate:
                        return GetAddressValue(_opcodeIndex + index);
                    case ParameterMode.Relative:
                        return _relativeBase + GetAddressValue(_opcodeIndex + index);
                    default:
                        throw new Exception($"Wrong parameter mode {parameterMode}");
                }
            }

            switch (parameterMode)
            {
                case ParameterMode.Position:
                    return GetAddressValue(GetAddressValue(_opcodeIndex + index));
                case ParameterMode.Immediate:
                    return GetAddressValue(_opcodeIndex + index);
                case ParameterMode.Relative:
                    return GetAddressValue(_relativeBase + GetAddressValue(_opcodeIndex + index));
                default:
                    throw new Exception($"Wrong parameter mode {parameterMode}");
            }
        }

        private long GetAddressValue(long index)
        {
            while (index >= _computerState.Length)
            {
                Array.Resize(ref _computerState, _computerState.Length * 2);
            }
            return _computerState[index];
        }

        private void SetAddressValue(long index, long value)
        {
            while (index >= _computerState.Length)
            {
                Array.Resize(ref _computerState, _computerState.Length * 2);
            }
            _computerState[index] = value;
        }

        public long[] Process(params long[] input)
        {
            int inputIndex = 0;
            List<long> output = new List<long>();

            do
            {
                _iteration++;

                var instruction = GetAddressValue(_opcodeIndex);
                var opcode = instruction % 100;

                var parameterString = ((instruction - opcode) / 100).ToString().PadLeft(3, '0');
                var paramMode1 = (ParameterMode)int.Parse(parameterString[2].ToString());
                var paramMode2 = (ParameterMode)int.Parse(parameterString[1].ToString());
                var paramMode3 = (ParameterMode)int.Parse(parameterString[0].ToString());

                var param1 = GetParam(1, paramMode1, opcode == 3);
                var param2 = GetParam(2, paramMode2);
                var param3 = GetParam(3, paramMode3, true);

                if (opcode == 1)
                    ProcessAddOpcode(param1, param2, param3);
                else if (opcode == 2)
                    ProcessMultiplyOpcode(param1, param2, param3);
                else if (opcode == 3)                    
                    ProcessInputOpcode(input[inputIndex++], param1);
                else if (opcode == 4)
                    output.Add(ProcessOutputOpcode(param1));
                else if (opcode == 5)
                    ProcessJumpIfTrueOpcode(param1, param2);
                else if (opcode == 6)
                    ProcessJumpIfFalseOpcode(param1, param2);
                else if (opcode == 7)
                    ProcessLessThanOpcode(param1, param2, param3);
                else if (opcode == 8)
                    ProcessEqualsOpcode(param1, param2, param3);
                else if (opcode == 9)
                    ProcessRelativeBaseOpcode(param1);

            } while (GetAddressValue(_opcodeIndex) != 99);

            return output.ToArray();
        }

        private void ProcessAddOpcode(long param1, long param2, long param3)
        {
            SetAddressValue(param3, param1 + param2);
            _opcodeIndex += 4;
        }

        private void ProcessMultiplyOpcode(long param1, long param2, long param3)
        {
            SetAddressValue(param3, param1 * param2);
            _opcodeIndex += 4;
        }

        private void ProcessInputOpcode(long input, long param1)
        {
            SetAddressValue(param1, input);
            _opcodeIndex += 2;
        }

        private long ProcessOutputOpcode(long param1)
        {
            _opcodeIndex += 2;
            return param1;
        }

        private void ProcessJumpIfTrueOpcode(long param1, long param2)
        {
            if (param1 != 0) _opcodeIndex = param2;
            else _opcodeIndex += 3;
        }

        private void ProcessJumpIfFalseOpcode(long param1, long param2)
        {
            if (param1 == 0) _opcodeIndex = param2;
            else _opcodeIndex += 3;
        }

        private void ProcessLessThanOpcode(long param1, long param2, long param3)
        {
            SetAddressValue(param3, param1 < param2 ? 1 : 0);
            _opcodeIndex += 4;
        }

        private void ProcessEqualsOpcode(long param1, long param2, long param3)
        {
            SetAddressValue(param3, param1 == param2 ? 1 : 0);
            _opcodeIndex += 4;
        }

        private void ProcessRelativeBaseOpcode(long param1)
        {
            _relativeBase += param1;
            _opcodeIndex += 2;
        }
    }
}