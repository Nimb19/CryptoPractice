using System;
using System.Numerics;

using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.CryptosystemControllers
{
    public static class ElgamalCryptosystemController
    {
        public static WrappedInteger CalculateOpenedKey(WrappedInteger closedKey, int g, int p) => 
            g.ВозвестиВСтепень(closedKey) % p;

        public static (WrappedInteger R, WrappedInteger E) GetMessage(ElgamalSubscriber from, ElgamalSubscriber to, int msg, int k)
        {
            var r = to.G.ВозвестиВСтепень(k) % to.P;
            var e = msg * to.OpenedKey % to.P;
            return (r, e);
        }

        public static (BigInteger P, BigInteger G) GenerateKeys(Random random)
        {
            PrimeNumberGenerator.PrimeRandom = random;
            var p = PrimeNumberGenerator.GeneratePrimeNumber();
            var g = random.Next(2, (int)p - 1);
            return (p, g);
        }
    }
}
