using System;

namespace Mathematics.Common
{
	public class Fraction
	{
		public Int64 Numerator { get; set; }
		public Int64 Denominator { get; set; }

		public Int64 n { get { return Numerator; } }
		public Int64 d { get { return Denominator; } }

		public float Value { get { return (float)Numerator/Denominator; } }

		public Fraction(Int64 numerator, Int64 denominator)
		{
			Numerator = numerator;
			Denominator = denominator;
		}

		public Fraction Normalize()
		{
			var frac = new Fraction(Numerator, Denominator);
			if (frac.Numerator == 0)
			{
				frac.Denominator = 1;
			}
			else
			{
				long iGCD = GCD(frac.Numerator, frac.Denominator);
				frac.Numerator /= iGCD;
				frac.Denominator /= iGCD;

				if (frac.Denominator < 0) // if -ve sign in denominator
				{
					//pass -ve sign to numerator
					frac.Numerator *= -1;
					frac.Denominator *= -1;
				}
			}
			return frac;
		}

		public override int GetHashCode()
		{
			return Numerator.GetHashCode() ^ Denominator.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is Fraction))return false;
			return Value == ((Fraction) obj).Value;
		}

		public static bool operator ==(Fraction a, Fraction b)
		{
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			if (((object)a == null) || ((object)b == null))
			{
				return false;
			}

			// Return true if the fields match:
			return a.Equals(b);
		}

		public static bool operator !=(Fraction a, Fraction b)
		{
			return !(a == b);
		}

		/// <summary>
		/// The function returns GCD of two numbers (used for reducing a Fraction)
		/// </summary>
		private static long GCD(long iNo1, long iNo2)
		{
			// take absolute values
			if (iNo1 < 0) iNo1 = -iNo1;
			if (iNo2 < 0) iNo2 = -iNo2;

			do
			{
				if (iNo1 < iNo2)
				{
					long tmp = iNo1;  // swap the two operands
					iNo1 = iNo2;
					iNo2 = tmp;
				}
				iNo1 = iNo1 % iNo2;
			} while (iNo1 != 0);
			return iNo2;
		}
	}
}
