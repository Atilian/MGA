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

        private ObservableCollection<Operation> _Operations = new ObservableCollection<Operation>();

        BDDComptabilite _BddComptabilite;
        
        private int _IndexOperation;

        private int _Montant = 0;

        public Comptabilite()
        {
            InitializeComponent();
            
            _BddComptabilite = new BDDComptabilite();
                        
            List<Operation> ListOperationsBdd = _BddComptabilite.Select();

            _IndexOperation = (ListOperationsBdd.Count > 0) ? (ListOperationsBdd.Last() as Operation).Index + 1 : 0;

            foreach(Operation i in ListOperationsBdd)
            {
                _Operations.Add(i);
            }

            foreach(Operation i in _Operations)
            {
                _Montant += i.Montant;
            }
            
            Montant.Text = _Montant.ToString();

            lbOperations.ItemsSource = _Operations;

            Graphique();
            
        }
        private void DragMove(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Btn_Menu(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Top = this.Top;
            mainWindow.Left = this.Left;
            mainWindow.Show();

            this.Close();
        }


        private void AddOperation(object sender, RoutedEventArgs e)
        {
            AddEditOperation addoperation = new AddEditOperation();
            
            addoperation.Top = this.Top;
            addoperation.Left = this.Left;
            addoperation.ShowDialog();

            if((addoperation._Libele != null) && (addoperation._Montant != 0))
            {
                string _libele = addoperation._Libele;
                int _montant = addoperation._Montant;
                string _date = DateTime.Now.ToString("dd/MM/yyyy");

                Operation operation = new Operation(_IndexOperation, _libele, _montant, _date);

                _BddComptabilite.Insert(_IndexOperation.ToString(), _libele, _montant.ToString(), _date);

                _Operations.Add(operation);

                _IndexOperation++;

                Montant.Text = (int.Parse(Montant.Text) + addoperation._Montant).ToString();
            }
            Graphique();

        }

        private bool SelectedItem()
        {
            return (lbOperations.SelectedItem != null) ? true : false;
        }

        private void DeleteOperation(object sender, RoutedEventArgs e)
        {
            if (SelectedItem())
            {
                MessageBoxResult result =  MessageBox.Show("Vouler vous vraiment supprimer l'operation ?","",MessageBoxButton.YesNo);

                if(result == MessageBoxResult.Yes)
                {
                    int index = ((lbOperations.SelectedItem as Operation).Index);

                    Montant.Text = (int.Parse(Montant.Text) - ((lbOperations.SelectedItem as Operation).Montant)).ToString();

                    _BddComptabilite.Delete(index.ToString());

                    _Operations.Remove(lbOperations.SelectedItem as Operation);

                }
            }
            else
            { 
                MessageBox.Show("Veuillez selectionner une operation a supprimer");
            }
            Graphique();
        }

        private void EditOperation(object sender, RoutedEventArgs e)
        {
            if (SelectedItem())
            {
                AddEditOperation addoperation = new AddEditOperation(((lbOperations.SelectedItem as Operation).Libele).ToString(), ((lbOperations.SelectedItem as Operation).Montant).ToString());

                addoperation.ShowDialog();

                if(addoperation._Libele != "Annuler")
                {
                    MessageBoxResult result = MessageBox.Show("Vouler vous vraiment editer l'operation ?", "", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        Montant.Text = ((int.Parse(Montant.Text) - ((lbOperations.SelectedItem as Operation).Montant)) + addoperation._Montant).ToString();

                        ((lbOperations.SelectedItem as Operation).Libele) = addoperation._Libele;
                        ((lbOperations.SelectedItem as Operation).Montant) = addoperation._Montant;

                        if(addoperation._Montant >= 0) 
                        {
                            ((lbOperations.SelectedItem as Operation).Color) = "LightGreen";
                            ((lbOperations.SelectedItem as Operation).Foreground) = "Green";
                        }
                        else
                        {
                            ((lbOperations.SelectedItem as Operation).Color) = "Pink";
                            ((lbOperations.SelectedItem as Operation).Foreground) = "Red";
                        }
                        lbOperations.Items.Refresh();

                        _BddComptabilite.Update(((lbOperations.SelectedItem as Operation).Index).ToString(), addoperation._Libele, (addoperation._Montant).ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une operation a editer");
            }
            Graphique();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void Graphique()
        {
            GridGraphique.Children.Clear();

            for (int i = 0; i <= 12; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();

                gridCol.Width = new GridLength('*');

                GridGraphique.ColumnDefinitions.Add(gridCol);
            }

            for (int i = 0; i <= 10; i++)
            {
                RowDefinition rowCol = new RowDefinition();

                rowCol.Height = new GridLength('*');

                GridGraphique.RowDefinitions.Add(rowCol);
            }

            Border borderAxeY = new Border();

            borderAxeY.BorderThickness = new Thickness(0, 0, 1, 0);
            borderAxeY.BorderBrush = Brushes.Red;
            Grid.SetRowSpan(borderAxeY, 11);
            Grid.SetColumn(borderAxeY, 0);

            GridGraphique.Children.Add(borderAxeY);

            Border borderAxeX = new Border();

            borderAxeX.BorderThickness = new Thickness(0, 1, 0, 0);
            borderAxeX.BorderBrush = Brushes.Red;
            Grid.SetRow(borderAxeX, 10);
            Grid.SetColumnSpan(borderAxeX, 13);

            GridGraphique.Children.Add(borderAxeX);

            TextBlock Origin = new TextBlock();
            Origin.Text = "0";
            Origin.FontSize = 12;
            Origin.HorizontalAlignment = HorizontalAlignment.Center;
            Origin.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(Origin, 10);
            Grid.SetColumn(Origin, 0);
            GridGraphique.Children.Add(Origin);

            int nbrChoice = 100;

            for (int i = 0; i < 10; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = (nbrChoice - (nbrChoice / 10) * i).ToString();
                textBlock.FontSize = 12;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Top;
                Grid.SetRow(textBlock, i);
                Grid.SetColumn(textBlock, 0);
                GridGraphique.Children.Add(textBlock);
            }

            for (int i = 0; i < 12; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = (12 - i).ToString();
                textBlock.FontSize = 12;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetRow(textBlock, 10);
                Grid.SetColumn(textBlock, 12 - i);
                GridGraphique.Children.Add(textBlock);
            }

            for (int i = 0; i < 12; i++)
            {
                double MontantMois = 0;
                string Mois;
                string OperationMois;

                foreach (Operation O in _Operations)
                {
                    Mois = "0" + (i + 1).ToString();
                    OperationMois = (O.Date[3].ToString() + O.Date[4].ToString());
                    MontantMois += (OperationMois == Mois) ? O.Montant : 0;
                }

                bool color = (MontantMois >= 0) ? true : false;

                MontantMois = (MontantMois >= 0) ? MontantMois : MontantMois * -1;

                if (MontantMois > 0)
                {

                    if(nbrChoice > MontantMois)
                    {
                        string value = (MontantMois < 10) ? "0" + (MontantMois % nbrChoice).ToString() : (MontantMois % nbrChoice).ToString();


                        for(int j = 10; j > 10 - (int.Parse(value[0].ToString())) ; j--)
                        {
                            Border b = new Border();
                            b.Background = (color) ? new SolidColorBrush(Colors.LightGreen) : new SolidColorBrush(Colors.Pink);
                            Grid.SetRow(b, j - 1);
                            Grid.SetColumn(b, i + 1);
                            GridGraphique.Children.Add(b);
                        }

                        if(value.Count() > 1)
                        {
                            Grid Split = new Grid();

                            Grid.SetRow(Split, 10 - (int.Parse(value[0].ToString()) + ((value.Count() > 1) ? 1 : 0)));
                            Grid.SetColumn(Split, i + 1);

                            GridGraphique.Children.Add(Split);

                            for (int i2 = 0; i2 <= 10; i2++)
                            {
                                RowDefinition rowCol = new RowDefinition();

                                rowCol.Height = new GridLength('*');

                                Split.RowDefinitions.Add(rowCol);
                            }

                            Border c = new Border();
                            c.Height = (500 / 11) / 10 * int.Parse(value[1].ToString());
                            c.Background = new SolidColorBrush(Colors.Green);
                            Grid.SetRow(c, 10 - (int.Parse(value[0].ToString()) + ((value.Count() > 1) ? 1 : 0)));
                            Grid.SetColumn(c, 0);
                            Split.Children.Add(c);

                            //GridGraphique.Children.Add(Split);

                        }
                    }
                    else
                    {
                        Border b = new Border();
                        b.Background = new SolidColorBrush(Colors.Pink);
                        Grid.SetRowSpan(b, 10);
                        Grid.SetColumn(b, i + 1);
                        GridGraphique.Children.Add(b);
                    }
                }
            }

        }

        private void SearchOperation(object sender, RoutedEventArgs e)
        {

        }
    }
}
