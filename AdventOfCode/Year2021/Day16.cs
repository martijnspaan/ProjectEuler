using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Extensions;
using AdventOfCode.Models;
using static System.String;

namespace AdventOfCode.Year2021
{
    class Day16 : IDay
    {
        public string ExampleInput => "A0016C880162017C3686B18A3D4780";

        public long SolvePart1(string puzzleInput)
        {
            puzzleInput.HexToBinaryString().ParsePackets().ToList();

            return 0; // Removed quick and dirty code for summing up values
        }

        public long SolvePart2(string puzzleInput)
        {
            var packets = puzzleInput.HexToBinaryString().ParsePackets();

            return packets.First().Value;
        }
    }
}

namespace AdventOfCode.Models
{
    public class LiteralValue : Packet
    {
        public LiteralValue(long version, long typeId, long value) : base(version, typeId)
        {
            Value = value;
        }
    }

    public class Operator : Packet
    {
        public List<Packet> SubPackets { get; }

        public Operator(long version, long typeId, List<Packet> subPackets) : base(version, typeId)
        {
            SubPackets = subPackets;

            Value = typeId switch
            {
                0 => SubPackets.Sum(packet => packet.Value),
                1 => SubPackets.Aggregate((long)1, (i, packet) => i * packet.Value),
                2 => SubPackets.Min(packet => packet.Value),
                3 => SubPackets.Max(packet => packet.Value),
                5 => SubPackets.First().Value > subPackets.Last().Value ? 1 : 0,
                6 => SubPackets.First().Value < subPackets.Last().Value ? 1 : 0,
                7 => SubPackets.First().Value == subPackets.Last().Value ? 1 : 0,
                _ => throw new NotSupportedException()
            };
        }
    }

    public class Packet
    {
        public long Version { get; }
        public long TypeId { get; }

        public long Value { get; protected set; }

        protected Packet(long version, long typeId)
        {
            Version = version;
            TypeId = typeId;
        }
    }

    public class BinaryStringReader
    {
        private int _index;
        private readonly string _binaryString;

        public BinaryStringReader(string input)
        {
            _binaryString = input;
        }

        public bool HasMorePackets => _index < _binaryString.Length - 7;

        public long TakeInt64(int length)
        {
            long value = Convert.ToInt64(_binaryString.Substring(_index, length), 2);
            _index += length;
            return value;
        }

        public long TakeLiteralValue()
        {
            var valueString = Empty;
            string valueStringPart;
            do
            {
                valueStringPart = _binaryString.Substring(_index, 5);
                _index += 5;

                valueString += valueStringPart.Substring(1);

            } while (valueStringPart.First() == '1');

            return Convert.ToInt64(valueString, 2);
        }

        public BinaryStringReader TakeBinaryString(int totalLength)
        {
            var value =  _binaryString.Substring(_index, totalLength);
            _index += totalLength;
            return new BinaryStringReader(value);
        }

        public Packet GetNextPacket()
        {
            var version = TakeInt64(3);
            var typeId = TakeInt64(3);

            if (typeId == 4)
            {
                return new LiteralValue(version, typeId, TakeLiteralValue());
            }

            var lengthTypeId = TakeInt64(1);

            if (lengthTypeId == 0)
            {
                var totalLength = TakeInt64(15);

                BinaryStringReader valuePacket = TakeBinaryString((int)totalLength);

                var subPackets = valuePacket.ParsePackets().ToList();

                return new Operator(version, typeId, subPackets);
            }

            if (lengthTypeId == 1)
            {
                long totalPackets = TakeInt64(11);

                List<Packet> subPackets = new List<Packet>();

                for (int i = 0; i < totalPackets; i++)
                {
                    subPackets.Add(GetNextPacket());
                }

                return new Operator(version, typeId, subPackets);
            }

            throw new NotImplementedException();
        }
    }
}

namespace AdventOfCode.Extensions
{
    public static partial class TransmissionExtensions
    {
        public static IEnumerable<Packet> ParsePackets(this BinaryStringReader binaryString)
        {
            do
            {
                yield return binaryString.GetNextPacket();
            } while (binaryString.HasMorePackets);
        }
    }

    public static partial class StringExtensions
    {
        public static BinaryStringReader HexToBinaryString(this string value)
        {
            return new(
                Join(Empty, value.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'))
            ));
        }
    }
}