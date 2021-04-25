using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoFormulaLibrary.Models
{
    public class ElgamalSubscriber : Subscriber
    {
        public WrappedInteger P { get; }
        public WrappedInteger G { get; }

        public ElgamalSubscriber(WrappedInteger openedKey, WrappedInteger closedKey, string name, 
            WrappedInteger p, WrappedInteger g) : base(openedKey, closedKey, name)
        {
            P = p;
            G = g;
        }
    }
}
