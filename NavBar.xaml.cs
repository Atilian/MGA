﻿using System;
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

namespace MGA
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

        private void tt(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            Window window = Window.GetWindow(this);
            window.WindowState = WindowState.Minimized;
        }
    }



}