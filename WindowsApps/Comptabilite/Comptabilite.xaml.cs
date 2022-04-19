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
using System.Collections.ObjectModel;

namespace MGA.WindowsApps.Comptabilite
{
    /// <summary>
    /// Logique d'interaction pour Comptabilite.xaml
    /// </summary>
    public partial class Comptabilite : Window
    {        
        private ObservableCollection<Operation> operations = new ObservableCollection<Operation>();

        private int IndexOperation = 0;

        public Comptabilite()
        {
            InitializeComponent();
            lbOperations.ItemsSource = operations;
        }

        private void Btn_Menu(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void dragmove(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void AddOperation(object sender, RoutedEventArgs e)
        {
            AddOperation x = new AddOperation("","");
            x.ShowDialog();

            if (x._Libele != null && x._Libele != "Annuler")
            {
                for(int t=0; t<10; t++)
                {
                    Operation i = new Operation(x._Libele, x._Montant, IndexOperation);

                    operations.Add(i);
                    IndexOperation++;
                }

            }
        }
        private bool SelectedItem()
        {
            return (lbOperations.SelectedItem != null)? true: false;
        }

        private void DeleteOperation(object sender, RoutedEventArgs e)
        {
            if (SelectedItem())
            {
                MessageBoxResult result =  MessageBox.Show("Vouler vous vraiment supprimer l'operation ?","",MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    operations.RemoveAt((lbOperations.SelectedItem as Operation).Index);
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une operation a supprimer");
            }
        }

        private void EditOperation(object sender, RoutedEventArgs e)
        {
            if (SelectedItem())
            {
                AddOperation x = new AddOperation(((lbOperations.SelectedItem as Operation).Libele).ToString(), ((lbOperations.SelectedItem as Operation).Montant).ToString());

                x.ShowDialog();

                if(x._Libele != "Annuler")
                {
                    MessageBoxResult result = MessageBox.Show("Vouler vous vraiment editer l'operation ?", "", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        ((lbOperations.SelectedItem as Operation).Libele) = x._Libele;
                        ((lbOperations.SelectedItem as Operation).Montant) = x._Montant;
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une operation a editer");
            }
        }

        private void SearchOperation(object sender, RoutedEventArgs e)
        {
            SearchOperation x = new SearchOperation();
            x.ShowDialog();
        }
    }
}
