using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using system_ogloszeniowy_wpf.Models;

namespace system_ogloszeniowy_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static User loggedUser = null;
        public App()
        {
            Database.Database.InitializeDatabase();
        }
    }
}
