using System;
using System.Linq;
using Mathematics.Extentions;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;

namespace AdventOfCode.Problems.Day4
{
    /// <summary>
    /// You arrive at the Venus fuel depot only to discover it's protected by a password. The Elves had written the password on a sticky note, but someone threw it out.
    /// 
    /// However, they do remember a few key facts about the password:
    /// 
    /// It is a six-digit number.
    /// The value is within the range given in your puzzle input.
    /// Two adjacent digits are the same (like 22 in 122345).
    /// Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).
    /// Other than the range rule, the following are true:
    /// 
    /// 111111 meets these criteria(double 11, never decreases).
    /// 223450 does not meet these criteria(decreasing pair of digits 50).
    /// 123789 does not meet these criteria(no double).
    /// How many different passwords within the range given in your puzzle input meet these criteria?
    /// </summary>
    class Part1
	{
        private static int passwordRangeStart = 278384;
        private static int passwordRangeEnd = 824795;

        public static Object Solve()
        {
            int foundPasswords = 0;

            Parallel.For(passwordRangeStart, passwordRangeEnd + 1, new ParallelOptions { MaxDegreeOfParallelism = 1 }, password => {
                if (IsValidPassword(password))
                {
                    Interlocked.Increment(ref foundPasswords);
                }
            });

            return foundPasswords;
		}

        private static bool IsValidPassword(int password)
        {
            string stringPassword = password.ToString();
            bool foundDouble = false;

            for (int i = 1; i < stringPassword.Length; i++)
            {
                if (stringPassword[i] < stringPassword[i - 1]) return false;
                if (stringPassword[i] == stringPassword[i - 1]) foundDouble = true;
            }

            return foundDouble;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class Part2
    {
        private static int passwordRangeStart = 278384;
        private static int passwordRangeEnd = 824795;

        public static Object Solve()
        {
            int foundPasswords = 0;

            Parallel.For(passwordRangeStart, passwordRangeEnd + 1, new ParallelOptions { MaxDegreeOfParallelism = 1 }, password => {
                if (IsValidPassword(password))
                {
                    Interlocked.Increment(ref foundPasswords);
                }
            });

            return foundPasswords;
        }

        private static bool IsValidPassword(int password)
        {
            string stringPassword = password.ToString();

            for (int i = 1; i < stringPassword.Length; i++)
            {
                if (stringPassword[i] < stringPassword[i - 1]) return false;                
            }

            for (int i = 1; i < stringPassword.Length; i++)
            {
                if (stringPassword[i] == stringPassword[i - 1] && stringPassword.Count(c => c == stringPassword[i]) == 2) return true;
            }

            return false;
        }
    }
}