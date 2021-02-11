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
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Car car = new Car {Id=1, BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = 2018, Description="2018 Model Araba"};
            Car car2 = new Car { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 50, ModelYear = 2020, Description = "2020 Model Araba" };
            carManager.Add(car);
            carManager.Add(car2);

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
        }
    }
}
