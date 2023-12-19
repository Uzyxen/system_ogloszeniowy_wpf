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
    /// Logika interakcji dla klasy ManageOffers.xaml
    /// </summary>
    public partial class ManageOffers : Page
    {
        public ManageOffers()
        {
            InitializeComponent();
        }

        private void GoToAddOfferPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (system_ogloszeniowy_wpf.MainWindow)App.Current.MainWindow;

            mainWindow.Main.Navigate(new AddOfferPage());
        }

        private void GoToOffersPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (system_ogloszeniowy_wpf.MainWindow)App.Current.MainWindow;

            mainWindow.Main.Navigate(new Offers());
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
