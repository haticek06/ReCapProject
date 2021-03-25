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
                                 CarName = car.Description,
                                 ModelYear = car.ModelYear

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
                //var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                //             join b in context.Brands
                //             on c.BrandId equals b.BrandId
                //             join cr in context.Colors
                //             on c.ColorId equals cr.ColorId
                //             //join i in context.CarImages
                //             //on c.Id equals i.Id
                //             select new CarDetailDto
                //             {
                //                 Id = c.Id,
                //                 CarName = c.CarName,
                //                 BrandName = b.BrandName,
                //                 ColorName = cr.ColorName,
                //                 ModelYear = c.ModelYear,
                //                 DailyPrice = c.DailyPrice,
                //                 Description = c.Description,
                //                 ImagePath = context.CarImages.Where(x => x.CarId == c.Id).FirstOrDefault().ImagePath

                //             };

                //return result.ToList();

            }
        }
    }
}
