using System.Collections.Generic;
using System.Linq;
using Oyster.Math;

namespace AdventOfCode.Year2021.Day6
{
    class Part1
    {
        public static object Solve()
        {
            int[] lanternFish = {5,1,1,5,4,2,1,2,1,2,2,1,1,1,4,2,2,4,1,1,1,1,1,4,1,1,1,1,1,5,3,1,4,1,1,1,1,1,4,1,5,1,1,1,4,1,2,2,3,1,5,1,1,5,1,1,5,4,1,1,1,4,3,1,1,1,3,1,5,5,1,1,1,1,5,3,2,1,2,3,1,5,1,1,4,1,1,2,1,5,1,1,1,1,5,4,5,1,3,1,3,3,5,5,1,3,1,5,3,1,1,4,2,3,3,1,2,4,1,1,1,1,1,1,1,2,1,1,4,1,3,2,5,2,1,1,1,4,2,1,1,1,4,2,4,1,1,1,1,4,1,3,5,5,1,2,1,3,1,1,4,1,1,1,1,2,1,1,4,2,3,1,1,1,1,1,1,1,4,5,1,1,3,1,1,2,1,1,1,5,1,1,1,1,1,3,2,1,2,4,5,1,5,4,1,1,3,1,1,5,5,1,3,1,1,1,1,4,4,2,1,2,1,1,5,1,1,4,5,1,1,1,1,1,1,1,1,1,1,3,1,1,1,1,1,4,2,1,1,1,2,5,1,4,1,1,1,4,1,1,5,4,4,3,1,1,4,5,1,1,3,5,3,1,2,5,3,4,1,3,5,4,1,3,1,5,1,4,1,1,4,2,1,1,1,3,2,1,1,4};

            List<int> spawnFish = new();

            for (int i = 0; i < 80; i++)
            {
                for (int j = 0; j < lanternFish.Length; j++)
                {
                    if (lanternFish[j] == 0)
                    {
                        lanternFish[j] = 6;
                        spawnFish.Add(8);
                    }
                    else
                    {
                        lanternFish[j]--;
                    }

                }

                lanternFish = lanternFish.Concat(spawnFish).ToArray();
                spawnFish = new();

            }

            return lanternFish.Length;
        }
    }
    
    class Part2
    {
        public static object Solve()
        {
            int[] input = { 5, 1, 1, 5, 4, 2, 1, 2, 1, 2, 2, 1, 1, 1, 4, 2, 2, 4, 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 5, 3, 1, 4, 1, 1, 1, 1, 1, 4, 1, 5, 1, 1, 1, 4, 1, 2, 2, 3, 1, 5, 1, 1, 5, 1, 1, 5, 4, 1, 1, 1, 4, 3, 1, 1, 1, 3, 1, 5, 5, 1, 1, 1, 1, 5, 3, 2, 1, 2, 3, 1, 5, 1, 1, 4, 1, 1, 2, 1, 5, 1, 1, 1, 1, 5, 4, 5, 1, 3, 1, 3, 3, 5, 5, 1, 3, 1, 5, 3, 1, 1, 4, 2, 3, 3, 1, 2, 4, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 4, 1, 3, 2, 5, 2, 1, 1, 1, 4, 2, 1, 1, 1, 4, 2, 4, 1, 1, 1, 1, 4, 1, 3, 5, 5, 1, 2, 1, 3, 1, 1, 4, 1, 1, 1, 1, 2, 1, 1, 4, 2, 3, 1, 1, 1, 1, 1, 1, 1, 4, 5, 1, 1, 3, 1, 1, 2, 1, 1, 1, 5, 1, 1, 1, 1, 1, 3, 2, 1, 2, 4, 5, 1, 5, 4, 1, 1, 3, 1, 1, 5, 5, 1, 3, 1, 1, 1, 1, 4, 4, 2, 1, 2, 1, 1, 5, 1, 1, 4, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1, 1, 1, 4, 2, 1, 1, 1, 2, 5, 1, 4, 1, 1, 1, 4, 1, 1, 5, 4, 4, 3, 1, 1, 4, 5, 1, 1, 3, 5, 3, 1, 2, 5, 3, 4, 1, 3, 5, 4, 1, 3, 1, 5, 1, 4, 1, 1, 4, 2, 1, 1, 1, 3, 2, 1, 1, 4 };

            IntX[] lanternFish = new IntX[9];
            for (int i = 0; i < lanternFish.Length; i++)
            {
                lanternFish[i] = new IntX(0);
            }

            for (int i = 0; i < input.Length; i++)
            {
                int index = input[i];
                lanternFish[index] = lanternFish[index] + 1;
            }

            for (int i = 0; i < 256; i++)
            {
                IntX newFish = new IntX(lanternFish[0]);

                for (int j = 0; j < 8; j++)
                {
                    lanternFish[j] = lanternFish[j + 1];
                }

                lanternFish[8] = newFish;
                lanternFish[6] += newFish;
            }

            IntX result = new IntX();
            foreach (var fish in lanternFish)
            {
                result += fish;
            }

            return result;
        }
    }
}