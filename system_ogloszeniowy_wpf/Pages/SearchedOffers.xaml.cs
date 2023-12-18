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
    /// Logika interakcji dla klasy SearchedOffers.xaml
    /// </summary>
    public partial class SearchedOffers : Page
    {
        public SearchedOffers(string searchedValue, string category, string location, int radius)
        {
            InitializeComponent();

            offersData.ItemsSource =  Database.Methods.DatabaseOffer.SearchOffers(searchedValue, category, location, radius);

            SearchedValueBlock.Text = searchedValue;
        }

        private void OfferDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = offersData.SelectedItem as Offer;

            if (selectedItem != null)
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Main.Navigate(new OfferInfo(selectedItem));
            }
        }
    }
}
