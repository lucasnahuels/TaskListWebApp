using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Database.Interfaces
{
    public interface ITaskRepository
    {
        TaskModel GetById(int id);
        IEnumerable<TaskModel> GetAll();
        int Add(TaskModel taskModel);

        void Edit(TaskModel taskModel);
    }
}
