using System.Numerics;
using CryptoFormulaLibrary.EDS.EDSAdapters;

namespace CryptoFormulaLibrary.EDS
{
    public class ElgamalResultOfEncryptionHash : IResultOfEncryptionHash
    {
        public BigInteger R { get; set; }
        public BigInteger E { get; set; }

        public ElgamalResultOfEncryptionHash(BigInteger r, BigInteger e)
        {
            R = r;
            E = e;
        }
    }
}
