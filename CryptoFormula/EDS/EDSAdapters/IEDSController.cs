using System.Numerics;
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.EDS.EDSAdapters
{
    public interface IEDSController
    {
        IResultOfEncryptionHash EncryptHashCode(BigInteger hashCode, WrappedInteger recipientOpenedKey);
        BigInteger DecryptHashCode(IResultOfEncryptionHash resultOfEncryptionHash);
    }
}
