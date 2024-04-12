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

namespace DogsShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
            
        }

        private void BtFood_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new FoodListPage());
        }

        private void BtCart_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new CartPage());
        }

        private void BtHistary_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.NavigationService.Navigate(new HistoriPage());
        }

        private void BtLeave_Click(object sender, RoutedEventArgs e)
        {
            App.LoggingDog = null;
            NavigationService.Navigate(new LoginPage());
        }
    }
}
