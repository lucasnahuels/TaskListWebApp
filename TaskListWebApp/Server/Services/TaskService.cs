using System.Collections.Generic;
using System.Linq;
using TaskListWebApp.Server.Database.Interfaces;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TaskService(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public List<ToDoTask> Get()
        {
            return _taskRepository.GetAll().ToList();
        }

        public void ChangeStatus(ToDoTask toDoTask)
        {
            toDoTask.Done = !toDoTask.Done;
            _taskRepository.Edit(toDoTask);
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            var taskToDelete =_taskRepository.GetById(id);
            _taskRepository.Remove(taskToDelete);
            _unitOfWork.Complete();
        }
    }
}
