using System.Numerics;
using CryptoFormulaLibrary.EDS.EDSModels;
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.EDS
{
    public class ElgamalResultOfEncryptionHash : IResultOfEncryptionHash
    {
        public BigInteger A { get; }
        public BigInteger B { get; }

        public BigInteger Y { get; }
        public BigInteger M { get; }

        public ElgamalResultOfEncryptionHash(BigInteger a, BigInteger b, WrappedInteger y, WrappedInteger hash)
        {
            A = a;
            B = b;
            Y = y.Value;
            M = hash.Value;
        }
    }
}
