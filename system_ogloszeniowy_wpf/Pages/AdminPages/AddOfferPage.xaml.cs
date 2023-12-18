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
    /// Logika interakcji dla klasy AddOfferPage.xaml
    /// </summary>
    public partial class AddOfferPage : Page
    {
        public AddOfferPage()
        {
            InitializeComponent();
        }

        private void CreateOfferButtonClicked(object sender, RoutedEventArgs e)
        {
            var offer = new Offer();

            offer.Tytul = tytulTxt.Text;
            offer.Opis = opisTxt.Text;
            offer.Kategoria = kategoriaTxt.Text;
            offer.Stanowisko = stanowiskoTxt.Text;
            offer.Placa_min = int.Parse(placaMinTxt.Text);
            offer.Placa_max = int.Parse(placaMaxTxt.Text);
            offer.Lokalizacja = lokalizacjaTxt.Text;
            offer.Odleglosc = int.Parse(odlegloscTxt.Text);

            Database.Methods.DatabaseOffer.AddOffer(offer);

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Main.Navigate(new Offers());
        }
    }
}
