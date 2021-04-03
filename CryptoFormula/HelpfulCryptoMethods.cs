using System.Collections.Generic;
using System.Numerics;

namespace CryptoFormula
{
    public static partial class CryptoFormula
    {
        public static List<int> РазложитьНаПростыеМножители(this int module)
        {
            var listDivisors = new List<int>();

            for (; module % 2 == 0; module /= 2)
                listDivisors.Add(2);

            for (int i = 3; i <= module;)
            {
                if (module % i == 0)
                {
                    listDivisors.Add(i);
                    module /= i;
                }
                else
                    i += 2;
            }

            return listDivisors;
        }

        /// <summary> Нахождение наибольшего общего делителя чисел a и b. </summary>
        public static BigInteger НОД(int a, int b)
        {
            if (a == 0) return b;
            else if (b == 0) return a;

            else return НОД(b, a % b);
        }

        private static BigInteger ВозвестиВСтепень(this int x, int y)
        {
            BigInteger result = x;
            for (int i = 2; i <= y; i++)
                result *= x;

            return result;
        }
    }
}
