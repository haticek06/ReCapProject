using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //GetAllTest();
            //GetByIdTest();
            //HatalıEklemeTest();
            //CarAddedTest();
            //BrandAddedTest();
            //ColorAddedTest();

            var result = carManager.GetCarDetails();
            if(result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Name: " + car.CarName + " Brand Name: " + car.BrandName + " Color Name: " + car.ColorName + " Daily Price: " + car.DailyPrice + " TL");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

            Console.ReadLine();
        }

        //private static void ColorAddedTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    colorManager.Add(new Color { ColorId = 5, ColorName = "Gri" });
        //}

        //private static void BrandAddedTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    brandManager.Add(new Brand { BrandId = 5, BrandName = "AUDİ" });
        //}

        //private static void CarAddedTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Add(new Car { Id = 7, CarName = "Q7", BrandId = 5, ColorId = 4, ModelYear = 2007, DailyPrice = 1900, Description = "Otomatik" });
        //}

        //private static void HatalıEklemeTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    carManager.Add(new Car { BrandId = 3, ColorId = 2, DailyPrice = 0, ModelYear = 2005, Description = "Otomatik" });
        //    brandManager.Add(new Brand { BrandName = "T" });
        //}

        //private static void GetByIdTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    Console.WriteLine(carManager.GetById(1).CarName);
        //    Console.WriteLine("\n");
        //}

        //private static void GetAllTest()
        //{
        //    Console.WriteLine("TÜM ARABALAR:");
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine("ID: " + car.Id + " CAR NAME: " + car.CarName + " BRAND ID: " + car.BrandId +
        //            " COLOR ID: " + car.ColorId + " DAİLY PRİCE: " + car.DailyPrice + " DESCRİPTİON: " + car.Description);

        //    }
        //    Console.WriteLine("\n");
        //}
    }
}
