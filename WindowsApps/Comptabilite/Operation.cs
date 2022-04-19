using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace MGA.WindowsApps.Comptabilite
{
    internal class Operation : INotifyPropertyChanged
    {
        public string Date { get; set; }
        private string libele;
        public string Libele {
            get { return this.libele; }
            set
            {
                if(this.libele != value)
                {
                    this.libele = value;
                    this.NotifyPropertyChanged("Libele");
                }
            }
        }
        private int montant;
        public int Montant {
            get { return this.montant; }
            set
            {
                if(this.montant != value)
                {
                    this.montant = value;
                    this.NotifyPropertyChanged("Montant");
                }
            }
        }

        public int Index { get; set; }

        public Operation(string libele, int montant, int index)
        {
            Date = DateTime.Now.ToString("dd MMMM yyyy :");
            Libele = libele;
            Montant = montant;
            Index = index;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyChangedName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyChangedName));
            }
        }
    }
}
