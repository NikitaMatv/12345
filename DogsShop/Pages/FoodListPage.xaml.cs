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
    /// Логика взаимодействия для FoodListPage.xaml
    /// </summary>
    public partial class FoodListPage : Page
    {
        bool isAlph = true;
        int MaxPage = 0;
        int currentPage = 1;

        List<List<FoodPet>> foodpet = new List<List<FoodPet>>();
        public FoodListPage()
        {
            InitializeComponent();
            Refresh();
            GenButton();
        }

        private void Refresh()
        {
            foodpet = new List<List<FoodPet>>();
            MaxPage = 0;
            var buffFood = App.db.FoodPet.ToList();
            if (isAlph == true)
            {
                buffFood = buffFood.OrderBy(x => x.Name).ToList();
            }
            int foodCount = 0;
            do
            {
                foodCount += 4;
                MaxPage++;
            } while (foodCount < buffFood.Count());
            TbPages.Text = $"{currentPage}/{MaxPage}";

            int start = 1;
            for (int i = 1; i <= MaxPage; i++)
            {
                List<FoodPet> buffer = new List<FoodPet>();

                for (; start <= 4 * i; start++)
                {
                    if (start <= buffFood.Count())
                    {
                        buffer.Add(buffFood[start - 1]);
                    }
                }
                foodpet.Add(buffer);
            }
            LvFood.ItemsSource = foodpet[currentPage - 1];
        }
        private void GenButton()
        {
            SpButton.Children.Clear();
            for (int i = 1; i <= MaxPage; i++)
            {
                Button myBtn = new Button();
                myBtn.Content = i;
                myBtn.Margin = new Thickness(5, 0, 0, 0);
                myBtn.Width = 30;
                myBtn.Click += MyBtn_Click;
                SpButton.Children.Add(myBtn);
            }
        }
        private void MyBtn_Click(Object sender, EventArgs e)
        {
            var ds = sender as Button;
            currentPage = (int)ds.Content;
            Refresh();
        }

        private void BtAlpf_Click(object sender, RoutedEventArgs e)
        {
            isAlph = true;
            Refresh();
        }

        private void BtNoAlpf_Click(object sender, RoutedEventArgs e)
        { 
            isAlph = false;
            Refresh();
        }

        private void BtLeftFull_Click(object sender, RoutedEventArgs e)
        {
            currentPage = 1;
            Refresh();
        }

        private void BtLeft_Click(object sender, RoutedEventArgs e)
        {
            if(currentPage != 1)
            {
                currentPage--;
            }
            Refresh();
        }

        private void BtNext_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage != MaxPage)
            {
                currentPage++;
            }
            Refresh();
        }

        private void BtNextFull_Click(object sender, RoutedEventArgs e)
        {
            currentPage = MaxPage;
            Refresh();
        }

        private void MiAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditFoodPetPage(new FoodPet()));
        }

        private void MiEdit_Click(object sender, RoutedEventArgs e)
        {
            var select = (sender as MenuItem).DataContext as FoodPet;
            if (select != null)
            {
                NavigationService.Navigate(new AddEditFoodPetPage(select));
            }
            else
            {
                return;
            }
        }

        private void MiAddCart_Click(object sender, RoutedEventArgs e)
        {
            
            var select = (sender as MenuItem).DataContext as FoodPet;
            if(select == null)
            {
                return;
            }
            Order_FoodPet order = new Order_FoodPet();
            order.FoodPetId = select.Id;
            order.Count = 1;
            order.DogId = App.LoggingDog.Id;

            if (App.db.Order_FoodPet.FirstOrDefault(x => x.OrderId == null && x.DogId == App.LoggingDog.Id && x.FoodPetId == select.Id) == null)
            {
                App.db.Order_FoodPet.Add(order);
            }
            else
            { 
                var carts = App.db.Order_FoodPet.FirstOrDefault(x => x.OrderId == null && x.DogId == App.LoggingDog.Id && x.FoodPetId == select.Id) as Order_FoodPet;
                if (carts.Count < 20)
                {
                    carts.Count = carts.Count + 1;
                    MessageBox.Show($"У вас теперь в корзине {select.Name} {carts.Count} шт");
                }
                else
                {
                    MessageBox.Show("Одну позицию из меню можно заказать не больше 20 раз в одно заказе!");
                    return;
                }
              
            }
            App.db.SaveChanges();
        }
    }
}
