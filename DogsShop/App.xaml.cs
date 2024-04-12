using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DogsShop.Components;
namespace DogsShop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PetShopEntities db = new PetShopEntities();
        public static Dog LoggingDog = null;
    }
}
