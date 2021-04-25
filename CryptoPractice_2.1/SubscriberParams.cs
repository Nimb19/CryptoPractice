using CryptoFormulaLibrary.Models;

namespace CryptoPractice_2._1
{
    public class SubscriberParams
    {
        public SubscriberForm SubscriberForm { get; set; }
        public ElgamalSubscriber ElgamalSubscriber { get; set; }

        public SubscriberParams(SubscriberForm subscriberForm, ElgamalSubscriber elgamalSubscriber)
        {
            this.SubscriberForm = subscriberForm;
            this.ElgamalSubscriber = elgamalSubscriber;
        }
    }
}
