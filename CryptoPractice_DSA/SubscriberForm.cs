using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CryptoFormulaLibrary.ChatController;
using CryptoFormulaLibrary.EDS;
using CryptoFormulaLibrary.Models;

namespace CryptoPractice_DSA
{
    public partial class SubscriberForm : Form
    {
        public DSASubscriber Subscriber { get; private set; }
        public ChatController<DSASubscriber> ChatController { get; private set; }
        private DataGridView _historyGataGrid;

        private const string SubNameConst = "@name";
        private ObservableCollection<SubscriberParams> AllSubscribers;

        public SubscriberForm(ObservableCollection<SubscriberParams> collection, DSASubscriber sub, DataGridView historyGataGrid)
        {
            InitializeComponent();
            InitParams(collection, sub);
            _historyGataGrid = historyGataGrid;
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

        private void InitParams(ObservableCollection<SubscriberParams> collection, DSASubscriber sub)
        {
            AllSubscribers = collection;
            AllSubscribers.CollectionChanged += AllSubscribers_CollectionChanged;
            Subscriber = sub;

            groupBoxParams.Text = groupBoxParams.Text.Replace(SubNameConst, sub.Name);
            this.Text = this.Text.Replace(SubNameConst, sub.Name);

            tbParamP.Text = sub.P.ToString();
            tbParamG.Text = sub.G.ToString();
            tbParamQ.Text = sub.Q.ToString();
            tbOpenedKey.Text = sub.OpenedKey.ToString();
            tbClosedKey.Text = sub.ClosedKey.ToString();

            var subs = AllSubscribers.Select(x => x.Subscriber.Name).Where(x => x != sub.Name);
            subComboBox.Items.AddRange(subs.ToArray());
            ChatController = new ChatController<DSASubscriber>(sub);
            ChatController.OnNewMessage += ChatController_OnNewMessage;
            ChatController.OnNewInfo += ChatController_OnNewInfo;
        }

        private void ChatController_OnNewInfo(object sender, string e)
        {
            chatBox.Text += e;
        }

        private void ChatController_OnNewMessage(object sender, MessageEventArgs<DSASubscriber> e)
        {
            chatBox.Text += e.Message;

            if (e.From == Subscriber)
                return;

            var encryptionResult = e.ResultOfEncryptionHash as DSAResultOfEncryptionHash
                ?? throw new Exception("В сообщении передавался не тот тип");

            var parameters = new object[]
            {
                encryptionResult.M ,
                e.From.ToString()  ,
                e.To.ToString()    ,
                encryptionResult.P ,
                encryptionResult.Q ,
                encryptionResult.G ,
                encryptionResult.X ,
                encryptionResult.Y ,
                encryptionResult.K ,
                encryptionResult.R ,
                encryptionResult.S ,
                encryptionResult.W ,
                encryptionResult.U1,
                encryptionResult.U2,
                encryptionResult.V ,
                };

            _historyGataGrid?.Rows?.Add(parameters);
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
