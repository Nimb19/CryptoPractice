using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using CryptoFormulaLibrary;

namespace CryptoPractice_1._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SolveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var module = int.Parse(moduleTextBox.Text.Trim());
                var number = int.Parse(numberTextBox.Text.Trim());

                List<int> divisors = null;
                string eulerSolutionErr = null;
                string euclideSolutionErr = null;
                var eulerResult = await Task.Run(() => CryptoFormula.ФормулаЭйлера(module, number, out divisors, out eulerSolutionErr));
                var euclideResult = await Task.Run(() => CryptoFormula.АлгоритмЕвклида(module, number, out euclideSolutionErr));

                if (eulerResult != null)
                    resultEulerTextBox.Text = eulerResult.ToString();
                else
                    resultEulerTextBox.Text = eulerSolutionErr;

                if (euclideResult != null)
                    resultEuclideTextBox.Text = euclideResult.ToString();
                else
                    resultEuclideTextBox.Text = euclideSolutionErr;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception}");
            }
        }
    }
}
