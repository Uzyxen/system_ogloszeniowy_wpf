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
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void GoToRegisterPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

            mainWindow.Main.Navigate(new Register());
        }

        private void LoginUserButtonClick(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(LoginTxt.Text) || string.IsNullOrEmpty(PasswordTxt.Password.ToString()))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var login = LoginTxt.Text;
                var users = Database.Methods.DatabaseUser.ReadUsers();
                User storedUser = null;

                foreach(var user in users)
                {
                    if(user.Login == login)
                    {
                        storedUser = user;
                        break;
                    }
                }

                if(storedUser != null)
                {
                    var enteredPassword = PasswordTxt.Password.ToString();

                    if(enteredPassword == storedUser.Haslo)
                    {
                        App.loggedUser = storedUser;

                        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                        mainWindow.Main.Navigate(new Home());
                    }
                    else
                    {
                        MessageBox.Show("Niepoprawny login lub hasło!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Niepoprawny login lub hasło!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Information);
                }
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
