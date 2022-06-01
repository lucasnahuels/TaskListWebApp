using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TaskListWebApp.Server.Database.Interfaces;

namespace TaskListWebApp.Server.Database
{
    public class Repository<TEntity, TContext> : IRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        protected TContext _dbContext { get; private set; }
        public Repository(TContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbContext = dbContext;
        }

        public virtual IQueryable<TEntity> Query()
        {
            return _dbContext.Set<TEntity>();
        }

        public virtual TEntity Get<TKey>(TKey id) where TKey : IComparable, IFormattable
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual TEntity Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);

            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<TEntity>().Attach(entity);

                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            return entity;
        }
        public virtual void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
