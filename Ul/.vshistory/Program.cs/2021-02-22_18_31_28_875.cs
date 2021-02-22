﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace Ul
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            ////8.
            //Car car = new Car { BrandId = 2, ColorId = 1, DailyPrice = 100, ModelYear = 2018, Description="Araba"};
            //  carManager.Add(car);


            CarTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.Id + " - " + car.BrandName + " - "
                    + car.ColorName + " - " + car.DailyPrice);
            }
        }
    }
}
