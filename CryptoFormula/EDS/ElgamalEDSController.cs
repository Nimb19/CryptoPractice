using System;
using System.Numerics;
using CryptoFormulaLibrary.EDSAdapters;
using CryptoFormulaLibrary.Models;
using HelpfulLibrary;

namespace CryptoFormulaLibrary.EDS
{
    public class ElGamalEDSController : IEDSController
    {
        public ElgamalSubscriber Sender { get; set; }

        public ElGamalEDSController(ElgamalSubscriber sub)
        {
            Sender = sub;
        }

        public static BigInteger CalculateOpenedKey(WrappedInteger closedKey, int g, int p)
        {
            return g.ВозвестиВСтепень(closedKey) % p;
        }

        //public static (BigInteger R, BigInteger E) GetMessageKeys(ElgamalSubscriber to, int msg, int k)
        //{
        //    var r = to.G.ВозвестиВСтепень(k) % to.P;
        //    var e = msg * to.OpenedKey % to.P;
        //    return (r, e);
        //}

        public static (BigInteger P, BigInteger G) GenerateKeys(Random random)
        {
            PrimeNumberGenerator.PrimeRandom = random;
            var p = PrimeNumberGenerator.GeneratePrimeNumber(1000, int.MaxValue);
            var g = random.Next(2, p - 1);
            return (p, g);
        }

        public BigInteger EncryptHashCode(BigInteger hash)
        {
            //var k = PrimeNumberGenerator.GeneratePrimeNumber(1, (Sender.P - 2).ToInt32());
            //var r = Sender.G.ВозвестиВСтепень(k) % Sender.P;
            //var m = (hash * Sender.OpenedKey.ВозвестиВСтепень(k)) % (Sender.P - 1);
            return hash;
        }

        public BigInteger DecryptHashCode(BigInteger ecryptedHash)
        {
            return ecryptedHash; // TODO:
        }
    }
}
