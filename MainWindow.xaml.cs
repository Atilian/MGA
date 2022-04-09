﻿using System.Windows;

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

        private void Btn_Compta(object sender, RoutedEventArgs e)
        {
            Comptabilite Compta = new Comptabilite();
            Compta.Show();
            this.Close();
        }
    }
}
