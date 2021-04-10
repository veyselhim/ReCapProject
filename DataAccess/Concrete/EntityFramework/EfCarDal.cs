using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in filter==null ? context.Cars :context.Cars.Where(filter)
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, CarName = c.CarName, ColorName = cl.ColorName,UnitPrice = c.UnitPrice,CarFindexScore = c.CarFindexScore,Images =
                                 (from i in context.CarImages where i.CarId == c.CarId select i.ImagePath).ToList()  };
                return result.ToList();
                             


            }

        }

        public List<CarDetailDto> GetCarDetail(int carId,Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join cl in context.Colors on c.ColorId equals cl.ColorId
                    select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, CarName = c.CarName, ColorName = cl.ColorName, UnitPrice = c.UnitPrice,CarFindexScore = c.CarFindexScore,Images = 
                        (from i in context.CarImages where i.CarId == c.CarId select i.ImagePath).ToList() };

                return result.ToList();

            }



        }

        


    }
}
