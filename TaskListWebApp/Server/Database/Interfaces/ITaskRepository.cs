using System.Collections.Generic;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Database.Interfaces
{
    public interface ITaskRepository : IRepository<ToDoTask>
    {
        ToDoTask GetById(int id);
        IEnumerable<ToDoTask> GetAll();
        int Add(ToDoTask toDoTask);

        void Edit(ToDoTask toDoTask);
        void Remove(ToDoTask toDoTask);
    }
}
