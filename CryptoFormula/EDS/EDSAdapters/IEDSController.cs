using System.Numerics;

namespace CryptoFormulaLibrary.EDSAdapters
{
    public interface IEDSController
    {
        BigInteger EncryptHashCode(BigInteger hashCode);
        BigInteger DecryptHashCode(BigInteger ecryptedHash);
    }
}
