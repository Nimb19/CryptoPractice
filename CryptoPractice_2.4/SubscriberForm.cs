using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CryptoFormulaLibrary.ChatController;
using CryptoFormulaLibrary.EDS;

namespace CryptoPractice_GOST_34_2012
{
    public partial class SubscriberForm : Form
    {
        public GOST_34_2012Subscriber Subscriber { get; private set; }
        public ChatController<GOST_34_2012Subscriber> ChatController { get; private set; }

        private const string SubNameConst = "@name";
        private ObservableCollection<SubscriberParams> AllSubscribers;

        public SubscriberForm(ObservableCollection<SubscriberParams> collection, GOST_34_2012Subscriber sub)
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
                    var sub = (element as SubscriberParams).Subscriber;
                    if (Subscriber.Name != sub.Name)
                        subComboBox.Items.Add(sub.Name);
                }
            }

            var oldCollection = (IList)e.OldItems?.SyncRoot;
            if (oldCollection != null)
            {
                foreach (var element in oldCollection)
                {
                    var sub = (element as SubscriberParams).Subscriber;
                    subComboBox.Items.Remove(sub.Name);
                }
            }
        }

        private void InitParams(ObservableCollection<SubscriberParams> collection, GOST_34_2012Subscriber sub)
        {
            AllSubscribers = collection;
            AllSubscribers.CollectionChanged += AllSubscribers_CollectionChanged;
            Subscriber = sub;

            groupBoxParams.Text = groupBoxParams.Text.Replace(SubNameConst, sub.Name);
            this.Text = this.Text.Replace(SubNameConst, sub.Name);

            tbOpenedKey.Text = sub.OpenedKey.ToString();
            tbClosedKey.Text = sub.ClosedKey.ToString();

            var subs = AllSubscribers.Select(x => x.Subscriber.Name).Where(x => x != sub.Name);
            subComboBox.Items.AddRange(subs.ToArray());
            ChatController = new ChatController<GOST_34_2012Subscriber>(sub);
            ChatController.OnNewMessage += ChatController_OnNewMessage;
            ChatController.OnNewInfo += ChatController_OnNewInfo;
        }

        private void ChatController_OnNewInfo(object sender, string e)
        {
            chatBox.Text += e;
        }

        private void ChatController_OnNewMessage(object sender, MessageEventArgs<GOST_34_2012Subscriber> e)
        {
            chatBox.Text += e.Message;
        }

        private void ButtonSendMessage_Click(object sender, EventArgs e)
        {
            CatchException(() =>
            {
                var selectedRecipientName = subComboBox.SelectedItem.ToString();
                var recipient = AllSubscribers.First(x => x.Subscriber.Name == selectedRecipientName);
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
