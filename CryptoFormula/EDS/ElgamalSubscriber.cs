﻿using CryptoFormulaLibrary.EDS;
using CryptoFormulaLibrary.EDSAdapters;

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
            Controller = new ElGamalEDSController(this);
        }
    }
}