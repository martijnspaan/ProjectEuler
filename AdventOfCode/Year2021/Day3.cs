using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Year2021.Day3
{
    class Part1
    {
        public static object Solve()
        {
            string[] input = File.ReadAllLines(@"Year2021\input\Day3.txt");

            int rateLength = input.First().Length;

            int[] count = new int[rateLength];

            foreach (var binary in input)
            {
                for (int i = 0; i < binary.Length; i++)
                {
                    if (binary[i] == '1')
                        count[i]++;
                }
            }

            char[] gammaRateString = new char[rateLength];
            char[] epsilonRateString = new char[rateLength];

            for (int i = 0; i < rateLength; i++)
            {
                if (count[i] > (input.Length / 2))
                {
                    gammaRateString[i] = '1';
                    epsilonRateString[i] = '0';
                }
                else
                {
                    gammaRateString[i] = '0';
                    epsilonRateString[i] = '1';
                }
            }

            int gammaRate = Convert.ToInt32(new string(gammaRateString), 2);
            int epsilonRate = Convert.ToInt32(new string(epsilonRateString), 2);

            return gammaRate * epsilonRate;
        }
    }
    
    class Part2
    {
        public static object Solve()
        {
            int result = 0;

            string[] oxygenGeneratorRatingInput = File.ReadAllLines(@"Year2021\input\Day3.txt");
            string[] CO2ScrubberRatingInput = File.ReadAllLines(@"Year2021\input\Day3.txt");

            int rateLength = oxygenGeneratorRatingInput.First().Length;

            for (int i = 0; i < rateLength; i++)
            {
                if (oxygenGeneratorRatingInput.Length > 1)
                    oxygenGeneratorRatingInput = oxygenGeneratorRatingInput.Where(binary => FindMostCommonBit(i, oxygenGeneratorRatingInput) == binary[i]).ToArray();

                if (CO2ScrubberRatingInput.Length > 1)
                    CO2ScrubberRatingInput = CO2ScrubberRatingInput.Where(binary => FindLeastCommonBit(i, CO2ScrubberRatingInput) == binary[i]).ToArray();
            }


            int oxygenGeneratorRate = Convert.ToInt32(new string(oxygenGeneratorRatingInput.First()), 2);
            int CO2ScrubberRate = Convert.ToInt32(new string(CO2ScrubberRatingInput.First()), 2);

            return oxygenGeneratorRate * CO2ScrubberRate;
        }

        private static char FindMostCommonBit(int index, string[] binaries)
        {
            int count = 0;
            for (int i = 0; i < binaries.Length; i++)
            {
                if (binaries[i][index] == '1')
                    count++;
            }

            return (count*2) == binaries.Length ? '1' : (count*2) > (binaries.Length) ? '1' : '0';
        }

        private static char FindLeastCommonBit(int index, string[] binaries)
        {
            int count = 0;
            for (int i = 0; i < binaries.Length; i++)
            {
                if (binaries[i][index] == '1')
                    count++;
            }

            return (count * 2) == binaries.Length ? '0' : (count*2) < (binaries.Length) ? '1' : '0';
        }
    }
}