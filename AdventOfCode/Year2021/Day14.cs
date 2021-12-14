using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Extensions;

namespace AdventOfCode.Year2021
{
    class Day14 : IDay
    {
        public string ExampleInput => "NNCB\n\nCH -> B\nHH -> N\nCB -> H\nNH -> C\nHB -> C\nHC -> B\nHN -> C\nNN -> C\nBH -> H\nNC -> B\nNB -> B\nBN -> B\nBB -> N\nBC -> B\nCC -> N\nCN -> C";

        public long SolvePart1(string puzzleInput)
        {
            var (polymer, mapping) = puzzleInput.ToPolymerDefinition();

            for (int i = 0; i < 10; i++)
            {
                StringBuilder newPolymer = new(polymer.Length * 2);
                for (int j = 0; j < polymer.Length-1; j++)
                {
                    var part = polymer.Substring(j, 2);
                    var newElement = mapping[part];
                    newPolymer.Append(part[0]);
                    newPolymer.Append(newElement);

                    if (j == polymer.Length-2)
                        newPolymer.Append(part[1]);
                }

                polymer = newPolymer.ToString();
            }

            var groups = polymer.GroupBy(c => c).ToArray();
            return groups.Max(group => group.Count()) - groups.Min(group => group.Count());
        }

        public long SolvePart2(string puzzleInput)
        {
            var (template, mapping) = puzzleInput.ToPolymerDefinition();

            var polymers = new Dictionary<string, long>();
            foreach (var key in mapping.Keys)
            {
                polymers.Add(key, template.Contains(key) ? 1 : 0);
            }

            for (int i = 0; i < 40; i++)
            {
                var originalPolymers = new Dictionary<string, long>(polymers);

                foreach (var key in polymers.Keys)
                {
                    if (originalPolymers[key] == 0)
                        continue;

                    var newElement = mapping[key];

                    // Split each polymer into two different ones
                    polymers[key[0] + newElement] += originalPolymers[key];
                    polymers[newElement + key[1]] += originalPolymers[key];
                    polymers[key] -= originalPolymers[key];
                }
            }

            var elementCount = new Dictionary<char, long>();
            foreach (var key in polymers.Keys)
            {
                if (elementCount.ContainsKey(key[0]) is false)
                    elementCount.Add(key[0], 0);

                elementCount[key[0]] += polymers[key];
            }

            // Add one to the last element of the template because only pairs are counted
            elementCount[template.Last()]++;

            return elementCount.Values.Max(x => x) - elementCount.Values.Min(x => x);
        }
    }
}

namespace AdventOfCode.Extensions
{
    public static partial class Day14StringExtensions
    {
        public static (string, IDictionary<string, string>) ToPolymerDefinition(this string input)
        {
            var tokens = input.Split("\n\n");
            var template = tokens[0];
            var mapping = tokens[1].Split('\n').ToDictionary(line => line.Split(" -> ")[0], line => line.Split(" -> ")[1]);

            return (template, mapping);
        }
    }
}