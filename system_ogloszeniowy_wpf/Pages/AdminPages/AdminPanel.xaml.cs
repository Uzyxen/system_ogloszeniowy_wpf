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

namespace system_ogloszeniowy_wpf.Pages.AdminPages
{
    /// <summary>
    /// Logika interakcji dla klasy AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void GoToAdminUsers(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (system_ogloszeniowy_wpf.MainWindow)App.Current.MainWindow;

            mainWindow.Main.Navigate(new ManageUsers());
        }

        private void GoToAdminOffers(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (system_ogloszeniowy_wpf.MainWindow)App.Current.MainWindow;

            mainWindow.Main.Navigate(new ManageOffers());
        }

        private void GoToHomePageClicked(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            if (mainWindow.Main.CanGoBack)
            {
                mainWindow.Main.GoBack();
            }
        }
    }
}
