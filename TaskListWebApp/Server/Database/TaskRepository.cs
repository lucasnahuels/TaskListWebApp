using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskListWebApp.Server.Database.Interfaces;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Database
{
    public class TaskRepository: Repository<TaskModel, ApplicationDbContext>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public TaskModel GetById(int id) => Get<int>(id);
        public IEnumerable<TaskModel> GetAll() => Query().ToList();
        public int Add(TaskModel taskModel) => Create(taskModel).Id;

        public void Edit(TaskModel taskModel) => Update(taskModel);
        public void Remove(TaskModel taskModel) => Delete(taskModel);
    }
}
