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
    /// Logika interakcji dla klasy Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void GoToLoginPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

            mainWindow.Main.Navigate(new Login());
        }

        private void RegisterButtonClicked(object sender, RoutedEventArgs e)
        {
            bool success = true;

            if(string.IsNullOrEmpty(loginTxt.Text) || string.IsNullOrEmpty(emailTxt.Text) ||  string.IsNullOrEmpty(passwordTxt.Password.ToString()) || string.IsNullOrEmpty(password2Txt.Password.ToString()))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                success = false;
            }
            else
            {
                if (!(loginTxt.Text.All(char.IsLetterOrDigit)) || loginTxt.Text.Length < 3 || loginTxt.Text.Length > 20)
                {
                    MessageBox.Show("Login musi mieć od 3 do 20 znaków i może zawierać tylko litery i liczby", "Niepoprawny login!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!passwordTxt.Password.ToString().All(char.IsLetterOrDigit) || passwordTxt.Password.ToString().Length < 8)
                {
                    MessageBox.Show("Hasło musi mieć więcej niż 8 znaków i może zawierać tylko litery i liczby", "Niepoprawne hasło!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
                if (!password2Txt.Password.ToString().All(char.IsLetterOrDigit) || password2Txt.Password.ToString() != password2Txt.Password.ToString())
                {
                    MessageBox.Show("Hasło może zawierać tylko litery i liczby", "Hasła się nie zgadzają!", MessageBoxButton.OK, MessageBoxImage.Information);
                    success = false;
                }
            }

            var login = loginTxt.Text;
            var users = Database.Methods.DatabaseUser.ReadUsers();

            foreach(var user in users)
            {
                if(user.Login == login)
                {
                    success = false;
                    MessageBox.Show("Użytkownik z takim loginem już istnieje", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
            }

            if (success)
            {
                var user = new User();

                user.Imie = "";
                user.Nazwisko = "";
                user.Opis = "";
                user.Login = login;
                user.Haslo = passwordTxt.Password.ToString();
                user.Email = emailTxt.Text;
                user.Numer_telefonu = "";

                Database.Methods.DatabaseUser.AddUser(user);

                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Main.Navigate(new Login());
            }
        }
    }
}
