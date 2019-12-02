using System;
using System.Linq;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectTweakers.Problems
{
    /// <summary>
    /// Een object zweeft met een vaste snelheid van 20 punten p/s door de ruimte.
    /// Op het moment van schrijven bevindt het object zich op positie x: 30, y: 50 en z: 90.
    /// Het object beweegt naar x: 4^6, y: -4^8 en z: 9.
    /// 
    /// Wat zijn de coördinaten van het object na 25 minuten.Afgerond op 2 decimalen
    /// </summary>
    class Exercise3
	{
        public static Object Solve()
        {
            var x1 = 30;
            var x2 = Math.Pow(4, 6);
            var y1 = 50;
            var y2 = Math.Pow(-4, 8);
            var z1 = 90;
            var z2 = 9;


            var xm = x2 - x1;
            var ym = y2 - y1;
            var zm = z2 - z1;

            var normalizeFactor = Math.Sqrt(xm*xm + ym*ym + zm*zm);

            var x = (xm/normalizeFactor)*25*60*20;
            var y = (ym/normalizeFactor)*25*60*20;
            var z = (zm/normalizeFactor)*25*60*20;

            Console.WriteLine(x + x1);
            Console.WriteLine(y + y1);
            Console.WriteLine(z + z1);

            return null;
        }
	}
}