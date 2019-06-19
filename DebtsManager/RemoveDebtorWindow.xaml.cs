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
    /// Interaction logic for RemoveDebtorWindow.xaml
    /// </summary>
    public partial class RemoveDebtorWindow : Window
    {
        DebtorManager debtorManager;

        public RemoveDebtorWindow(DebtorManager debtorManager)
        {
            InitializeComponent();
            this.debtorManager = debtorManager;
            DataContext = debtorManager;
        }

        private void RemoveDebtorButton_Click(object sender, RoutedEventArgs e)
        {
            if (debtorsListBox.SelectedItem != null)
            {
                try
                {
                    debtorManager.RemoveDebtor((Debtor)debtorsListBox.SelectedItem);
                    debtorManager.Save();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
