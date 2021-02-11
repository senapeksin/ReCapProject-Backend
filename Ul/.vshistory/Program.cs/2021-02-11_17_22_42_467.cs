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

            Car car = new Car {Id=1, BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = 2018, Description="yeni"};
            carManager.Add(car);

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
        }
    }
}
