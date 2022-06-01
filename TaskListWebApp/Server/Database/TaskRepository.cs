using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskListWebApp.Server.Database.Interfaces;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Database
{
    public class TaskRepository: Repository<ToDoTask, ApplicationDbContext>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public ToDoTask GetById(int id) => Get<int>(id);
        public IEnumerable<ToDoTask> GetAll() => Query().ToList();
        public int Add(ToDoTask toDoTask) => Create(toDoTask).Id;

        public void Edit(ToDoTask toDoTask) => Update(toDoTask);
        public void Remove(ToDoTask toDoTask) => Delete(toDoTask);
    }
}
