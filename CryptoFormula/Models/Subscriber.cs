using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CryptoFormulaLibrary.Models
{
    public abstract class Subscriber
    {
        public WrappedInteger OpenedKey { get; }
        public WrappedInteger ClosedKey { get; }
        public string Name { get; }

        public Subscriber(WrappedInteger openedKey, WrappedInteger closedKey, string name)
        {
            OpenedKey = openedKey;
            ClosedKey = closedKey;
            Name = name;
        }
    }
}
