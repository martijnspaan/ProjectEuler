using System;
using System.Linq;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectTweakers.Problems
{
    /// <summary>
    /// De Fibonaccireeks is een rij van getallen die ten grondslag ligt aan vele processen in de natuur,
    /// van de structuur van zonnebloemen tot de explosieve groei van een konijnenpopulatie.
    /// 
    /// De reeks begint met de getallen 0 en 1, waarna ieder volgend getal de som is van zijn 2 voorgangers.
    /// Het begin is dus: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, etc.
    /// 
    /// Stel dat je van alle Fibonaccigetallen tot 1.000.000.000.000.000.000 (10^18) de afzonderlijke cijfers optelt,
    /// hoe vaak komt daar een getal uit dat zelf het kwadraat is van een geheel getal?
    /// </summary>
    class Exercise2
	{
        public static Object Solve()
        {
            return FibonacciSequence.ItemsX.TakeWhile(x => x < 1000000000000000000).Count(x => x.SumDigits().SquareRoot().IsNumber());
		}
	}
}