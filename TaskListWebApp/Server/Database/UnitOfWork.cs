using Microsoft.EntityFrameworkCore;
using System;
using TaskListWebApp.Server.Database.Interfaces;

namespace TaskListWebApp.Server.Database
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        protected TContext _dbContext { get; private set; }

        public UnitOfWork(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Complete()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while committing unit of work changes.", ex);
            }
        }
    }
}

