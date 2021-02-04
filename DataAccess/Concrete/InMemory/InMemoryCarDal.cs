using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    //public class InMemoryCarDal : ICarDal
    //{
    //    List<Car> _cars;
    //    public InMemoryCarDal()
    //    {
    //        _cars = new List<Car>
    //        {
    //            new Car{CarId=1,BrandId=101,ColorId=1001,Description="Fiat Egea 30.000 KM ",DailyPrice=300,ModelYear="2017"},
    //            new Car{CarId=2,BrandId=102,ColorId=1002,Description="Wolswagen Tiguan 140.000 KM ",DailyPrice=350,ModelYear="2013"},
    //            new Car{CarId=3,BrandId=103,ColorId=1003,Description="Renault Kadjar 56.400 KM ",DailyPrice=470,ModelYear="2020"},
    //            new Car{CarId=4,BrandId=104,ColorId=1004,Description="Hyundai Tucson 25.300 KM ",DailyPrice=220,ModelYear="2015"}

    //        };
    //    }

    //    public void Add(Car car)
    //    {
    //        _cars.Add(car);
    //        Console.WriteLine("Added : {0}\nDaily Price :  {1}\nModelYear : {2}",car.Description,car.DailyPrice,car.ModelYear);
    //        Console.WriteLine("------------------------");
    //    }



    //    public void Delete(Car car)
    //    {
    //        Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

    //        _cars.Remove(carToDelete);
    //    }

    //    public Car Get(Expression<Func<Car, bool>> filter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Car> GetAll()
    //    {
    //        return _cars;

    //    }

    //    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Car> GetById(int CarId)
    //    {
    //        return _cars = _cars.Where(c => c.CarId == CarId).ToList();

    //    }

    //    public void Update(Car car)
    //    {
    //        Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
           

    //    }
    //}
}
