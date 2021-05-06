using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using CryptoFormulaLibrary.ChatController;
using CryptoFormulaLibrary.Models;

namespace CryptoPractice_2._1
{
    public partial class SubscriberForm : Form
    {
        public ElgamalSubscriber Subscriber { get; private set; }
        public ChatController<ElgamalSubscriber> ChatController { get; private set; }

        private const string SubNameConst = "@name";
        private ObservableCollection<SubscriberParams> AllSubscribers;

        public SubscriberForm(ObservableCollection<SubscriberParams> collection, ElgamalSubscriber sub)
        {
            InitializeComponent();
            InitParams(collection, sub);
        }

        private void AllSubscribers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var newCollection = (IList)e.NewItems?.SyncRoot;
            if (newCollection != null) 
            {
                foreach (var element in newCollection)
                {
                    var sub = (element as SubscriberParams).ElgamalSubscriber;
                    if (Subscriber.Name != sub.Name)
                        subComboBox.Items.Add(sub.Name);
                }
            }

            var oldCollection = (IList)e.OldItems?.SyncRoot;
            if (oldCollection != null)
            {
                foreach (var element in oldCollection)
                {
                    var sub = (element as SubscriberParams).ElgamalSubscriber;
                    subComboBox.Items.Remove(sub.Name);
                }
            }
        }

        private void InitParams(ObservableCollection<SubscriberParams> collection, ElgamalSubscriber sub)
        {
            AllSubscribers = collection;
            AllSubscribers.CollectionChanged += AllSubscribers_CollectionChanged;
            Subscriber = sub;

            groupBoxParams.Text = groupBoxParams.Text.Replace(SubNameConst, sub.Name);
            this.Text = this.Text.Replace(SubNameConst, sub.Name);

            tbParamP.Text = sub.P.ToString();
            tbParamG.Text = sub.G.ToString();
            tbOpenedKey.Text = sub.OpenedKey.ToString();
            tbClosedKey.Text = sub.ClosedKey.ToString();

            var subs = AllSubscribers.Select(x => x.ElgamalSubscriber.Name).Where(x => x != sub.Name);
            subComboBox.Items.AddRange(subs.ToArray());
            ChatController = new ChatController<ElgamalSubscriber>(sub);
            ChatController.OnNewMessage += ChatController_OnNewMessage;
            ChatController.OnNewInfo += ChatController_OnNewInfo;
        }

        private void ChatController_OnNewInfo(object sender, string e)
        {
            chatBox.Text += e;
        }

        private void ChatController_OnNewMessage(object sender, MessageEventArgs<ElgamalSubscriber> e)
        {
            chatBox.Text += e.Message;
        }

        private void ButtonSendMessage_Click(object sender, EventArgs e)
        {
            CatchException(() =>
            {
                var selectedRecipientName = subComboBox.SelectedItem.ToString();
                var recipient = AllSubscribers.First(x => x.ElgamalSubscriber.Name == selectedRecipientName);
                var text = tbMessage.Text.Trim();
                ChatController.WriteMessageTo(recipient.SubscriberForm.ChatController, text);
            });
        }

        private void CatchException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
