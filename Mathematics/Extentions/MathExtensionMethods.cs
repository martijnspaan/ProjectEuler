using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mathematics.Common;

namespace Mathematics.Extentions
{
	public static class MathExtensionMethods
	{
		public static Fraction Multiply(this IEnumerable<Fraction> source)
		{
			return source.Aggregate(new Fraction(1, 1), (fResult, f) => new Fraction(fResult.n * f.n, fResult.d * f.d));
		}
	}
}
