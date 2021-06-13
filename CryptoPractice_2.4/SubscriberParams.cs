using CryptoFormulaLibrary.EDS;
using CryptoFormulaLibrary.Models;

namespace CryptoPractice_GOST_34_2012
{
    public class SubscriberParams
    {
        public SubscriberForm SubscriberForm { get; set; }
        public GOST_34_2012Subscriber Subscriber { get; set; }

        public SubscriberParams(SubscriberForm subscriberForm, GOST_34_2012Subscriber subscriber)
        {
            this.SubscriberForm = subscriberForm;
            this.Subscriber = subscriber;
        }
    }
}
