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
using system_ogloszeniowy_wpf.Pages;

namespace system_ogloszeniowy_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool logged = true;
        public MainWindow()
        {
            InitializeComponent();

            if(logged == false)
            {
                Main.Navigate(new Login());
            }
            else
            {
                Main.Navigate(new Home());
            }
        }
    }
}
