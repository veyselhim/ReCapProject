using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Özellikler : {0}\nGünlük Fiyatı : {1}\nModel Yılı : {2}",car.Description,car.DailyPrice,car.ModelYear);
            }
        }
    }
}
