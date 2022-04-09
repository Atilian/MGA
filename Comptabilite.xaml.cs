using System.Windows;

namespace MGA
{
    /// <summary>
    /// Logique d'interaction pour Comptabilite.xaml
    /// </summary>
    public partial class Comptabilite : Window
    {
        public Comptabilite()
        {
            InitializeComponent();
        }
        private void Click_Fermer(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Click_Agrandir(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
        }

        private void Click_Reduire(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void Btn_Menu(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
