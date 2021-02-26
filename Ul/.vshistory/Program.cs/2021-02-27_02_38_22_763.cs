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
            //CarTest();             //foreign key koyunca sorun oluyor
            // BrandTest();         //sorun yok
            // ColorTest();         //sorun yok
            // UserTest();
            CustomerTest();
        }

        private static void CustomerTest()
        {
            CustomerManager customer = new CustomerManager(new EfCustomerDal());
            customer.Add(new Customer { UserId = 1, CompanyName = "Şirket1" });
            customer.Add(new Customer { UserId = 3, CompanyName = "Şirket2" });
            customer.Add(new Customer { UserId = 2, CompanyName = "Şirket3" });
            customer.Add(new Customer { UserId = 3, CompanyName = "Şirket1" });
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Begüm", LastName = "Muşdal", Email = "begum@hotmail.com", Password = "123456" });
            userManager.Add(new User { FirstName = "Nisa", LastName = "Has", Email = "nisa@hotmail.com", Password = "222222" });
            userManager.Add(new User { FirstName = "Gizem", LastName = "Baygın", Email = "gizem@hotmail.com", Password = "333333" });
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
           // colorManager.Add(new Color { ColorId=4, ColorName = "Yeşil" });
           //  colorManager.Delete(new Color { ColorId = 4, ColorName = "Yeşil" });
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
             carManager.Add(new Car { BrandId=3, ColorId=2, DailyPrice=1,Description="  mercedes",ModelYear=2019});
          //  carManager.Delete(new Car { Id=2012, BrandId=1,ColorId=2 });
            //foreach (var car in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine(car.Id + " - " + car.BrandName + " - "
            //        + car.ColorName + " - " + car.DailyPrice);
            //}
        }
    }
}
