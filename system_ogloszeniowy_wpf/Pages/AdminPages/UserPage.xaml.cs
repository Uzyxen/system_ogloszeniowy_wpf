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
    /// Logika interakcji dla klasy UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage(User user)
        {
            InitializeComponent();

            FirstNameBlock.Text = user.Imie;
            LastNameBlock.Text = user.Nazwisko;
            PositionBlock.Text = user.Stanowisko;
            EmailBlock.Text = user.Email;
            DescriptionBlock.Text = user.Opis;
            NumberBlock.Text = user.Numer_telefonu;
            EducationBlock.Text = user.Wyksztalcenie;
            GithubBlock.Text = user.Github;
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
