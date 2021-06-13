using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using CryptoFormulaLibrary;
using CryptoFormulaLibrary.EDS;
using CryptoFormulaLibrary.Models;
using HelpfulLibrary;

namespace CryptoPractice_DSA
{
    public partial class MainForm : Form
    {
        internal ObservableCollection<SubscriberParams> SubscribersParams = new ObservableCollection<SubscriberParams>();
        private readonly Random _random = new Random();

        public MainForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            _random = new Random();
            SubscribersParams.CollectionChanged += SubscribersParams_CollectionChanged;

            foreach (var column in dataGridViewHistory.Columns.Cast<DataGridViewColumn>())
            {
                column.Width = 80;
            }
        }

        private void SubscriberParams_FormClosing(object sender, EventArgs e)
        {
            var closingSubName = (sender as SubscriberForm).Subscriber.Name;
            SubscribersParams.Remove(SubscribersParams.First(x => x.Subscriber.Name == closingSubName));
        }

        private void SubscribersParams_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var newCollection = (IList)e.NewItems?.SyncRoot;
            if (newCollection != null)
            {
                foreach (var element in newCollection)
                {
                    var sub = (element as SubscriberParams).Subscriber;
                    subscribersDataGrid.Rows.Add(sub.Name, sub.OpenedKey);
                }
            }

            var oldCollection = (IList)e.OldItems?.SyncRoot;
            if (oldCollection != null)
            {
                foreach (var element in oldCollection)
                {
                    var sub = (element as SubscriberParams).Subscriber;
                    var row = subscribersDataGrid.GetRowByValue(sub.Name);

                    subscribersDataGrid.Rows.Remove(row);
                }
            }
        }

        private void TbClosedKey_TextChanged(object sender, EventArgs e)
        {
            CatchException(() =>
            {
                var closedKey = BigInteger.Parse((sender as TextBox)?.Text);
                var g = int.Parse(tbParamG.Text);
                var p = int.Parse(tbParamP.Text);

                tbOpenedKey.Text = DSAEDSController.CalculateOpenedKey(closedKey, g, p).ToString();
            });
        }

        private void BtAddSubscriber_Click(object sender, EventArgs e)
        {
            CatchException(() =>
            {
                var name = string.IsNullOrWhiteSpace(tbSubscriberName.Text)
                    ? throw new ArgumentException("Имя подписчика не должно быть пустым")
                    : tbSubscriberName.Text;
                var openedKey = BigInteger.Parse(tbOpenedKey.Text);
                var closedKey = BigInteger.Parse(tbClosedKey.Text);
                var g = int.Parse(tbParamG.Text);
                var q = int.Parse(tbParamQ.Text);
                var p = int.Parse(tbParamP.Text);

                var newSub = new DSASubscriber(openedKey, closedKey, name, p, q, g);
                var form = new SubscriberForm(SubscribersParams, newSub, dataGridViewHistory);
                form.FormClosing += SubscriberParams_FormClosing;
                SubscribersParams.Add(new SubscriberParams(form, newSub));
                form.Show();

                BtSetRandomSubscriberParams(this, e);
            });
        }

        private void BtSetRandomSubscriberParams(object sender, EventArgs e)
        {
            CatchException(() =>
            {
                tbClosedKey.Text = PrimeNumberGenerator
                    .GeneratePrimeNumber(3, Convert.ToInt32(tbParamQ.Text) - 1, _random)
                    .ToString();
                
                tbSubscriberName.Text = HelpfulMethods.GetRandomName(_random);
            });
        }

        private void BtSetRandomCommonParams_Click(object sender, EventArgs e)
        {
            var dsaParams = DSAEDSController.GenerateParams(_random);
            tbParamP.Text = dsaParams.P.ToString();
            tbParamQ.Text = dsaParams.Q.ToString();
            tbParamG.Text = dsaParams.G.ToString();
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
