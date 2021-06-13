using CryptoFormulaLibrary.EDS;
using CryptoFormulaLibrary.EDS.EDSModels;

namespace CryptoFormulaLibrary.Models
{
    public class ElgamalSubscriber : Subscriber
    {
        public WrappedInteger P { get; }
        public WrappedInteger G { get; }

        public override IEDSController Controller { get; }

        public ElgamalSubscriber(WrappedInteger openedKey, WrappedInteger closedKey, string name, 
            WrappedInteger p, WrappedInteger g) : base(openedKey, closedKey, name)
        {
            P = p;
            G = g;
            Controller = new ElgamalEDSController(this);
        }
    }
}
