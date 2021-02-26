using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace Ul
{
    class Program
    {
        static void Main(string[] args)
        {
           // CarTest();
           // BrandTest(); //sorun yok
           ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId=4, ColorName = "Yeşil" });
          //   colorManager.Delete(new Color { ColorId = 3, ColorName = "Kırmızı" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal()); ;
             brandManager.Delete(new Brand { BrandId = 3, BrandName = "BMW" });
           // brandManager.Add(new Brand { BrandName = "BMW", BrandId = 3 }) ;

            //foreach (var brand in brandManager.GetAll().Data)
            //{
            //    Console.WriteLine(brand.BrandName);
            //}
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            // carManager.Add(new Car { BrandId=1, ColorId=2, DailyPrice=1,Description="Dördüncü araba mercedes",ModelYear=2019});
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.Id + " - " + car.BrandName + " - "
                    + car.ColorName + " - " + car.DailyPrice);
            }
        }
    }
}
