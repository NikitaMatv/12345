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
    /// Логика взаимодействия для HistoriPage.xaml
    /// </summary>
    public partial class HistoriPage : Page
    {
        bool isAlph = true;
        int MaxPage = 0;
        int currentPage = 1;
        List<List<Order_FoodPet>> Order_foodpet = new List<List<Order_FoodPet>>();
        public HistoriPage()
        {
            InitializeComponent();
            Refresh();
            GenButton();
        }
        
        private void Refresh()
        {
            Order_foodpet = new List<List<Order_FoodPet>>();
            MaxPage = 0;
            var buffFood = App.db.Order_FoodPet.Where(x => x.DogId == App.LoggingDog.Id && x.OrderId != null).ToList();
            if (isAlph == true)
            {
                buffFood = buffFood.OrderBy(x => x.FoodPet.Name).ToList();
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
                List<Order_FoodPet> buffer = new List<Order_FoodPet>();

                for (; start <= 4 * i; start++)
                {
                    if (start <= buffFood.Count())
                    {
                        buffer.Add(buffFood[start - 1]);
                    }
                }
                Order_foodpet.Add(buffer);
            }
            LbCart.ItemsSource = Order_foodpet[currentPage - 1];
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
            if (currentPage != 1)
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
    }
}
