using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
       IDataResult<List<Car>> GetAll();

       IDataResult<List<Car>> GetCarsByUnitPrice(decimal min , decimal max);

       IDataResult<List<Car>> GetCarsByBrandId(int id);

       IDataResult<List<Car>> GetCarsByColorId(int id);

       IDataResult<List<CarDetailDto>> GetCarsByColorAndBrand(int colorId, int brandId);

       IDataResult<List<CarDetailDto>> GetCarDetails();

       IDataResult<List<CarDetailDto>> GetCarDetail(int carId);


        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);
       IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);

        IDataResult<Car> GetById(int carId);

       IResult Add(Car car);

       IResult Delete(Car car);

       IResult Update(Car car);

    }
}
