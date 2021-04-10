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
                var addedEntity = context.Entry(entity); 
                addedEntity.State = EntityState.Added;//Ekleme işlemi yapılacağını bildirdik. 
                context.SaveChanges();//İşlemleri gerçekleştir.

            }

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

                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {


            }


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
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {

            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
