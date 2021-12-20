using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Extensions;
using Mathematics.Extentions;
using Models;

namespace AdventOfCode.Year2021
{
    class Day19 : IDay
    {
        public string ExampleInput => "--- scanner 0 ---\n404,-588,-901\n528,-643,409\n-838,591,734\n390,-675,-793\n-537,-823,-458\n-485,-357,347\n-345,-311,381\n-661,-816,-575\n-876,649,763\n-618,-824,-621\n553,345,-567\n474,580,667\n-447,-329,318\n-584,868,-557\n544,-627,-890\n564,392,-477\n455,729,728\n-892,524,684\n-689,845,-530\n423,-701,434\n7,-33,-71\n630,319,-379\n443,580,662\n-789,900,-551\n459,-707,401\n\n--- scanner 1 ---\n686,422,578\n605,423,415\n515,917,-361\n-336,658,858\n95,138,22\n-476,619,847\n-340,-569,-846\n567,-361,727\n-460,603,-452\n669,-402,600\n729,430,532\n-500,-761,534\n-322,571,750\n-466,-666,-811\n-429,-592,574\n-355,545,-477\n703,-491,-529\n-328,-685,520\n413,935,-424\n-391,539,-444\n586,-435,557\n-364,-763,-893\n807,-499,-711\n755,-354,-619\n553,889,-390\n\n--- scanner 2 ---\n649,640,665\n682,-795,504\n-784,533,-524\n-644,584,-595\n-588,-843,648\n-30,6,44\n-674,560,763\n500,723,-460\n609,671,-379\n-555,-800,653\n-675,-892,-343\n697,-426,-610\n578,704,681\n493,664,-388\n-671,-858,530\n-667,343,800\n571,-461,-707\n-138,-166,112\n-889,563,-600\n646,-828,498\n640,759,510\n-630,509,768\n-681,-892,-333\n673,-379,-804\n-742,-814,-386\n577,-820,562\n\n--- scanner 3 ---\n-589,542,597\n605,-692,669\n-500,565,-823\n-660,373,557\n-458,-679,-417\n-488,449,543\n-626,468,-788\n338,-750,-386\n528,-832,-391\n562,-778,733\n-938,-730,414\n543,643,-506\n-524,371,-870\n407,773,750\n-104,29,83\n378,-903,-323\n-778,-728,485\n426,699,580\n-438,-605,-362\n-469,-447,-387\n509,732,623\n647,635,-688\n-868,-804,481\n614,-800,639\n595,780,-596\n\n--- scanner 4 ---\n727,592,562\n-293,-554,779\n441,611,-461\n-714,465,-776\n-743,427,-804\n-660,-479,-426\n832,-632,460\n927,-485,-438\n408,393,-506\n466,436,-512\n110,16,151\n-258,-428,682\n-393,719,612\n-211,-452,876\n808,-476,-593\n-575,615,604\n-485,667,467\n-680,325,-822\n-627,-443,-432\n872,-547,-609\n833,512,582\n807,604,487\n839,-516,451\n891,-625,532\n-652,-548,-490\n30,-46,-14";

        public long SolvePart1(string puzzleInput)
        {
            List<Scanner> scanners = puzzleInput.ToScanners().ToList();

            do
            {
                var unknownScanners = scanners.Where(scanner => scanner.Position == null);

                foreach (var unknownScanner in unknownScanners)
                {
                    var knownScanners = scanners.Where(scanner => scanner.Position != null).OrderByDescending(scanner => scanner.NonOverlappingScanners.Count);

                    foreach (var knownScanner in knownScanners)
                    {
                        unknownScanner.IdentifyPositionRelativeTo(knownScanner);
                    }
                }


            } while (scanners.Any(scanner => scanner.Position == null && scanner.NonOverlappingScanners.Count != 3));


            var beacons = scanners.SelectMany(scanner => scanner.Beacons.Select(beacon =>
                new Position(beacon.X, beacon.Y, beacon.Z)));
            var distinctBeacons = beacons.DistinctBy(pos => pos.X * pos.Y * pos.Z).ToList();
            return distinctBeacons.Count();
        }

        public long SolvePart2(string puzzleInput)
        {
            //int[] input = puzzleInput.ToIntArray();

            return 0;
        }
    }
}

namespace Models
{
    public class Scanner
    {
        public int Id { get; set; }

        public List<Position> Beacons { get; set; } = new();

        public List<int> NonOverlappingScanners = new();

        public Position Position { get; set; }

        public int Facing { get; set; }

        public (int X, int Y, int Z) Orientation { get; set; }

        private static readonly List<(int X, int Y, int Z)> Orientations = new()
        {
            (-1, 1, -1),
            (-1, -1, -1),
            (-1, -1, 1),
            (-1, 1, 1),
            (1, -1, -1),
            (1, -1, 1),
            (1, 1, 1),
            (1, 1, -1),
        };

        public Scanner(string input)
        {
            var lines = input.Split('\n');

            var match = Regex.Match(lines[0], @"\d+");
            Id = int.Parse(match.Value);

            if (Id == 0)
            {
                Position = new (0, 0, 0);
                Orientation = (1, 1, 1);
            }

            for (int i = 1; i < lines.Length; i++)
            {
                match = Regex.Match(lines[i], @"(?<X>-?\d+),(?<Y>-?\d+),(?<Z>-?\d+)");

                int X = int.Parse(match.Groups["X"].Value);
                int Y = int.Parse(match.Groups["Y"].Value);
                int Z = int.Parse(match.Groups["Z"].Value);

                Beacons.Add(new Position(X, Y, Z));
            }
        }

        private Position CalculateDelta(Position beacon, Position knownBeacon, (int X, int Y, int Z) orientation, int facing)
        {
            switch (facing)
            {
                case 0: // X,Y,Z
                    return new(knownBeacon.X - beacon.X * orientation.X,
                        knownBeacon.Y - beacon.Y * orientation.Y,
                        knownBeacon.Z - beacon.Z * orientation.Z);
                case 1: // X,Z,Y
                    return new(knownBeacon.X - beacon.X * orientation.X,
                        knownBeacon.Y - beacon.Z * orientation.Z,
                        knownBeacon.Z - beacon.Y * orientation.Y);
                case 2: // Y,X,Z
                    return new(knownBeacon.X - beacon.Y * orientation.Y,
                        knownBeacon.Y - beacon.X * orientation.X,
                        knownBeacon.Z - beacon.Z * orientation.Z);
                case 3: // Y,Z,X
                    return new(knownBeacon.X - beacon.Y * orientation.Y,
                        knownBeacon.Y - beacon.Z * orientation.Z,
                        knownBeacon.Z - beacon.X * orientation.X);
                case 4: // Z,X,Y
                    return new(knownBeacon.X - beacon.Z * orientation.Z,
                        knownBeacon.Y - beacon.X * orientation.X,
                        knownBeacon.Z - beacon.Y * orientation.Y);
                case 5: // Z,Y,X
                    return new(knownBeacon.X - beacon.Z * orientation.Z,
                        knownBeacon.Y - beacon.Y * orientation.Y,
                        knownBeacon.Z - beacon.X * orientation.X);
                default:
                    throw new NotImplementedException();
            } 
        }
        private Position CalculateAbsolute(Position beacon, Position delta, (int X, int Y, int Z) orientation, int facing)
        {
            switch (facing)
            {
                case 0: // X,Y,Z
                    return new(beacon.X * orientation.X + delta.X,
                        beacon.Y * orientation.Y + delta.Y,
                        beacon.Z * orientation.Z + delta.Z);
                case 1: // X,Z,Y
                    return new(beacon.X * orientation.X + delta.X,
                        beacon.Z * orientation.Z + delta.Y,
                        beacon.Y * orientation.Y + delta.Z);
                case 2: // Y,X,Z
                    return new(beacon.Y * orientation.Y + delta.X,
                        beacon.X * orientation.X + delta.Y,
                        beacon.Z * orientation.Z + delta.Z);
                case 3: // Y,Z,X
                    return new(beacon.Y * orientation.Y + delta.X,
                        beacon.Z * orientation.Z + delta.Y,
                        beacon.X * orientation.X + delta.Z);
                case 4: // Z,X,Y
                    return new(beacon.Z * orientation.Z + delta.X,
                        beacon.X * orientation.X + delta.Y,
                        beacon.Y * orientation.Y + delta.Z);
                case 5: // Z,Y,X
                    return new(beacon.Z * orientation.Z + delta.X,
                        beacon.Y * orientation.Y + delta.Y,
                        beacon.X * orientation.X + delta.Z);
                default:
                    throw new NotImplementedException();
            }
        }

        private Position CalculateAbsolutePosition(Scanner knownScanner, (int X, int Y, int Z) orientation, Position delta, int facing)
        {
            switch (knownScanner.Facing)
            {
                case 0: // X,Y,Z
                    return new(knownScanner.Position.X + delta.X * knownScanner.Orientation.X,
                               knownScanner.Position.Y + delta.Y * knownScanner.Orientation.Y,
                               knownScanner.Position.Z + delta.Z * knownScanner.Orientation.Z);
                case 1: // X,Z,Y
                    return new(knownScanner.Position.X + delta.X * knownScanner.Orientation.X,
                               knownScanner.Position.Y + delta.Y * knownScanner.Orientation.Y,
                               knownScanner.Position.Z + delta.Z * knownScanner.Orientation.Z);
                case 2: // Y,X,Z
                    return new(knownScanner.Position.X + delta.X * knownScanner.Orientation.X,
                               knownScanner.Position.Y + delta.Y * knownScanner.Orientation.Y,
                               knownScanner.Position.Z + delta.Z * knownScanner.Orientation.Z);
                case 3: // Y,Z,X
                    return new(knownScanner.Position.X + delta.Y * orientation.X * -1,
                               knownScanner.Position.Y + delta.Z * orientation.Y * -1,
                               knownScanner.Position.Z + delta.X * orientation.Z * -1);
                case 4: // Z,X,Y
                    return new(knownScanner.Position.X + delta.X * knownScanner.Orientation.X,
                               knownScanner.Position.Y + delta.Y * knownScanner.Orientation.Y,
                               knownScanner.Position.Z + delta.Z * knownScanner.Orientation.Z);
                case 5: // Z,Y,X
                    return new(knownScanner.Position.X + delta.X * knownScanner.Orientation.X,
                               knownScanner.Position.Y + delta.Y * knownScanner.Orientation.Y,
                               knownScanner.Position.Z + delta.Z * knownScanner.Orientation.Z);
                default:
                    throw new NotImplementedException();
            }
        }

        public void IdentifyPositionRelativeTo(Scanner knownScanner)
        {
            if (NonOverlappingScanners.Contains(knownScanner.Id)) return;

            for (int facing = 0; facing < 6; facing++)
            {
                foreach (var orientation in Orientations)
                {
                    for (int o = 0; o < Beacons.Count; o++)
                    {
                        for (int u = 0; u < knownScanner.Beacons.Count; u++)
                        {
                            Position delta = CalculateDelta(Beacons[o], knownScanner.Beacons[u], orientation, facing);

                            var overlappingBeacons = knownScanner.Beacons.SelectMany(knownBeacon =>
                                    Beacons.Select(beacon =>
                                        CalculateDelta(beacon, knownBeacon, orientation, facing)))
                                .Where(beaconDelta => beaconDelta == delta);

                            if (overlappingBeacons.Count() >= 12)
                            {

                                /*Position = CalculateAbsolutePosition(knownScanner, orientation, delta, facing);

                                Orientation = orientation;

                                Facing = facing;*/

                                Beacons = Beacons.Select(beacon =>
                                    CalculateAbsolute(beacon, delta, orientation, facing)).ToList();

                                Position = new Position(0, 0, 0);

                                return;
                            }
                        }
                    }
                }
            }

            NonOverlappingScanners.Add(knownScanner.Id);
        }
    }

    public record Position(int X, int Y, int Z);
}

namespace AdventOfCode.Extensions
{
    public static partial class Day19Extensions
    {
        public static IEnumerable<Scanner> ToScanners(this string input)
        {
            return input.Split("\n\n").Select(scannerInput => new Scanner(scannerInput));
        }
    }
}