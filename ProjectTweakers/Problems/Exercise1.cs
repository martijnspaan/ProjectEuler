﻿using System;
using System.Linq;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectTweakers.Problems
{
    /// <summary>
    /// Sommige positieve getallen n hebben de eigenschap dat de som [ n + reverse(n) ] volledig bestaat uit oneven nummers. 
    /// Bijvoorbeeld, 36 + 63 = 99 en 409 + 904 = 1313. Deze getallen noemen we omkeerbaar; dus 36, 63, 409, en 904 zijn omkeerbaar.
    /// Voorlopende nullen in n or reverse(n) zijn niet toegestaan.
    ///
    /// Er zijn 120 omkeerbare getallen onder 1000.
    /// Hoeveel omkeerbare getallen zijn er onder 100 miljoen(108)?
    /// </summary>
    class Exercise1
	{
        public static Object Solve()
        {
            return InfiniteIntList.Items.Take(100000000).AsParallel().Count(x => x.IsReversableNumber());
		}
	}
}