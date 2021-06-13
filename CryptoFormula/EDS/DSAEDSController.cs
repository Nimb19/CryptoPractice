using System;
using System.Linq;
using System.Numerics;
using CryptoFormulaLibrary.EDS.EDSModels;
using CryptoFormulaLibrary.Models;
using HelpfulLibrary;

namespace CryptoFormulaLibrary.EDS
{
    public class DSAEDSController : IEDSController
    {
        public DSASubscriber Subscriber { get; }

        public DSAEDSController(DSASubscriber sub)
        {
            Subscriber = sub;
        }

        public IResultOfEncryptionHash EncryptHashCode(BigInteger hash, WrappedInteger recipientOpenedKey)
        {
            var p = Subscriber.P;
            var g = Subscriber.G;
            var q = Subscriber.Q;
            var x = Subscriber.ClosedKey;
            var y = Subscriber.OpenedKey;

            var k = PrimeNumberGenerator.GeneratePrimeNumber(1, (q - 1).ToInt32()); // 3;

            //hash = 9;

            var r = (g.ВСтепень(k) % p) % q;
            var inverseK = (CryptoFormula.АлгоритмЕвклида(q, k, out var euErr) ?? throw new Exception(euErr));
            var s = inverseK * (hash + ((x * r) % q)) % q;

            var result = new DSAResultOfEncryptionHash(r, s, Subscriber.OpenedKey, hash)
            {
                P = Subscriber.P.Value,
                Q = Subscriber.G.Value,
                G = Subscriber.Q.Value,
                K = k,
                X = Subscriber.ClosedKey.Value,
            };

            return result;
        }

        public bool DecryptHashCode(IResultOfEncryptionHash resultOfEncryptionHash)
        {
            var hashRes = resultOfEncryptionHash as DSAResultOfEncryptionHash
                ?? throw new ArgumentException("Результат хеша был не того типа.");

            var p = Subscriber.P;
            var q = Subscriber.Q;
            var g = Subscriber.G;
            var y = hashRes.Y; // открытый ключ отправителя
            var m = hashRes.M; // хэш

            var r = hashRes.R;
            var s = hashRes.S;

            var w = (CryptoFormula.АлгоритмЕвклида(q, s, out var euErr) ?? throw new Exception(euErr));
            var u1 = ((m % q) * (w % q)) % q;
            var u2 = ((r % q) * (w % q)) % q;

            ////                   (g.ВСтепень(u1) mod p) mod q
            //var v = (((((((g % p) % q).ВСтепень((u1 % p) % q)) % p) % q) 
            ////                   (y.ВСтепень(u2) mod p) mod q
            //    *   (((((y % p) % q).ВСтепень((u2 % p) % q)) % p) % q)) 
            //                                                            % p) % q;

            var v = ((g.ВСтепень(u1) * y.ВСтепень(u2)) %p) % q;

            hashRes.W = w;
            hashRes.U1 = u1;
            hashRes.U2 = u2;
            hashRes.V = v;

            return v == r;
        }

        public static BigInteger CalculateOpenedKey(WrappedInteger closedKey, int g, int p)
        {
            return g.ВСтепень(closedKey) % p;
        }

        public static (BigInteger P, BigInteger Q, BigInteger G) GenerateParams(Random random)
        {
            PrimeNumberGenerator.PrimeRandom = random;            
            var p = PrimeNumberGenerator.GeneratePrimeNumber(100, 1000); // (1000000, int.MaxValue); // 
            var q = (p - 1).РазложитьНаПростыеМножители().Max();
            var h = random.Next(1, p - 2);

            var getG = new Func<BigInteger>(() => { return h.ВСтепень((p - 1) / q) % p; });
            var g = getG();

            while (g < 2)
            {
                p = PrimeNumberGenerator.GeneratePrimeNumber(100, 1000);
                q = (p - 1).РазложитьНаПростыеМножители().Max();
                h = random.Next(1, p - 2);
                g = getG();
            }

            return (p, q, g);
        }
    }
}
