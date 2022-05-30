using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListWebApp.Server.Database.Interfaces
{
    public interface IRepository<TEntity> 
    {
        IQueryable<TEntity> Query();
        TEntity Get<TKey>(TKey id) where TKey : IComparable, IFormattable;

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

    }

    public interface IRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
    }
}
