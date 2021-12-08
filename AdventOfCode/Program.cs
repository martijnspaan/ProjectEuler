using Mathematics.Common;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using AdventOfCode.Year2021;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            HiPerfTimer timer = new HiPerfTimer();
            foreach (Type day in Assembly.GetEntryAssembly().GetTypes()
                .Where(x => x.IsInterface is false && typeof(IDay).IsAssignableFrom(x) && !x.Name.EndsWith("99") && x.Namespace.Contains("2021"))
                .OrderByDescending(x => int.Parse(x.Name.Replace("Day", string.Empty))))
            {
                Console.WriteLine("=======================================");
                Console.WriteLine(day.Namespace + "." + day.Name);
                Console.WriteLine("=======================================");
                
                IDay puzzle = (IDay)Activator.CreateInstance(day);

                // Solve part 1
                string puzzleInput = "0";
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Add(HttpRequestHeader.Cookie, "session=" + Environment.GetEnvironmentVariable("AoC-Session"));
                    var puzzleDay = day.Name.Replace("Day", string.Empty);
                    try
                    {
                        puzzleInput = webClient.DownloadString($"https://adventofcode.com/2021/day/{puzzleDay}/input");
                        puzzleInput = puzzleInput.Trim(' ', '\r', '\n');
                    }
                    catch
                    {
                        Console.WriteLine("Could not find puzzle input for " + day.Name);
                    }
                }

                Console.WriteLine("Example : " + puzzle.SolvePart1(puzzle.ExampleInput));
                timer.Start();
                int solutionPart1 = puzzle.SolvePart1(puzzleInput);
                timer.Stop();
                Console.WriteLine("Solution: " + solutionPart1);
                Console.WriteLine("Duration: " + timer.DurationFormatted);
                Console.WriteLine();

                Console.WriteLine("Example : " + puzzle.SolvePart2(puzzle.ExampleInput));
                timer.Start();
                int solutionPart2 = puzzle.SolvePart2(puzzleInput);
                timer.Stop();
                Console.WriteLine("Solution: " + solutionPart2);
                Console.WriteLine("Duration: " + timer.DurationFormatted);
                Console.WriteLine();

                Console.ReadKey();
                Console.WriteLine();
            }
        }
    }
}