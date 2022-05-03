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

namespace MGA.WindowsApps.Comptabilite
{
    /// <summary>
    /// Logique d'interaction pour AddEditOperation.xaml
    /// </summary>
    public partial class AddEditOperation : Window
    {
        public string _Libele;
        public int _Montant;

        public AddEditOperation(string txtLibele = "Libele", string txtMontant = "Montant")
        {
            InitializeComponent();
            
            Libele.Text = txtLibele;
            Montant.Text = txtMontant;
        }

        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Click_AddOperation(object sender, RoutedEventArgs e)
        {
            if ((Montant != null) && (int.TryParse(Montant.Text, out int x)) && (Libele != null))
            {
                _Montant = x;
                _Libele = Libele.Text;
            }
            else
            {
                MessageBox.Show("La ou les valeurs ne sont pas correct");
            }
            this.Close();
        }

        private void Click_Annuler(object sender, RoutedEventArgs e)
        {
            _Libele = "Annuler";
            this.Close();
        }

        private void resetTxtLibele(object sender, MouseButtonEventArgs e)
        {
            if (Libele.Text == "Libele")
            {
                Libele.Text = "";
            }
        }

        private void resetTxtMontant(object sender, MouseButtonEventArgs e)
        {
            if (Montant.Text == "Montant")
            {
                Montant.Text = "";
            }
        }

    }
}
