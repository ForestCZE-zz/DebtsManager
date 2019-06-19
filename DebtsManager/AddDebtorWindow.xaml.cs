using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DebtsManager
{
    /// <summary>
    /// Interaction logic for AddDebtorWindow.xaml
    /// </summary>
    public partial class AddDebtorWindow : Window
    {
        private DebtorManager debtorManager;

        public AddDebtorWindow(DebtorManager debtorManager)
        {
            InitializeComponent();
            this.debtorManager = debtorManager;
        }

        private void AddDebtorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                debtorManager.AddDebtor(nameTextBox.Text, amountTextBox.Text, paidTextBox.Text);
                debtorManager.Save();

                nameTextBox.Clear();
                amountTextBox.Clear();
                paidTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
