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
    /// Logika interakcji dla klasy OfferInfo.xaml
    /// </summary>
    public partial class OfferInfo : Page
    {
        Offer Offer { get; set; }
        public OfferInfo(Offer offer)
        {
            InitializeComponent();

            Offer = offer;

            TitleBlock.Text = Offer.Tytul;
            DescriptionBlock.Text = Offer.Opis;
            payMinBlock.Text = Offer.Placa_min.ToString();
            payMaxBlock.Text = Offer.Placa_max.ToString();
            LocationBlock.Text = Offer.Lokalizacja;
            positionBlock.Text = Offer.Stanowisko;
            contractBlock.Text = Offer.Umowa;
        }

        private void ApplyButtonClicked(object sender, RoutedEventArgs e)
        {
            if(App.loggedUser != null)
            {
                if(App.loggedUser.Admin == true)
                {
                    MessageBox.Show("Nie możesz aplikować o prace jako admin!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Database.Methods.DatabaseApp.AddApp(Offer);

                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow.Main.Navigate(new Home());
                }
            }
            else
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Main.Navigate(new Login());
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
    }
}
