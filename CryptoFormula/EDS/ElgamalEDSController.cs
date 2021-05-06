using System;
using System.Numerics;
using CryptoFormulaLibrary.EDSAdapters;
using CryptoFormulaLibrary.Models;
using HelpfulLibrary;

namespace CryptoFormulaLibrary.EDS
{
    public class ElGamalEDSController : IEDSController
    {
        public ElgamalSubscriber CurrentSub { get; set; }

        public ElGamalEDSController(ElgamalSubscriber sub)
        {
            CurrentSub = sub;
        }

        public static BigInteger CalculateOpenedKey(WrappedInteger closedKey, int g, int p)
        {
            return g.ВозвестиВСтепень(closedKey) % p;
        }

        public static (BigInteger P, BigInteger G) GenerateKeys(Random random)
        {
            PrimeNumberGenerator.PrimeRandom = random;
            var p = PrimeNumberGenerator.GeneratePrimeNumber(50, 5000);
            var g = random.Next(2, p - 1);
            return (p, g);
        }

        public BigInteger[] EncryptHashCode(ElgamalSubscriber to, BigInteger hash)
        {
            var resultCollection = new BigInteger[2];

            var k = PrimeNumberGenerator.GeneratePrimeNumber(1, (CurrentSub.P - 2).ToInt32());
            var r = to.G.ВозвестиВСтепень(k) % to.P;
            var e = (hash * to.OpenedKey.ВозвестиВСтепень(k)) % (CurrentSub.P - 1);

            resultCollection[0] = r;
            resultCollection[1] = e;
            return resultCollection;
        }

        public BigInteger DecryptHashCode(ElgamalSubscriber from, BigInteger[] encryptedHashResultCollection)
        {
            var r = encryptedHashResultCollection[0];
            var e = encryptedHashResultCollection[1];
            var decryptedHash = (e * r.ВозвестиВСтепень(CurrentSub.P - 1 - CurrentSub.ClosedKey)) % CurrentSub.P;
            return decryptedHash;
        }

        public BigInteger[] EncryptHashCode(IEDSSubscriber to, BigInteger hashCode)
        {
            return EncryptHashCode(to as ElgamalSubscriber ?? throw new ArgumentException(), hashCode);
        }

        public BigInteger DecryptHashCode(IEDSSubscriber from, BigInteger[] ecryptedHashNums)
        {
            return DecryptHashCode(from as ElgamalSubscriber ?? throw new ArgumentException(), ecryptedHashNums);
        }
    }
}
