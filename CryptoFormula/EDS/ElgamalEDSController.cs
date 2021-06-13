using System;
using System.Numerics;
using CryptoFormulaLibrary.EDS.EDSModels;
using CryptoFormulaLibrary.Models;
using HelpfulLibrary;

namespace CryptoFormulaLibrary.EDS
{
    public class ElgamalEDSController : IEDSController
    {
        public ElgamalSubscriber Subscriber { get; }

        public ElgamalEDSController(ElgamalSubscriber sub)
        {
            Subscriber = sub;
        }

        public IResultOfEncryptionHash EncryptHashCode(BigInteger hash, WrappedInteger recipientOpenedKey)
        {
            var p = Subscriber.P;
            var g = Subscriber.G;
            //var k = 9;
            WrappedInteger k = PrimeNumberGenerator.GeneratePrimeNumber(1, (p - 2).ToInt32());
            while (CryptoFormula.НайтиНОД(k, p - 1) != 1)
                k = PrimeNumberGenerator.GeneratePrimeNumber(1, (p - 2).ToInt32());
            k %= p - 1;
            hash %= p - 1;

            var a = g.ВСтепень(k) % p;
            var b = (CryptoFormula.АлгоритмЕвклида(p - 1, k, out var euErr) ?? throw new Exception(euErr))
                * ((p - 1) + (hash - ((Subscriber.ClosedKey * a) % (p - 1)))) % (p - 1);

            return new ElgamalResultOfEncryptionHash(a, b, Subscriber.OpenedKey, hash);
        }

        public bool DecryptHashCode(IResultOfEncryptionHash resultOfEncryptionHash)
        {
            var hashRes = resultOfEncryptionHash as ElgamalResultOfEncryptionHash 
                ?? throw new ArgumentException("Результат хеша был не того типа.");

            var p = Subscriber.P;
            var a = hashRes.A;
            var b = hashRes.B;
            var y = hashRes.Y;
            var g = Subscriber.G;
            var m = hashRes.M;

            var leftSolution = (y.ВСтепень(a) % p) * (a.ВСтепень(b) % p) % p;
            var rightSolution = (g.ВСтепень(m) % p);
            return leftSolution == rightSolution;
        }

        public static BigInteger CalculateOpenedKey(WrappedInteger closedKey, int g, int p)
        {
            return g.ВСтепень(closedKey) % p;
        }

        public static (BigInteger P, BigInteger G) GenerateKeys(Random random)
        {
            PrimeNumberGenerator.PrimeRandom = random;
            var p = PrimeNumberGenerator.GeneratePrimeNumber(100, 1000); // (1000000, int.MaxValue); // 
            var g = random.Next(2, p - 1);
            return (p, g);
        }
    }
}
