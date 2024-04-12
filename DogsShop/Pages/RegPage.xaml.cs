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
using DogsShop.Components;
namespace DogsShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        Dog contextDog;
        public RegPage(Dog dog)
        {
            InitializeComponent();
            contextDog = dog;
            DataContext = contextDog;
        }

        private void BtReg_Click(object sender, RoutedEventArgs e)
        {
            if(contextDog.Name != null && contextDog.Password != null)
            {
                if(App.db.Dog.FirstOrDefault(x=>x.Name == contextDog.Name) == null)
                {
                    App.db.Dog.Add(contextDog);
                    App.db.SaveChanges();
                    NavigationService.Navigate(new LoginPage());
                }
                else
                {
                    MessageBox.Show("Кличка уже занита");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
        }

        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
