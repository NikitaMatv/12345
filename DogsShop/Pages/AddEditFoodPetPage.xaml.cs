using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddEditFoodPetPage.xaml
    /// </summary>
    public partial class AddEditFoodPetPage : Page
    {
        FoodPet contextFoodPet;
        public AddEditFoodPetPage(FoodPet foodPet)
        {
            InitializeComponent();
            contextFoodPet = foodPet;
            DataContext = contextFoodPet;
        }

        public void BtSave_Click(object sender, RoutedEventArgs e)
        {
            if (contextFoodPet.Cost != null && contextFoodPet.Name != null && contextFoodPet.Discription != null)
            {
                contextFoodPet.DataEdit = DateTime.Now;
                if(contextFoodPet.Id == 0)
                {
                    App.db.FoodPet.Add(contextFoodPet);
                }
                App.db.SaveChanges();
                NavigationService.Navigate(new FoodListPage());
            }
            else
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
        }

        private void BtCansel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FoodListPage());
        }

        private void TbCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
