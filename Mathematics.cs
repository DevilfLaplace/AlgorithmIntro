using System;
using System.Collections.Generic;

namespace AlgorithmIntro
{
    public class Mathematics
    {
        /// <summary>
        /// Finds the greatest common divisor of two given number
        /// </summary>
        /// <param name="number1">Number one</param>
        /// <param name="number2">Number two</param>
        /// <returns>( int ) Common Divisor</returns>
        public static int GCD(int number1, int number2)
        {
            int gCD = 1, gCD1 = 2;
            while (number1 != 1 || number2 != 1)
            {
                if (number1 % gCD1 == 0 && number2 % gCD1 == 0)
                {
                    gCD *= gCD1;
                    number1 /= gCD1;
                    number2 /= gCD1;
                }
                else if (number1 % gCD1 == 0)
                    number1 /= gCD1;
                else if (number2 % gCD1 == 0)
                    number2 /= gCD1;
                else
                    gCD1++;
            }
            return gCD;
        }

        /// <summary>
        /// Finds the least common factor of two given numbers
        /// </summary>
        /// <param name="number1">Number one</param>
        /// <param name="number2">Number two</param>
        /// <returns>( int ) Common Fold</returns>
        public static int LCF(int number1, int number2)
        {
            int i = 2, lCF = 1;
            while (number2 != 1 || number1 != 1)
            {
                if (number1 / i == 0 && number2 / i == 0)
                {
                    lCF *= i;
                    number1 /= i;
                    number2 /= i;
                }
                else if (number1 % i == 0)
                {
                    lCF *= i;
                    number1 /= i;
                }
                else if (number2 % i == 0)
                {
                    lCF *= i;
                    number2 /= i;
                }
                else
                    i++;
            }
            return lCF;
        }

        /// <summary>
        /// Turns the binary to decimal based system 
        /// </summary>
        /// <param name="binary">The given binnary</param>
        /// <returns>( int ) Decimal based number</returns>
        public static int FromBinary(string binary)
        {
            int output = 0, z = 0; bool check = true;
            for (int i = 0; i < binary.Length; i++)
            {
                if (!(binary[i] == '0' || binary[i] == '1'))
                {
                    check = !check;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Title = "Error!";
                    Console.Clear();
                    Console.Write("\n\n\n\n\n\t\a    Empty or Invalid Input!\n\n\t     Exit...");
                    break;
                }
            }
            if (check)
            {
                for (int i = binary.Length - 1; i >= 0; i--)
                {
                    output += Convert.ToInt32(System.Math.Pow(2, i) * Convert.ToInt32(Convert.ToString(binary[z])));
                    z++;
                }
            }
            return output;
        }

        /// <summary>
        /// Finds the divisors of the number
        /// </summary>
        /// <param name="dividingNumber">Number</param>
        /// <returns>( List<int> ) Divisors</returns>
        public static List<int> PrimeDivisors(int dividingNumber)
        {
            List<int> multipliers = new List<int>(); int divisor = 2;
            while (dividingNumber > 1)
            {
                if (dividingNumber % divisor == 0)
                {
                    if (!(multipliers.Contains(divisor)))
                    {
                        multipliers.Add(divisor);
                    }
                    dividingNumber /= divisor;
                }
                else
                    divisor++;
            }
            return multipliers;
        }

    }
}