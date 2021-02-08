using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ICarDal carDal = new EfCarDal();

            RentACarSystem(carManager, carDal);

        }

        private static void RentACarSystem(CarManager carManager, ICarDal carDal)
        {
            bool giris = true;


            while (giris == true)
            {
                Console.WriteLine("Ekleme işlemi yapmak için : 1\nSilme işlemi yapmak için : 2\nGüncelleme işlemi için : 3\nBütün kayıtları getirmek için : 4\nModeline göre kayıt getirmek için : 5\nRengine göre kayıt getirmek için : 6\nGenel bilgi için : 7\nÇıkış için : 0");
                int secim = Convert.ToInt32(Console.ReadLine());

                string name;
                int ıd;
                int brandId;
                int colorId;
                if (secim == 1)
                {

                    Console.Write("Name : ");
                    name = Console.ReadLine();
                
                    Console.Write("Brand Id : ");
                    brandId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Color Id : ");
                    colorId = Convert.ToInt32(Console.ReadLine());

                    carDal.Add(new Car  {CarName = name, BrandId = brandId, ColorId = colorId });


                }
                else if (secim == 2)
                {
                    Console.Write("Id : ");
                    ıd = Convert.ToInt32(Console.ReadLine());

                    Car carToDelete = new Car { Id = ıd };
                    carDal.Delete(carToDelete);

                }
                else if (secim == 3)
                {

                    Console.Write("Id : ");
                    ıd = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Name : ");
                    name = Console.ReadLine();

                    Console.Write("Brand Id : ");
                    brandId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Color Id : ");
                    colorId = Convert.ToInt32(Console.ReadLine());

                    Car carToUpdate = new Car { Id = ıd, BrandId = brandId, ColorId = colorId, CarName = name };
                    carDal.Update(carToUpdate);

                }
                else if (secim == 4)
                {
                    foreach (var car in carManager.GetAll())
                    {
                        Console.WriteLine("Id of Car : {0}\nName of Car : {1}\nBrand Id of Car : {2}\nColor Id of Car : {3}\n", car.Id, car.CarName, car.BrandId, car.ColorId);
                        Console.WriteLine("=======================");
                    }
                    System.Threading.Thread.Sleep(8000);
                    Console.Clear();
                }
                else if (secim == 5)
                {
                    Console.Write("Id : ");
                    ıd = Convert.ToInt32(Console.ReadLine());
                    foreach (var car in carManager.GetCarsByBrandId(ıd))
                    {
                        Console.WriteLine("Id of Car : {0}\nName of Car : {1}\nBrand Id of Car : {2}\nColor Id of Car : {3}\n", car.Id, car.CarName, car.BrandId, car.ColorId);
                    }
                    System.Threading.Thread.Sleep(8000);
                    Console.Clear();
                }
                else if (secim == 6)
                {
                    Console.Write("Id : ");
                    ıd = Convert.ToInt32(Console.ReadLine());
                    foreach (var car in carManager.GetCarsByColorId(ıd))
                    {
                        Console.WriteLine("Id of Car : {0}\nName of Car : {1}\nBrand Id of Car : {2}\nColor Id of Car : {3}\n", car.Id, car.CarName, car.BrandId, car.ColorId);
                    }
                    System.Threading.Thread.Sleep(8000);
                    Console.Clear();
                }
                else if (secim==7)
                {
                    foreach (var car in carManager.GetCarDetails())
                    {
                        Console.WriteLine("Car Id : {0}\nCar Name {1}\nBrand Name : {2}\nColor Name : {3} ",car.CarId,car.CarName,car.BrandName,car.ColorName);
                        Console.WriteLine("==========================");
                    }
                    System.Threading.Thread.Sleep(8000);
                    Console.Clear();
                }
                else if (secim == 0)
                {
                    giris = false;
                }




            }
        }
    }
}
