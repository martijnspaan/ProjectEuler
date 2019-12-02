using System;
using System.Linq;
using Mathematics.Extentions;
using Mathematics.Lists;
using Oyster.Math;

namespace ProjectTweakers.Problems
{
    /// <summary>
    /// De schimmel F. ellipsoidea wordt erg groot. De fibonacci reeks bepaald het aantal centimeters dat de schimmel dagelijks in diameter toeneemt.
    /// 
    /// Bereken de omtrek van de schimmel na 1000 dagen groeien.
    /// 
    /// </summary>
    class Exercise4
	{
        public static Object Solve()
        {

            
            var diameter = FibonacciSequence.ItemsX.Take(1000).Sum();
            
            var x = IntX.Multiply(diameter, 314159265359, MultiplyMode.Classic);
            var y = IntX.Divide(x, 100000000000, DivideMode.Classic);
            return y;
        }
	}
}