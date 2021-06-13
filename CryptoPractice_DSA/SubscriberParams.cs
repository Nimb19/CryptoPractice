using CryptoFormulaLibrary.Models;

namespace CryptoPractice_DSA
{
    public class SubscriberParams
    {
        public SubscriberForm SubscriberForm { get; set; }
        public DSASubscriber Subscriber { get; set; }

        public SubscriberParams(SubscriberForm subscriberForm, DSASubscriber subscriber)
        {
            this.SubscriberForm = subscriberForm;
            this.Subscriber = subscriber;
        }
    }
}
