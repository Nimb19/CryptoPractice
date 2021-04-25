using System;
using System.Collections.Generic;
using System.Text;

using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary
{
    public static class PrimeNumberGenerator
    {
        public static Random PrimeRandom = new Random();

        public static uint GeneratePrimeNumber(Random random = null)
        {
            var rnd = random ?? PrimeRandom;

            var numberBytes = new byte[4];
            rnd.NextBytes(numberBytes);
            uint number = BitConverter.ToUInt32(numberBytes, 0);

            while (!IsPrime(number))
            {
                unchecked
                {
                    number++;
                }
            }
            return number;
        }

        public static int GeneratePrimeNumber(int from, int to, Random random = null)
        {
            var rnd = random ?? PrimeRandom;

            var number = rnd.Next(from, to);
            while (!IsPrime(number))
            {
                unchecked
                {
                    number++;
                }
            }
            return number;
        }

        public static bool IsPrime(WrappedInteger num)
        {
            var number = num.Value;
            if ((number & 1) == 0) return (number == 2);

            var limit = Math.Sqrt((double)number);
            for (uint i = 3; i <= limit; i += 2)
                if ((number % i) == 0) 
                    return false;

            return true;
        }

        public static bool IsPrime(int number)
        {
            return IsPrime((WrappedInteger)number);
        }
    }
}
