using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DebtsManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DebtorManager debtorManager = new DebtorManager();

        public MainWindow()
        {
            InitializeComponent();

            PrepareDir(debtorManager.directory);
            debtorManager.DebtorPropertyChanged += DebtorManager_DebtorPropertyChanged;

            try
            {
                debtorManager.Load();
                debtorsDataGrid.ItemsSource = debtorManager.Debtors;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PrepareDir(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private void DebtorManager_DebtorPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            debtorManager.Save();
        }

        private void AddMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddDebtorWindow addDebtorWindow = new AddDebtorWindow(debtorManager);
            addDebtorWindow.ShowDialog();
        }

        private void RemoveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RemoveDebtorWindow removeDebtorWindow = new RemoveDebtorWindow(debtorManager);
            removeDebtorWindow.ShowDialog();
        }
    }
}
