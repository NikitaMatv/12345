using DogsShop.Components;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtLoging_Click(object sender, RoutedEventArgs e)
        {
            var dogs = App.db.Dog.FirstOrDefault(x => x.Name == TbLogin.Text);
            if(dogs != null)
            {
                if(dogs.Password == PbPassword.Password)
                {
                    App.LoggingDog = dogs;
                    NavigationService.Navigate(new MainMenuPage());
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }
             
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
        }

        private void BtReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage(new Dog()));
        }
    }
}
