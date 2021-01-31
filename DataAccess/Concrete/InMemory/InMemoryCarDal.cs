using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1,ColorId=4,DailyPrice=2500,ModelYear=2018,Description="BMW"},
                new Car{Id=2, BrandId=2,ColorId=1,DailyPrice=2900,ModelYear=2016,Description="Mercedes"},
                new Car{Id=3, BrandId=3,ColorId=3,DailyPrice=1900,ModelYear=2015,Description="Volvo"},
                new Car{Id=4, BrandId=4,ColorId=2,DailyPrice=800,ModelYear=2005,Description="Toyota"},
                new Car{Id=5, BrandId=5,ColorId=5,DailyPrice=600,ModelYear=2002,Description="Fiat"}
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=> c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
