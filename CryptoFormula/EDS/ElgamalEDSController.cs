using System;
using System.Numerics;
using CryptoFormulaLibrary.EDS.EDSModels;
using CryptoFormulaLibrary.Models;
using HelpfulLibrary;

namespace CryptoFormulaLibrary.EDS
{
    public class ElgamalEDSController : IEDSController
    {
        public ElgamalSubscriber CurrentSub { get; set; }

        public ElgamalEDSController(ElgamalSubscriber sub)
        {
            CurrentSub = sub;
        }

        public IResultOfEncryptionHash EncryptHashCode(BigInteger hash, WrappedInteger recipientOpenedKey)
        {
            var k = PrimeNumberGenerator.GeneratePrimeNumber(1, (CurrentSub.P - 2).ToInt32());
            var r = CurrentSub.G.ВозвестиВСтепень(k) % CurrentSub.P;
            var e = (hash * recipientOpenedKey.ВозвестиВСтепень(k)) % (CurrentSub.P - 1);

            return new ElgamalResultOfEncryptionHash(r, e);
        }

        public BigInteger DecryptHashCode(IResultOfEncryptionHash resultOfEncryptionHash)
        {
            var hashRes = resultOfEncryptionHash as ElgamalResultOfEncryptionHash 
                ?? throw new ArgumentException("Результат хеша был не того типа.");

            var r = hashRes.R;
            var e = hashRes.E;
            var p = CurrentSub.P;
            var closedKey = CurrentSub.ClosedKey;

            var decryptedHash = (e * r.ВозвестиВСтепень(p - 1 - closedKey)) % p;
            return decryptedHash;
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
    }
}
