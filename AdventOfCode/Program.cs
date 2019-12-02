using Mathematics.Common;
using System;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            HiPerfTimer timer = new HiPerfTimer();
            foreach (Type day in Assembly.GetEntryAssembly().GetTypes()
                .Where(x => x.Name.StartsWith("Part") && !x.Namespace.EndsWith("99"))
                .OrderByDescending(x => int.Parse(x.Namespace.Replace("AdventOfCode.Problems.Day", string.Empty)))
                .ThenBy(x => int.Parse(x.Name.Replace("Part", string.Empty))))
            {
                Console.WriteLine("=======================================");
                Console.WriteLine(day.Namespace + "." + day.Name);
                Console.WriteLine("=======================================");

                // Solve exercise
                timer.Start();
                object solution = day.InvokeMember("Solve", BindingFlags.InvokeMethod, null, null, null);
                timer.Stop();

                // Show solution
                Console.WriteLine("Solution: " + solution);
                Console.WriteLine("Duration: " + timer.DurationFormatted);
                Console.WriteLine();
                Console.ReadKey();
                Console.WriteLine();
            }
        }
    }
}