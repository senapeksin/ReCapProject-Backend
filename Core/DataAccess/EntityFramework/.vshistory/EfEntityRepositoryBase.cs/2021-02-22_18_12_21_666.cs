﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // referansı yakalama
                addedEntity.State = EntityState.Added;   //Durumu ekle yapıyorum
                context.SaveChanges();                   //ekleme işlemini yap 
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Update(TEntity entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
