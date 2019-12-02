using System;
using System.Linq;
using System.Reflection;

using Mathematics.Common;

namespace ProjectTweakers
{
    class Program
    {
        static void Main()
        {
            HiPerfTimer timer = new HiPerfTimer();
            foreach (Type exercise in Assembly.GetEntryAssembly().GetTypes().Where(x => x.Name.StartsWith("Exercise"))
                                                                            .OrderByDescending(x => Int32.Parse(x.Name.Replace("Exercise", String.Empty))))
            {
                Console.WriteLine("===========================");
                Console.WriteLine(exercise.Name);
                Console.WriteLine("===========================");

                // Solve exercise
                timer.Start();
                var solution = exercise.InvokeMember("Solve", BindingFlags.InvokeMethod, null, null, null);
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
