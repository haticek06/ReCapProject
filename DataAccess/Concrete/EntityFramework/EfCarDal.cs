using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join carImage in context.CarImages on car.Id equals carImage.CarId
                             select new CarDetailDto()
                             {
                                 Id = car.Id,
                                 ImagePath = carImage.ImagePath,
                                 Description = car.Description,
                                 BrandId = brand.BrandId,
                                 BrandName = brand.BrandName,
                                 CarImageDate = carImage.Date,
                                 ColorId = color.ColorId,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 CarName = car.CarName,
                                 ModelYear = car.ModelYear,
                                 FindexScore =car.FindexScore

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
           

            }
        }

        //public CarDetailDto GetCarFilter(Expression<Func<CarDetailDto, bool>> filter)
        //{
        //    using (ReCapProjectDBContext context = new ReCapProjectDBContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands on c.BrandId equals b.BrandId
        //                     join r in context.Colors on c.ColorId equals r.ColorId
        //                     let i = context.CarImages.Where(x => x.CarId == c.Id).FirstOrDefault()
        //                     select new CarDetailDto()
        //                     {
        //                         Id = c.Id,
        //                         BrandName = b.BrandName,
        //                         DailyPrice = c.DailyPrice,
        //                         ColorName = r.ColorName,
        //                         Description = c.Description,
        //                         ImagePath = i.ImagePath
        //                     };
        //        return result.SingleOrDefault(filter);
        //    }
        //}
    }
}
