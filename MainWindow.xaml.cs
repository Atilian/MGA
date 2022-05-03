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
            Window w = new Window();
        }

        private void Btn_Compta(object sender, RoutedEventArgs e)
        {
            WindowsApps.Comptabilite.Comptabilite compta = new WindowsApps.Comptabilite.Comptabilite();
            compta.Top = this.Top;
            compta.Left = this.Left;
            this.Close();
            compta.ShowDialog();
        }

        private void dragmove(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
