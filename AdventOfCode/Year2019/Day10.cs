using System;
using System.Linq;
using Mathematics.Extentions;

namespace AdventOfCode.Problems.Day10
{
    /// <summary>
    /// 
    /// </summary>
    class Part1
	{
        private static bool[,] _starMap;
        private static int _width;
        private static int _height;
        
        private static string input = @"#.#...#.#.|.###....#.|.#....#...|##.#.#.#.#|....#.#.#.|.##..###.#|..#...##..|..##....##|......#...|.####.###.";
        //private static string input = @"......#.#.|#..#.#....|..#######.|.#.#.###..|.#..#.....|..#....#.#|#..#....#.|.##.#..###|##...#..#.|.#....####";
        //private static string input = @".#..#|.....|#####|....#|...##";

        public static Object Solve()
        {
            var lines = input.Split("|");
            _width = lines[0].Length;
            _height = lines.Length;

            ParseStarMap(lines);

            var maxDetectedCount = 0;
            var maxDetectedX = -1;
            var maxDetectedY = -1;

            //for (int x = 0; x < _width; x++)
            {
                //for (int y = 0; y < _height; y++)
                {
                    //if (_starMap[x, y] == false) continue; // Coordinate is not an star
                    int x = 1;
                    int y = 2;
                    var detected = CountDetectedStars(x, y);
                    if (detected > maxDetectedCount)
                    {
                        maxDetectedCount = detected;
                        maxDetectedX = x;
                        maxDetectedY = y;
                    }
                }
            }


            return maxDetectedCount;
        }

        private static int CountDetectedStars(int detectorX, int detectorY)
        {
            var testStartsMap = (bool[,])_starMap.Clone();
            var removedMap = new bool[_width, _height];

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {                    
                    if (x == detectorX && y == detectorY) continue; // Coordinate is the detector
                    if (_starMap[x,y] == false) continue; // Coordinate is not star

                    var deltaX = x - detectorX;
                    var deltaY = y - detectorY;

                    if (deltaX == 0)
                    {
                        deltaY = deltaY > 0 ? 1 : -1;
                    }
                    else if (deltaY == 0)
                    {
                        deltaX = deltaX > 0 ? 1 : -1;
                    }
                    else
                    {
                        while (deltaX % deltaY == 0)
                        {
                            if (Math.Abs(deltaY) == 1) break;

                            deltaX = deltaX / Math.Abs(deltaY);
                            deltaY = deltaY / Math.Abs(deltaY);
                        }
                        while (deltaY % deltaX == 0)
                        {
                            if (Math.Abs(deltaX) == 1) break;

                            deltaY = deltaY / Math.Abs(deltaX);
                            deltaX = deltaX / Math.Abs(deltaX);
                        }
                    }

                    var testStarX = x + deltaX;
                    var testStarY = y + deltaY;

                    while (testStarX >= 0 && testStarY >= 0 && testStarX < _width && testStarY < _height)
                    {
                        if (testStartsMap[testStarX, testStarY])
                        {
                            testStartsMap[testStarX, testStarY] = false;
                            removedMap[testStarX, testStarY] = true;
                        }

                        testStarX += deltaX;
                        testStarY += deltaY;
                    }
                }
            }

            for (int y = 0; y < _height; y++) 
            {
                for (int x = 0; x < _width; x++)
                {
                    Console.Write(testStartsMap[x,y] ? "#" : ".");
                }
                Console.WriteLine();
            }

            return testStartsMap.OfType<bool>().Count(star => star == true);
        }

        private static void ParseStarMap(string[] lines)
        {
            _starMap = new bool[_width, _height];
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _starMap[x, y] = lines[y][x] == '#';
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class Part2
    {
        public static Object Solve()
        {
            return 0;
        }
    }
}