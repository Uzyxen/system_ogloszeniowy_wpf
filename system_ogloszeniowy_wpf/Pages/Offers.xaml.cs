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
    /// Logika interakcji dla klasy Offers.xaml
    /// </summary>
    public partial class Offers : Page
    {
        public Offers()
        {
            InitializeComponent();

            offersData.ItemsSource = Database.Methods.DatabaseOffer.ReadOffers();

            if(App.loggedUser != null)
            {
                if(App.loggedUser.Admin == true)
                {
                    AdminManage.Visibility = Visibility.Visible;
                }
                else
                {
                    AdminManage.Visibility = Visibility.Hidden;
                }
            }
        }

        private void DeleteOfferButton(object sender, RoutedEventArgs e)
        {
            if (offersData.SelectedItem != null)
            {
                var offer = offersData.SelectedItem as Offer;

                Database.Methods.DatabaseOffer.DeleteOffer(offer.Id);
                offersData.ItemsSource = Database.Methods.DatabaseOffer.ReadOffers();

                offersData.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Zaznacz element!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditOfferButton(object sender, RoutedEventArgs e)
        {
            if (offersData.SelectedItem != null)
            {
                var offer = offersData.SelectedItem as Offer;

                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Main.Navigate(new AdminPages.EditOfferPage(offer));
            }
            else
            {
                MessageBox.Show("Zaznacz element!", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
