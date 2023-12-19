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
using system_ogloszeniowy_wpf.Models;

namespace system_ogloszeniowy_wpf.Pages.AdminPages
{
    /// <summary>
    /// Logika interakcji dla klasy ManageUsers.xaml
    /// </summary>
    public partial class ManageUsers : Page
    {
        public ManageUsers()
        {
            InitializeComponent();

            appsData.ItemsSource = Database.Methods.DatabaseApp.ReadApps();
        }

        private void ShowOfferDetail(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            AppModel selectedItem = (AppModel)clickedButton.DataContext;

            Offer offer = new Offer();
            offer = Database.Methods.DatabaseOffer.ReadOffer(selectedItem.Offer_Id);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Main.Navigate(new OfferInfo(offer));
        }

        private void ShowUserDetail(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            AppModel selectedItem = (AppModel)clickedButton.DataContext;

            User user = new User();
            user = Database.Methods.DatabaseUser.ReadUser(selectedItem.User_id);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Main.Navigate(new AdminPages.UserPage(user));
        }

        private void AcceptApplicationButtonClicked(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            AppModel selectedItem = (AppModel)clickedButton.DataContext;

            Database.Methods.DatabaseApp.AcceptApp(selectedItem.User_id, selectedItem.Id, $"Pracuje w: {selectedItem.Firma}");

            appsData.ItemsSource = Database.Methods.DatabaseApp.ReadApps();
        }

        private void DeclineApplicationButtonClicked(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            AppModel selectedItem = (AppModel)clickedButton.DataContext;

            Database.Methods.DatabaseApp.DeleteApp(selectedItem.Id);

            appsData.ItemsSource = Database.Methods.DatabaseApp.ReadApps();
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
