using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        //IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColorId(int brandId, int colorId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandAndColorId(int brandId, int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetail(int carId);
        IResult AddTransactionalTest(Car car);


    }
}
