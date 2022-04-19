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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MGA.UserControls
{
    /// <summary>
    /// Logique d'interaction pour NavBar.xaml
    /// </summary>
    public partial class NavBar : UserControl
    {
        public NavBar()
        {
            InitializeComponent();
        }
        public string SrcOptionImg { get; set; }

        private void Click_Reduire(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            Window window = Window.GetWindow(this);
            window.WindowState = WindowState.Minimized;
        }
        private void Click_Agrandir(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            Window window = Window.GetWindow(this);
            if (window.WindowState != WindowState.Maximized)
            {
                window.WindowState = WindowState.Maximized;
            }
            else
            {
                window.WindowState = WindowState.Normal;
            }
        }

        private void Click_Fermer(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            Window window = Window.GetWindow(this);
            window.Close();
        }
    }



}