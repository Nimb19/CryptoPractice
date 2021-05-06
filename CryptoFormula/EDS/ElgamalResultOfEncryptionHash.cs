using System.Numerics;
using CryptoFormulaLibrary.EDS.EDSModels;

namespace CryptoFormulaLibrary.EDS
{
    internal class ElgamalResultOfEncryptionHash : IResultOfEncryptionHash
    {
        public BigInteger R { get; }
        public BigInteger E { get; }

        public ElgamalResultOfEncryptionHash(BigInteger r, BigInteger e)
        {
            R = r;
            E = e;
        }
    }
}
