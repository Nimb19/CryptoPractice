using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using CryptoFormulaLibrary.EDS.EDSModels;
using CryptoFormulaLibrary.Models;

namespace CryptoFormulaLibrary.EDS
{
    public class GOST_34_2012EDSController : IEDSController 
    {
        public GOST_34_2012Subscriber Subscriber { get; }

        public GOST_34_2012EDSController(GOST_34_2012Subscriber subscriber)
        {
            Subscriber = subscriber;
        }

        public IResultOfEncryptionHash EncryptHashCode(BigInteger hashCode, WrappedInteger recipientOpenedKey)
        {
            throw new NotImplementedException();
        }

        public bool DecryptHashCode(IResultOfEncryptionHash resultOfEncryptionHash)
        {
            throw new NotImplementedException();
        }
    }
}
