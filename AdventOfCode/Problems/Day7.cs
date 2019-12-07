using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathematics.Extentions;

namespace AdventOfCode.Problems.Day7
{
    /// <summary>
    /// </summary>
    class Part1
    {
        public static Object Solve()
        {
            int[] _computerState = new int[] { 3, 8, 1001, 8, 10, 8, 105, 1, 0, 0, 21, 34, 51, 76, 101, 114, 195, 276, 357, 438, 99999, 3, 9, 1001, 9, 3, 9, 1002, 9, 3, 9, 4, 9, 99, 3, 9, 101, 4, 9, 9, 102, 4, 9, 9, 1001, 9, 5, 9, 4, 9, 99, 3, 9, 1002, 9, 4, 9, 101, 3, 9, 9, 102, 5, 9, 9, 1001, 9, 2, 9, 1002, 9, 2, 9, 4, 9, 99, 3, 9, 1001, 9, 3, 9, 102, 2, 9, 9, 101, 4, 9, 9, 102, 3, 9, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 101, 4, 9, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 99, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 99 };

            var cpu = new OpcodeComputer(_computerState);

            int maxThrusterSignal = 0;
            object maxThrusterSignalLock = new object();

            Parallel.For(0, 44445, new ParallelOptions { MaxDegreeOfParallelism = 8 }, (phase) => {
                var phaseString = phase.ToString().PadLeft(5, '0');

                if (phaseString.Any(c => int.Parse(c.ToString()) > 4)) return;
                if (phaseString.Distinct().ToArray().Length != 5) return;

                int thrusterSignal = 0;
                foreach (char phaseStep in phaseString)
                {
                    // FIX thrusterSignal = cpu.Process(int.Parse(phaseStep.ToString()), thrusterSignal);
                }
                
                lock(maxThrusterSignalLock)
                {
                    if (thrusterSignal > maxThrusterSignal)
                    {
                        maxThrusterSignal = Math.Max(thrusterSignal, maxThrusterSignal);
                    }
                }
            });            

            return maxThrusterSignal;
        }

        /// <summary>
        /// </summary>
        class Part2
        {
            public static Object Solve()
            {
                int[] _computerState = new int[] { 3, 8, 1001, 8, 10, 8, 105, 1, 0, 0, 21, 34, 51, 76, 101, 114, 195, 276, 357, 438, 99999, 3, 9, 1001, 9, 3, 9, 1002, 9, 3, 9, 4, 9, 99, 3, 9, 101, 4, 9, 9, 102, 4, 9, 9, 1001, 9, 5, 9, 4, 9, 99, 3, 9, 1002, 9, 4, 9, 101, 3, 9, 9, 102, 5, 9, 9, 1001, 9, 2, 9, 1002, 9, 2, 9, 4, 9, 99, 3, 9, 1001, 9, 3, 9, 102, 2, 9, 9, 101, 4, 9, 9, 102, 3, 9, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 101, 4, 9, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 99, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 99 };

                

                int maxThrusterSignal = 0;
                object maxThrusterSignalLock = new object();

                Parallel.For(55555, 100000, new ParallelOptions { MaxDegreeOfParallelism = 8 }, (phase) =>
                {
                    var phaseString = phase.ToString().PadLeft(5, '0');

                    var amplifiers = new[] {
                        new OpcodeComputer((int[])_computerState.Clone()),
                        new OpcodeComputer((int[])_computerState.Clone()),
                        new OpcodeComputer((int[])_computerState.Clone()),
                        new OpcodeComputer((int[])_computerState.Clone()),
                        new OpcodeComputer((int[])_computerState.Clone())
                    };

                    if (phaseString.Any(c => int.Parse(c.ToString()) < 5)) return;
                    if (phaseString.Distinct().ToArray().Length != 5) return;

                    int signal = 0;
                    for (int ampIndex = 0; ampIndex < 5; ampIndex++)
                    {
                        signal = amplifiers[ampIndex].Process(int.Parse(phaseString[ampIndex].ToString()), signal);
                    }

                    var output = 0;
                    do
                    {
                        for (int ampIndex = 0; ampIndex < 5; ampIndex++)
                        {
                            output = amplifiers[ampIndex].Process(signal);
                            if (output == int.MinValue) break;
                            signal = output;
                        }
                        if (output == int.MinValue) break;
                    } while (output != int.MinValue);

                    lock (maxThrusterSignalLock)
                    {
                        if (signal > maxThrusterSignal)
                        {
                            maxThrusterSignal = Math.Max(signal, maxThrusterSignal);
                        }
                    }
                });

                return maxThrusterSignal;
            }
        }
    }

    public class OpcodeComputer
    {
        private int _opcodeIndex = 0;
        private readonly int[] _computerState;

        public OpcodeComputer(int[] initial_computerState)
        {
            _computerState = (int[])initial_computerState.Clone();
        }

        public int Process(params int[] input)
        {
            int inputIndex = 0;

            do
            {
                var opcode = _computerState[_opcodeIndex] % 100;

                var opcodeString = ((_computerState[_opcodeIndex] - opcode) / 100).ToString().PadLeft(3, '0');
                var immidiateMode1 = int.Parse(opcodeString[2].ToString());
                var immidiateMode2 = int.Parse(opcodeString[1].ToString());
                var immidiateMode3 = int.Parse(opcodeString[0].ToString());

                if (opcode == 1)
                    ProcessAddOpcode(immidiateMode1 == 1, immidiateMode2 == 1);
                else if (opcode == 2)
                    ProcessMultiplyOpcode(immidiateMode1 == 1, immidiateMode2 == 1);
                else if (opcode == 3)                    
                    ProcessInputOpcode(input[inputIndex++]);
                else if (opcode == 4)
                    return ProcessOutputOpcode(immidiateMode1 == 1);
                else if (opcode == 5)
                    ProcessJumpIfTrueOpcode(immidiateMode1 == 1, immidiateMode2 == 1);
                else if (opcode == 6)
                    ProcessJumpIfFalseOpcode(immidiateMode1 == 1, immidiateMode2 == 1);
                else if (opcode == 7)
                    ProcessLessThanOpcode(immidiateMode1 == 1, immidiateMode2 == 1);
                else if (opcode == 8)
                    ProcessEqualsOpcode(immidiateMode1 == 1, immidiateMode2 == 1);

            } while (_computerState[_opcodeIndex] != 99);

            return int.MinValue;
        }

        private void ProcessAddOpcode(bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? _computerState[_opcodeIndex + 1] : _computerState[_computerState[_opcodeIndex + 1]];
            var param2 = immidiateMode2 ? _computerState[_opcodeIndex + 2] : _computerState[_computerState[_opcodeIndex + 2]];
            _computerState[_computerState[_opcodeIndex + 3]] = param1 + param2;
            _opcodeIndex += 4;
        }

        private void ProcessMultiplyOpcode(bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? _computerState[_opcodeIndex + 1] : _computerState[_computerState[_opcodeIndex + 1]];
            var param2 = immidiateMode2 ? _computerState[_opcodeIndex + 2] : _computerState[_computerState[_opcodeIndex + 2]];
            _computerState[_computerState[_opcodeIndex + 3]] = param1 * param2;
            _opcodeIndex += 4;
        }

        private void ProcessInputOpcode(int input)
        {            
            _computerState[_computerState[_opcodeIndex + 1]] = input;
            _opcodeIndex += 2;
        }

        private int ProcessOutputOpcode(bool immidiateMode1)
        {
            var value = immidiateMode1 ? _computerState[_opcodeIndex + 1] : _computerState[_computerState[_opcodeIndex + 1]];
            _opcodeIndex += 2;
            return value;
        }

        private void ProcessJumpIfTrueOpcode(bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? _computerState[_opcodeIndex + 1] : _computerState[_computerState[_opcodeIndex + 1]];
            var param2 = immidiateMode2 ? _computerState[_opcodeIndex + 2] : _computerState[_computerState[_opcodeIndex + 2]];
            if (param1 != 0) _opcodeIndex = param2;
            else _opcodeIndex += 3;
        }

        private void ProcessJumpIfFalseOpcode(bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? _computerState[_opcodeIndex + 1] : _computerState[_computerState[_opcodeIndex + 1]];
            var param2 = immidiateMode2 ? _computerState[_opcodeIndex + 2] : _computerState[_computerState[_opcodeIndex + 2]];
            if (param1 == 0) _opcodeIndex = param2;
            else _opcodeIndex += 3;
        }

        private void ProcessLessThanOpcode(bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? _computerState[_opcodeIndex + 1] : _computerState[_computerState[_opcodeIndex + 1]];
            var param2 = immidiateMode2 ? _computerState[_opcodeIndex + 2] : _computerState[_computerState[_opcodeIndex + 2]];
            
            _computerState[_computerState[_opcodeIndex + 3]] = param1 < param2 ? 1 : 0;
            _opcodeIndex += 4;
        }

        private void ProcessEqualsOpcode(bool immidiateMode1, bool immidiateMode2)
        {
            var param1 = immidiateMode1 ? _computerState[_opcodeIndex + 1] : _computerState[_computerState[_opcodeIndex + 1]];
            var param2 = immidiateMode2 ? _computerState[_opcodeIndex + 2] : _computerState[_computerState[_opcodeIndex + 2]];

            _computerState[_computerState[_opcodeIndex + 3]] = param1 == param2 ? 1 : 0;
            _opcodeIndex += 4;
        }
    }
}