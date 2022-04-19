using System;
using System.Windows;

namespace MGA
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Compta(object sender, RoutedEventArgs e)
        {
            WindowsApps.Comptabilite.Comptabilite compta = new WindowsApps.Comptabilite.Comptabilite();
            compta.Show();
            this.Close();
        }

        private void dragmove(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
