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
            SecondNameBlock.Text = user.Nazwisko;
        }
    }
}
