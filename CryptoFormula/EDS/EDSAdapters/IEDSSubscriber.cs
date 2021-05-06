
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.EDSAdapters
{
    public interface IEDSSubscriber
    {
        WrappedInteger OpenedKey { get; }
        WrappedInteger ClosedKey { get; }
        string Name { get; }
        IEDSController Controller { get; }
    }
}
