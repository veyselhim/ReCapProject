using Business.Concrete;
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

            UserManager userManager = new UserManager(new EfUserDal());

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            bool giris = true;

            while (giris)
            {
                Console.WriteLine("Ne işlem yapmak istiyorsununuz ?\n\n----------------------------------------");

                Console.WriteLine("********Araba İşlemleri*********\n\n"+
                                  "Ekleme işlemi yapmak için : 1\n" +
                                  "Silme işlemi yapmak için : 2\n" +
                                  "Güncelleme işlemi için : 3\n" +
                                  "Bütün kayıtları getirmek için : 4\n" +
                                  "Modeline göre kayıt getirmek için : 5\n" +
                                  "Rengine göre kayıt getirmek için : 6\n" +
                                  "Genel araba bilgisi için : 7\n\n" +
                                  "********Kullanıcı İşlemleri********\n\n"+
                                  "Kullanıcı eklemek için : 8\n" +
                                  "Kullanıcı silmek için : 9\n"+
                                  "Kullanıcı güncellemek için : 10\n"+
                                  "Bütün kayıtları getirmek için : 11\n"+
                                  "Müşteri eklemek için : 12\n"+
                                  "Müşteri silmek için : 13\n"+
                                  "Müşteri güncellemek için : 14\n"+
                                  "Araba kirala : 15\n"+
                                  "Kiralama bilgisini güncelle : 16\n"+
                                  "Kira bilgilerini getir : 17\n"+
                                  "Çıkış için : 0");



                int secim = Convert.ToInt32(Console.ReadLine());


                switch (secim)
                {
                    case 1:
                        AddCar(carManager);
                        break;
                    case 2:
                    {
                        DeleteCar(carManager);
                        break;
                    }
                    case 3:
                    {
                        UpdateCar(carManager);
                        break;
                    }
                    case 4:
                    {
                        GetCarsInfo(carManager);
                        break;
                    }
                    case 5:
                    {
                        GetCarsByBrandId(carManager);
                        break;
                    }
                    case 6:
                    {
                        GetCarsByColorId(carManager);
                        break;
                    }
                    case 7:
                    {
                        GetCarDetails(carManager);

                        break;
                    }
                    case 8:
                    {
                        AddUser(userManager);

                        break;
                    }
                    case 9:
                    {
                        DeleteUser(userManager);

                        break;
                    }
                    case 10:
                    {
                        UpdateUser(userManager);

                        break;
                    }
                    case 11:
                    {
                        GetUsersInfo(userManager);

                        break;
                    }
                    case 12:
                    {
                        AddCustomer(customerManager);

                        break;
                    }
                    case 13:
                    {
                        DeleteCustomer(customerManager);
                        break;
                    }
                    case 14:
                    {
                        UpdateCustomer(customerManager);

                        break;
                    }
                    case 15:
                    {
                        RentalAdd(rentalManager);

                        break;
                    }
                    case 16:
                    {
                        RentalUpdate(rentalManager);

                        break;
                    }
                    case 17:
                    {
                        GetRentals(rentalManager);

                        break;
                    }

                    case 0:
                        giris = false;
                        break;
                }




            }

       


            
        }

        private static void GetRentals(RentalManager rentalManager)
        {
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Rental Id : {0}\nCar Id : {1}\nCustomer Id : {2}\nRent Date : {3}", rental.Id, rental.CarId,
                    rental.CustomerId, rental.RentDate);
                Console.WriteLine("------------------------");
            }

            System.Threading.Thread.Sleep(8000);
            Console.Clear();
        }
       public static DateTime rentDate = DateTime.Now;
        private static void RentalUpdate(RentalManager rentalManager)
        {
            int Id;
            int carId;
            int customerId;
          
            Console.WriteLine("Id : ");
            Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Car Id : ");
            carId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Customer Id : ");
            customerId = Convert.ToInt32(Console.ReadLine());


            rentalManager.Update(new Rental
                {Id = Id, CustomerId = customerId, CarId = carId, ReturnDate = DateTime.Now,RentDate = rentDate});
        }

        private static void RentalAdd(RentalManager rentalManager)
        {
            int carId;
            int customerId;
            Console.WriteLine("Car Id : ");
            carId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Customer Id : ");
            customerId = Convert.ToInt32(Console.ReadLine());

            rentalManager.Add(new Rental
                {CarId = carId, CustomerId = customerId, RentDate = DateTime.Now});
        }

        private static void DeleteCustomer(CustomerManager customerManager)
        {
            Console.WriteLine("Customer Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            customerManager.Delete(new Customer {CustomerId = id});
        }

        private static void UpdateCustomer(CustomerManager customerManager)
        {
            int id;
            string companyName;
            int userId;
            Console.Write("Customer Id : ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write("User Id : ");
            userId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Company Name : ");
            companyName = Console.ReadLine();


            customerManager.Update(new Customer {CustomerId = id, UserId = userId, CompanyName = companyName});
        }

        private static void AddCustomer(CustomerManager customerManager)
        {
            int userId;
            string companyName;

            Console.Write("User Id : ");
            userId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Company Name : ");
            companyName = Console.ReadLine();

            customerManager.Add(new Customer {UserId = userId, CompanyName = companyName});
        }

        private static void UpdateUser(UserManager userManager)
        {
            int id;
            string firstName;
            string lastName;
            string eMail;
            string password;

            Console.Write("Id : ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write("First Name : ");
            firstName = Console.ReadLine();

            Console.Write("Last Name : ");
            lastName = Console.ReadLine();

            Console.Write("E-Mail : ");
            eMail = Console.ReadLine();

            Console.Write("Password : ");
            password = Console.ReadLine();


            userManager.Update(new User
                {UserId = id, FirstName = firstName, LastName = lastName, Email = eMail, Password = password});
        }

        private static void GetUsersInfo(UserManager userManager)
        {
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine("User Id : {0}\nUser First Name : {1}\nUser Last Name : {2}\nUser E-mail : {3}\nUser Password : {4}", user.UserId, user.FirstName, user.LastName, user.Email, user.Password);
                Console.WriteLine("=======================");
            }

            System.Threading.Thread.Sleep(8000);
            Console.Clear();
        }

        private static void DeleteUser(UserManager userManager)
        {
            int id;
            Console.Write("Id : ");
            id = Convert.ToInt32(Console.ReadLine());

            User userToDelete = new User {UserId = id};
            userManager.Delete(userToDelete);
        }

        private static void AddUser(UserManager userManager)
        {
            string firstName;
            string lastName;
            string eMail;
            string password;
            Console.Write("First Name : ");
            firstName = Console.ReadLine();

            Console.Write("Last Name : ");
            lastName = Console.ReadLine();

            Console.Write("E-Mail : ");
            eMail = Console.ReadLine();

            Console.Write("Password : ");
            password = Console.ReadLine();

            userManager.Add(new User {FirstName = firstName, LastName = lastName, Email = eMail, Password = password});
        }


        private static void GetCarDetails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Id : {0}\nCar Name {1}\nBrand Name : {2}\nColor Name : {3} ", car.CarId,
                        car.CarName, car.BrandName, car.ColorName);
                    Console.WriteLine("==========================");
                }

                System.Threading.Thread.Sleep(8000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine(result.Message);
                System.Threading.Thread.Sleep(8000);
                Console.Clear();
            }
        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            int id;
            Console.Write("Id : ");
            id = Convert.ToInt32(Console.ReadLine());
            foreach (var car in carManager.GetCarsByColorId(id).Data)
            {
                Console.WriteLine(
                    "Id of Car : {0}\nName of Car : {1}\nBrand Id of Car : {2}\nColor Id of Car : {3}\n", car.Id,
                    car.CarName, car.BrandId, car.ColorId);
            }

            System.Threading.Thread.Sleep(8000);
            Console.Clear();
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            int id;
            Console.Write("Id : ");
            id = Convert.ToInt32(Console.ReadLine());
            foreach (var car in carManager.GetCarsByBrandId(id).Data)
            {
                Console.WriteLine(
                    "Id of Car : {0}\nName of Car : {1}\nBrand Id of Car : {2}\nColor Id of Car : {3}\n", car.Id,
                    car.CarName, car.BrandId, car.ColorId);
            }

            System.Threading.Thread.Sleep(8000);
            Console.Clear();
        }

        private static void GetCarsInfo(CarManager carManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(
                    "Id of Car : {0}\nName of Car : {1}\nBrand Id of Car : {2}\nColor Id of Car : {3}\n", car.Id,
                    car.CarName, car.BrandId, car.ColorId);
                Console.WriteLine("=======================");
            }

            System.Threading.Thread.Sleep(8000);
            Console.Clear();
        }
        
        private static void UpdateCar(CarManager carManager)
        {
            int id;
            string name;
            int brandId;
            int colorId;
            Console.Write("Id : ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name : ");
            name = Console.ReadLine();

            Console.Write("Brand Id : ");
            brandId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Color Id : ");
            colorId = Convert.ToInt32(Console.ReadLine());

            Car carToUpdate = new Car {Id = id, BrandId = brandId, ColorId = colorId, CarName = name};
            carManager.Update(carToUpdate);
        }
        private static void DeleteCar(CarManager carManager)
        {
            int Id;
            Console.Write("Id : ");
            Id = Convert.ToInt32(Console.ReadLine());

            Car carToDelete = new Car {Id = Id};
            carManager.Delete(carToDelete);
        }
       
        private static void AddCar(CarManager carManager)
        {
            string name;
            int brandId;
            int colorId;
            Console.Write("Name : ");
            name = Console.ReadLine();

            Console.Write("Brand Id : ");
            brandId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Color Id : ");
            colorId = Convert.ToInt32(Console.ReadLine());

            carManager.Add(new Car {CarName = name, BrandId = brandId, ColorId = colorId});
        }
    }


}


