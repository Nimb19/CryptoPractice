using System;
using System.Numerics;

using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.CryptosystemControllers
{
    public static class ElgamalCryptosystemController
    {
        public static WrappedInteger CalculateOpenedKey(WrappedInteger closedKey, int g, int p) => 
            g.ВозвестиВСтепень(closedKey) % p;

        public static (WrappedInteger R, WrappedInteger E) GetMessageKeys(ElgamalSubscriber from, ElgamalSubscriber to, int msg, int k)
        {
            var r = to.G.ВозвестиВСтепень(k) % to.P;
            var e = msg * to.OpenedKey % to.P;
            return (r, e);
        }

        public static (BigInteger P, BigInteger G) GenerateKeys(Random random)
        {
            PrimeNumberGenerator.PrimeRandom = random;
            var p = PrimeNumberGenerator.GeneratePrimeNumber(1000, int.MaxValue);
            var g = random.Next(2, p - 1);
            return (p, g);
        }
    }
}
