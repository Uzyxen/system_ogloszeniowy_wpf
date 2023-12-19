using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logika interakcji dla klasy MyAccount.xaml
    /// </summary>
    public partial class MyAccount : Page
    {
        User User { get; set; }
        public MyAccount(User user)
        {
            InitializeComponent();

            User = user;

            PositionBox.Text = User.Stanowisko;
            FirstNameBox.Text = User.Imie;
            LastNameBox.Text = User.Nazwisko;
            DescriptionBox.Text = User.Opis;
            NumberBox.Text = User.Numer_telefonu;
            EmailBox.Text = User.Email;
            educationBox.Text = User.Wyksztalcenie;
            GithubBox.Text = User.Github;
            StatusBlock.Text = User.Status;

            if(User.Status == "bezrobotny")
            {
                fireFromJobBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                fireFromJobBtn.Visibility = Visibility.Visible;
            }
        }

        private void UpdateUserData(object sender, RoutedEventArgs e)
        {
            string value = "";

            if((ComboBoxItem)educationBox.SelectedItem != null)
            {
                ComboBoxItem typeItem = (ComboBoxItem)educationBox.SelectedItem;
                value = typeItem.Content.ToString();
            }

            User.Stanowisko = PositionBox.Text;
            User.Imie = FirstNameBox.Text;
            User.Nazwisko = LastNameBox.Text;
            User.Opis = DescriptionBox.Text;
            User.Numer_telefonu = NumberBox.Text;
            User.Email = EmailBox.Text;
            User.Wyksztalcenie = value;
            User.Github = GithubBox.Text;

            Database.Methods.DatabaseUser.EditUser(User);
        }

        private void logoutButton(object sender, RoutedEventArgs e)
        {
            App.loggedUser = null;

            MainWindow mainWindow = (system_ogloszeniowy_wpf.MainWindow)App.Current.MainWindow;
            mainWindow.Main.Navigate(new Home());
        }

        private void GoToHomePageClicked(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            if (mainWindow.Main.CanGoBack)
            {
                mainWindow.Main.GoBack();
            }
        }

        private void FireFromJobButtonClicked(object sender, RoutedEventArgs e)
        {
            Database.Methods.DatabaseUser.FireFromJob();

            User = Database.Methods.DatabaseUser.ReadUser(App.loggedUser.Id);
            App.loggedUser = User;

            StatusBlock.Text = User.Status;
            fireFromJobBtn.Visibility = Visibility.Hidden;
        }

        private void GoToMyApplications(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = (system_ogloszeniowy_wpf.MainWindow)App.Current.MainWindow;
            mainWindow.Main.Navigate(new MyApplications());
        }
    }
}
