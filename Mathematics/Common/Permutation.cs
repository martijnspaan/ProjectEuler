using System;
using System.Collections.Generic;
using System.Linq;
using Mathematics.Lists;

namespace Mathematics.Common
{
	class Permutation
	{
		private static List<String> permutations = new List<string>();

		private static char[] inputSet;
		private static int elementLevel = -1;
		private static int numberOfElements;
		private static int[] permutationValue = new int[0];

		public static IList<String> Calc(bool circular, params char [] values)
		{
			// set input values
			inputSet = values;
			numberOfElements = values.Count();

			// Initialize for calculation
			permutations = new List<string>();
			elementLevel = -1;
			permutationValue = new int[0];
			Array.Resize(ref permutationValue, inputSet.Length);

			if (circular)
				CalcCiculation();
			else
				CalcPermutation(0);
			return permutations;
		}

		private static void CalcCiculation()
		{
			for (int i = 0; i < numberOfElements; i++)
			{
				var value = "";
				for (int j = i; j < numberOfElements; j++)
				{
					value += inputSet[j];
				}
				for (int j = 0; j < i; j++)
				{
					value += inputSet[j];
				}
				permutations.Add(value);
			}
		}

		private static void CalcPermutation(int k)
		{
			elementLevel++;
			permutationValue.SetValue(elementLevel, k);

			if (elementLevel == numberOfElements)
			{
				var permutation = permutationValue.Aggregate("", (current, i) => current + inputSet.GetValue(i - 1));
				permutations.Add(permutation);
			}
			else
			{
				for (var i = 0; i < numberOfElements; i++)
				{
					if (permutationValue[i] == 0)
					{
						CalcPermutation(i);
					}
				}
			}
			elementLevel--;
			permutationValue.SetValue(0, k);
		}
	}
}
