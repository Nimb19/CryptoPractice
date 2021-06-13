using System.Numerics;
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.EDS.EDSModels
{
    public interface IEDSController
    {
        IResultOfEncryptionHash EncryptHashCode(BigInteger hashCode, WrappedInteger recipientOpenedKey);
        bool DecryptHashCode(IResultOfEncryptionHash resultOfEncryptionHash);
    }
}
