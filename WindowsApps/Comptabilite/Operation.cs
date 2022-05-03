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
        public int Index { get; set; }
        
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

        public string Date { get; set; }

        public string Color { get; set; }

        public string Foreground { get; set; }

        public Operation(int index, string libele, int montant, string date)
        {
            Index = index;
            Libele = libele;
            Montant = montant;
            Date = date;
            Color = (montant >= 0) ? "LightGreen" : "Pink";
            Foreground = (Color == "LightGreen") ? "Green" : "Red";
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
