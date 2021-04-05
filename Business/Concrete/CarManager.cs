using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            
            
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        [SecuredOperation("car.delete,admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id),Messages.CarIdListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //if(DateTime.Now.Hour==12)
            //{
            //    return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        public IDataResult<List<CarDetailDto>> GetCarsByBrandAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId));
        }

        //public IDataResult<List<Car>> GetCarsByBrandId(int id)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),Messages.CarsByBrandId);
        //}

        //public IDataResult<List<Car>> GetCarsByColorId(int id)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id),Messages.CarsByColorId);
        //}

        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);


        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);

            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }

            Add(car);

            return null;
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.Id == carId));
        }
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId), Messages.CarsByBrandId);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId), Messages.CarsByColorId);
        }

    }
}
