using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())//using içindeki context garbage collector yardımıyla belleği hızlıca temizler.Performans için yazdık.
            {
                var addedEntity = context.Entry(entity);//Veri kaynağından gönderdiğim productla eşleştir.Referansı yakala 
                addedEntity.State = EntityState.Added;//Ekleme işlemi yapılacağını bildirdik. 
                context.SaveChanges();//İşlemleri gerçekleştir.
                Console.WriteLine("Ekleme işlemi yapılmıştır..");
                System.Threading.Thread.Sleep(2000);

            }

            Console.Clear();
        }

        public void Delete(TEntity entity)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                    Console.WriteLine("Sİlme işlemi yapılmıştır..");
                    System.Threading.Thread.Sleep(2000);// wait 2 seconds

                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {

                Console.WriteLine("Lütfen varolan kayıtları siliniz.");
                System.Threading.Thread.Sleep(2000);

            }
            Console.Clear();// clear console


        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {           //filter boş mu     EVET ise bütün datayı döndür           HAYIR ise filtreyi uygula 
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                using (TContext context = new TContext())
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    context.SaveChanges();
                    Console.WriteLine("Güncelleme işlemi yapılmıştır..");
                    System.Threading.Thread.Sleep(2000);

                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                Console.WriteLine("Lütfen varolan kayıtları güncelleyiniz..");             
            }
            System.Threading.Thread.Sleep(2000);

            Console.Clear();

        }
    }
}
