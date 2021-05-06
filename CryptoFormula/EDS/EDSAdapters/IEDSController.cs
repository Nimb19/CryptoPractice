using System.Numerics;
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.EDSAdapters
{
    public interface IEDSController
    {
        BigInteger[] EncryptHashCode(IEDSSubscriber to, BigInteger hashCode);
        BigInteger DecryptHashCode(IEDSSubscriber from, BigInteger[] ecryptedHashNums);
    }
}
