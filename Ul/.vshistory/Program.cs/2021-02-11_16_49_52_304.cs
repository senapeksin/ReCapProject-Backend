using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace Ul
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.BrandId);
            }
        }
    }
}
