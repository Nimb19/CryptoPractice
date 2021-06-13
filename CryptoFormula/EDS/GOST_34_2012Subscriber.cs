using System;
using System.Collections.Generic;
using System.Text;
using CryptoFormulaLibrary.EDS.EDSModels;
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.EDS
{
    public class GOST_34_2012Subscriber : Subscriber
    {
        public override IEDSController Controller { get; }

        public GOST_34_2012Subscriber(WrappedInteger openedKey, WrappedInteger closedKey, string name) : base(openedKey, closedKey, name)
        {
            Controller = new GOST_34_2012EDSController(this);
        }
    }
}
