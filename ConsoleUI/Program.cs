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

            Console.WriteLine("Tüm Arabalar: ");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(" ID: " + car.Id + " --- Color: " + colorManager.GetById(car.ColorId).ColorName +
                    " --- Brand Name: " + brandManager.GetById(car.BrandId).BrandName + " --- Model Year: " + car.ModelYear +
                    " --- Daily Price: " + car.DailyPrice + " --- Description: " + car.Description);
            }

            Console.WriteLine("\n");

            Console.WriteLine("BrandId'si 1 olan Arabalar: ");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(" ID: " +car.Id+" --- Color: "+ colorManager.GetById(car.ColorId).ColorName+
                    " --- Brand Name: " + brandManager.GetById(car.BrandId).BrandName+ " --- Model Year: " + car.ModelYear+
                    " --- Daily Price: " + car.DailyPrice+ " --- Description: " + car.Description);
            }

            Console.WriteLine("\n");

            Console.WriteLine("Günlük Fiyat Aralığı 700 ile 2000 TL Arası Olan Arabalar: ");
            foreach (var car in carManager.GetByDailyPrice(700,2000))
            {
                Console.WriteLine(" ID: " + car.Id + " --- Color: " + colorManager.GetById(car.ColorId).ColorName +
                    " --- Brand Name: " + brandManager.GetById(car.BrandId).BrandName + " --- Model Year: " + car.ModelYear +
                    " --- Daily Price: " + car.DailyPrice + " --- Description: " + car.Description);
            }

            Console.WriteLine("\n");

            carManager.Add(new Car { BrandId = 3, ColorId = 2, DailyPrice = 0, ModelYear = 2005, Description = "Otomatik" });
            brandManager.Add(new Brand { BrandName = "T" });
            Console.ReadLine();
        }
    }
}
