using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogsShop.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogsShop;
namespace DogsShop.Components.Tests
{
    [TestClass()]
    public class FoodPetTests
    {
        PetShopEntities db = new PetShopEntities();
       [TestMethod()]
        public void FoodPetTest()
        { 
            FoodPet testFood = new FoodPet();
            int id = 1;
            string names = "Новый Корм с мясом";
            DateTime dateedit = DateTime.Now;
            testFood = db.FoodPet.FirstOrDefault(x => x.Id == id);
            if (testFood != null)
            {
                testFood.Name = names;
                testFood.DataEdit = dateedit;
                db.SaveChanges();
            }
            Assert.AreEqual(db.FoodPet.FirstOrDefault(x => x.Id == id).DataEdit , dateedit);
        }
    }
}