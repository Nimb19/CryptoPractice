using System.Collections.Generic;
using System.Numerics;
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary
{
    public static partial class CryptoFormula
    {
        public static List<int> РазложитьНаПростыеМножители(this WrappedInteger num)
        {
            var listDivisors = new List<int>();

            for (; num % 2 == 0; num /= 2)
                listDivisors.Add(2);

            for (int i = 3; i <= num;)
            {
                if (num % i == 0)
                {
                    listDivisors.Add(i);
                    num /= i;
                }
                else
                    i += 2;
            }

            return listDivisors;
        }

        /// <summary> Нахождение наибольшего общего делителя чисел a и b. </summary>
        public static BigInteger НайтиНОД(WrappedInteger a, WrappedInteger b)
        {
            if (a == 0) return b.Value;
            else if (b == 0) return a.Value;

            else return НайтиНОД(b, a % b);
        }

        public static BigInteger ВозвестиВСтепень(this WrappedInteger x, WrappedInteger y)
        {
            BigInteger result = x.Value;
            for (int i = 2; i <= y; i++)
                result *= x.Value;

            return result;
        }
    }
}
