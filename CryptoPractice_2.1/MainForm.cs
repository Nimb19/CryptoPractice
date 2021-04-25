using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using CryptoFormulaLibrary.CryptosystemControllers;
using CryptoFormulaLibrary.Models;
using HelpfulLibrary;
using static CryptoFormulaLibrary.PrimeNumberGenerator;

namespace CryptoPractice_2._1
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
            PrimeRandom = _random;

            SubscribersParams.CollectionChanged += SubscribersParams_CollectionChanged;
        }

        private void SubscriberParams_FormClosing(object sender, EventArgs e)
        {
            var closingSubName = (sender as SubscriberForm).Subscriber.Name;
            SubscribersParams.Remove(SubscribersParams.First(x => x.ElgamalSubscriber.Name == closingSubName));
        }

        private void SubscribersParams_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var newCollection = (IList)e.NewItems?.SyncRoot;
            if (newCollection != null) 
            {
                foreach (var element in newCollection)
                {
                    var sub = (element as SubscriberParams).ElgamalSubscriber;
                    subscribersDataGrid.Rows.Add(sub.Name, sub.OpenedKey);
                }
            }

            var oldCollection = (IList)e.OldItems?.SyncRoot;
            if (oldCollection != null)
            {
                foreach (var element in oldCollection)
                {
                    var sub = (element as SubscriberParams).ElgamalSubscriber;
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

                tbOpenedKey.Text = ElgamalCryptosystemController.CalculateOpenedKey(closedKey, g, p).ToString();
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
                var p = int.Parse(tbParamP.Text);

                var newSub = new ElgamalSubscriber(openedKey, closedKey, name, p, g);
                var form = new SubscriberForm(SubscribersParams, newSub);
                form.FormClosing += SubscriberParams_FormClosing;
                SubscribersParams.Add(new SubscriberParams(form, newSub));
                form.Show();

                BtSetRandomSubscriberParams(this, e);
            });
        }

        private void BtSetRandomSubscriberParams(object sender, EventArgs e)
        {
            tbClosedKey.Text = GeneratePrimeNumber(10, 100).ToString();
            tbSubscriberName.Text = HelpfulMethods.GetRandomName(_random);
        }

        private void BtSetRandomCommonParams_Click(object sender, EventArgs e)
        {
            var pg = ElgamalCryptosystemController.GenerateKeys(_random);
            tbParamP.Text = pg.P.ToString();
            tbParamG.Text = pg.G.ToString();
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
