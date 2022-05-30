using System;
using System.Threading.Tasks;

namespace TaskListWebApp.Server.Database.Interfaces
{
    public interface IUnitOfWork
    {
        int Complete();
    }
}
