using CryptoFormulaLibrary.EDS;
using CryptoFormulaLibrary.EDS.EDSModels;

namespace CryptoFormulaLibrary.Models
{
    public class DSASubscriber : Subscriber
    {
        public WrappedInteger P { get; }
        public WrappedInteger Q { get; }
        public WrappedInteger G { get; }

        public override IEDSController Controller { get; }

        public DSASubscriber(WrappedInteger openedKey, WrappedInteger closedKey, string name, 
            WrappedInteger p, WrappedInteger q, WrappedInteger g) : base(openedKey, closedKey, name)
        {
            P = p;
            G = g;
            Q = q;
            Controller = new DSAEDSController(this);
        }
    }
}
