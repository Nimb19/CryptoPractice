using System.Numerics;
using CryptoFormulaLibrary.EDS.EDSModels;
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.EDS
{
    public class DSAResultOfEncryptionHash : IResultOfEncryptionHash
    {
        public BigInteger P { get; set; }
        public BigInteger Q { get; set; }
        public BigInteger G { get; set; }
        public BigInteger X { get; set; }
        public BigInteger K { get; set; }
        public BigInteger W { get; set; }
        public BigInteger U1 { get; set; }
        public BigInteger U2 { get; set; }
        public BigInteger V { get; set; }

        public BigInteger R { get; }
        public BigInteger S { get; }

        /// <summary> Открытый ключ отправителя. </summary>
        public BigInteger Y { get; }

        /// <summary> Хэш сообщения. </summary>
        public BigInteger M { get; }

        public DSAResultOfEncryptionHash(BigInteger r, BigInteger s, WrappedInteger y, WrappedInteger m)
        {
            R = r;
            S = s;
            Y = y.Value;
            M = m.Value;
        }
    }
}
