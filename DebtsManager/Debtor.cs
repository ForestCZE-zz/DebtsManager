using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtsManager
{
    public class Debtor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void UpdateProperty(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                UpdateProperty("Name");
            }
        }

        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                //UpdateProperty("Amount");
                UpdateProperty("RemainingDebt");
            }
        }

        private decimal _paid;
        public decimal Paid
        {
            get { return _paid; }
            set
            {
                _paid = value;
                //UpdateProperty("Paid");
                UpdateProperty("RemainingDebt");
            }
        }

        public decimal RemainingDebt => Amount - Paid;

        public DateTime Created { get; set; }

        public Debtor()
        {

        }

        public Debtor(string name, decimal amount, decimal paid, DateTime created)
        {
            Name = name;
            Amount = amount;
            Paid = paid;
            Created = created;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
