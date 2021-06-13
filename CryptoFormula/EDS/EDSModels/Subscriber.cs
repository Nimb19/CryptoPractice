using System;
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.EDS.EDSModels
{
    public abstract class Subscriber : IEDSSubscriber
    {
        public WrappedInteger OpenedKey { get; }
        public WrappedInteger ClosedKey { get; }
        public string Name { get; }

        public abstract IEDSController Controller { get; }

        public Subscriber(WrappedInteger openedKey, WrappedInteger closedKey, string name)
        {
            OpenedKey = openedKey;
            ClosedKey = closedKey;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
