using System;
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.EDS.EDSModels
{
    public interface IEDSSubscriber
    {
        WrappedInteger OpenedKey { get; }
        WrappedInteger ClosedKey { get; }
        string Name { get; }
        IEDSController Controller { get; }
    }
}
