using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
       
        public void Add(Car entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                try
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();

                    Console.WriteLine("Ekleme işlemi tamamlandı.");
                    System.Threading.Thread.Sleep(2000);//2 saniye bekle
                    Console.Clear();

                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    Console.WriteLine("Lütfen Girilmemiş bir Id giriniz.");
                }

               
            }
        }

        public void Delete(Car entity)
        {
            try
            {
                using (ReCapProjectContext context = new ReCapProjectContext())
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                    Console.WriteLine("Kayıt silindi.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                Console.WriteLine("Olmayan kayıt silinemez");
            }
           
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
                System.Threading.Thread.Sleep(2000);
                Console.Clear();

            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
        }

        public void Update(Car entity)
        {
            try
            {
                using (ReCapProjectContext context = new ReCapProjectContext())
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    context.SaveChanges();

                    Console.WriteLine("Kayıt güncellendi.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                Console.WriteLine("Olmayan kayıt güncellenemez.");
            }
           
            
        }
    }
}
