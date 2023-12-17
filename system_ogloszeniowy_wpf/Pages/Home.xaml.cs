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

namespace system_ogloszeniowy_wpf.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();

            if(App.loggedUser != null)
            {
                loginButton.Visibility = Visibility.Hidden;
                myAccountButton.Visibility = Visibility.Visible;

                if(App.loggedUser.Admin == true)
                {
                    adminInfo.Visibility = Visibility.Visible;
                }
                else
                {
                    adminInfo.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                loginButton.Visibility = Visibility.Visible;
                myAccountButton.Visibility = Visibility.Hidden;
            }
        }

        private void SearchForOffers(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchInput.Text))
            {
                MessageBox.Show("Uzupełnij pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void GoToMyAccount(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (system_ogloszeniowy_wpf.MainWindow)App.Current.MainWindow;

            mainWindow.Main.Navigate(new MyAccount());
        }

        private void GoToLoginPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (system_ogloszeniowy_wpf.MainWindow)App.Current.MainWindow;

            mainWindow.Main.Navigate(new Login());
        }

        private void GoToAdminPanel(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (system_ogloszeniowy_wpf.MainWindow)App.Current.MainWindow;

            mainWindow.Main.Navigate(new AdminPages.AdminPanel());
        }

        private void GoToOffersPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (system_ogloszeniowy_wpf.MainWindow)App.Current.MainWindow;

            mainWindow.Main.Navigate(new Offers());
        }
    }
}
