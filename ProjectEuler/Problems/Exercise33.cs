using System;
using System.Linq;
using Mathematics.Common;
using Mathematics.Extentions;
using Mathematics.Lists;

namespace ProjectEuler.Problems
{
	/// <summary>
	/// The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it,
	/// may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.
	/// 
	/// We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
	/// 
	/// There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.
	/// 
	/// If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
	/// </summary>
	class Exercise33
	{
		public static Object Solve()
		{
			return FiniteIntList.GetItems(2, 9).SelectMany(d => FiniteIntList.GetItems(d - 1, 1).Select(n => new Fraction(n, d))) // Generates a list of all possible lowest term fractions (4/8)
											   .Select(f => new // Expands all lowest term fractions to include all possible higher term fractions (49/98)
															   {
																   f,
																   fl = FiniteIntList.GetItems(1, 9).Select(p => new Fraction(f.n + p * 10, f.d + p * 10)).Concat(
																		FiniteIntList.GetItems(1, 9).Select(p => new Fraction(f.n + p * 10, f.d * 10 + p))).Concat(
																		FiniteIntList.GetItems(1, 9).Select(p => new Fraction(f.n * 10 + p, f.d + p * 10))).Concat(
																		FiniteIntList.GetItems(1, 9).Select(p => new Fraction(f.n * 10 + p, f.d * 10 + p)))
																									.Where(l => l.n < l.d)
															   })
												.SelectMany(o => o.fl.Where(fl => fl == o.f)) // Select all higher term fractions that equal their lower term fraction
												.Multiply()
												.Normalize()
												.Denominator;
		}
	}
}
