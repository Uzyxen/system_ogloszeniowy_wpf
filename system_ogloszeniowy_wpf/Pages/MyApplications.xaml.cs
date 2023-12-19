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

namespace system_ogloszeniowy_wpf.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy MyApplications.xaml
    /// </summary>
    public partial class MyApplications : Page
    {
        public MyApplications()
        {
            InitializeComponent();

            appsData.ItemsSource = Database.Methods.DatabaseApp.ReadAppsForUser();
        }

        private void CancelApplicationButtonClicked(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            AppModel selectedItem = (AppModel)clickedButton.DataContext;

            if(selectedItem.Status == "zakończone")
            {
                MessageBox.Show("Ta aplikacja została już zakończona!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (selectedItem.Status == "anulowane")
            {
                MessageBox.Show("Ta aplikacja została anulowana!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (selectedItem.Status == "odrzucone")
            {
                MessageBox.Show("Ta aplikacja została odrzucona!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Database.Methods.DatabaseApp.CancelApp(selectedItem.Id);
                appsData.ItemsSource = Database.Methods.DatabaseApp.ReadAppsForUser();
            }
        }

        private void GoToHomePageClicked(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            if (mainWindow.Main.CanGoBack)
            {
                mainWindow.Main.GoBack();
            }
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
    }
}
