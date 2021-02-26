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
            CarTest();
           // BrandTest();
           //  ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
          //  colorManager.Add(new Color { ColorId=3, ColorName = "Kırmızı" });
          //   colorManager.Delete(new Color { ColorId = 3, ColorName = "Kırmızı" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal()); ;
           //  brandManager.Delete(new Brand { BrandId = 2, BrandName = "Mercedes" });
           // brandManager.Add(new Brand { BrandName = "BMW" });

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId=2, ColorId=2, DailyPrice=150,Description="İkinci araba mercedes",ModelYear=2020});
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.Id + " - " + car.BrandName + " - "
                    + car.ColorName + " - " + car.DailyPrice);
            }
        }
    }
}
