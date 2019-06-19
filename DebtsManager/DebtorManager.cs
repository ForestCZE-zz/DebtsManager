using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DebtsManager
{
    public class DebtorManager
    {
        public ObservableCollection<Debtor> Debtors { get; set; }

        public string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ForiSoft/DebtsManager/");
        public string fileName = "debtors.xml";

        public event PropertyChangedEventHandler DebtorPropertyChanged;

        public DebtorManager()
        {
            Debtors = new ObservableCollection<Debtor>();
        }

        public void AddDebtor(string name, string amount, string paid)
        {
            if (name.Length < 3)
                throw new ArgumentException("Jméno je příliš krátké.");
            if (!decimal.TryParse(amount, out decimal a))
                throw new ArgumentException("Neplatný formát částky.");
            if (!decimal.TryParse(paid, out decimal p))
                throw new ArgumentException("Neplatný formát splacené částky.");
            if(a <= 0)
                throw new ArgumentException("Neplatná částka.");
            if(p < 0)
                throw new ArgumentException("Neplatná splacená částka.");

            Debtor debtor = new Debtor(name, a, p, DateTime.Now);
            Debtors.Add(debtor);
        }

        public void RemoveDebtor(Debtor debtor)
        {
            Debtors.Remove(debtor);
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(Debtors.GetType());
            using (StreamWriter sw = new StreamWriter(directory + fileName))
            {
                serializer.Serialize(sw, Debtors);
            }
        }

        public void Load()
        {
            XmlSerializer serializer = new XmlSerializer(Debtors.GetType());
            if (File.Exists(directory + fileName))
            {
                using (StreamReader sr = new StreamReader(directory + fileName))
                {
                    Debtors = (ObservableCollection<Debtor>)serializer.Deserialize(sr);
                    foreach(Debtor d in Debtors)
                    {
                        d.PropertyChanged += EventHandler;
                    }
                }
            }
        }

        private void EventHandler(object sender, PropertyChangedEventArgs e)
        {
            DebtorPropertyChanged?.Invoke(sender, e);
        }
    }
}
