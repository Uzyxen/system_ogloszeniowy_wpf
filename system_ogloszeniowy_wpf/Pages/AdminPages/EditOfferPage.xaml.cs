﻿using System;
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
    /// Logika interakcji dla klasy EditOfferPage.xaml
    /// </summary>
    public partial class EditOfferPage : Page
    {
        Offer Offer { get; set; }

        public EditOfferPage(Offer offer)
        {
            InitializeComponent();

            Offer = offer;

            tytulTxt.Text = Offer.Tytul;
            opisTxt.Text = Offer.Opis;
            kategoriaTxt.Text = Offer.Kategoria;
            lokalizacjaTxt.Text = Offer.Lokalizacja;
            odlegloscTxt.Text = Offer.Odleglosc.ToString();
        }

        private void EditOfferButtonClicked(object sender, RoutedEventArgs e)
        {
            Offer.Tytul = tytulTxt.Text;
            Offer.Opis = opisTxt.Text;
            Offer.Kategoria = kategoriaTxt.Text;
            Offer.Lokalizacja = lokalizacjaTxt.Text;
            Offer.Odleglosc = int.Parse(odlegloscTxt.Text);

            Database.Methods.DatabaseOffer.EditOffer(Offer);

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Main.Navigate(new Offers());
        }
    }
}
