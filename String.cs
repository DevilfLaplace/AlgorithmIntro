using System;
using System.Collections.Generic;

namespace AlgorithmIntro
{
    public class String
    {
        /// <summary>
        /// Finds the divisors of the number
        /// </summary>
        /// <param name="number">Number</param>
        /// <returns>( int[] ) Divisors</returns>
        public static int[] PrimeDivisors(int number)
        {
            string divisorsList = "";
            int i = 2;
            while (number > 1)
            {
                if (number % i == 0)
                {
                    number /= i;
                    divisorsList += i.ToString() + ",";
                }
                else
                    i++;
            }
            divisorsList = divisorsList[0..^1];
            string[] divisors = divisorsList.Split(",");

            string same = divisors[0];
            string exclusives = same;

            for (i = 0; i < divisors.Length; i++)
            {
                if (!(same == divisors[i]))
                {
                    exclusives += "," + divisors[i];
                    same = divisors[i];
                }
            }
            divisors = exclusives.Split(",");
            int[] eXclusives = new int[divisors.Length];
            i = 0;
            foreach (var item in divisors)
            {
                eXclusives[i] = Convert.ToInt32(item);
                i++;
            }
            return eXclusives;
        }

        /// <summary>
        /// Finds the vowels count in input
        /// </summary>
        /// <param name="input">word or string of words</param>
        /// <returns>( int ) Count</returns>
        public static int NumberOfVowels(string input)
        {
            List<char> vowel = new List<char> { 'a', 'e', 'o', 'u', 'i' };
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (vowel.Contains(input[i]))
                    sum++;
            }
            return sum;
        }
    }
}
