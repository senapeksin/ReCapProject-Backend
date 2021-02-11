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
           
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.BrandId);
            
            }
        }
    }
}
