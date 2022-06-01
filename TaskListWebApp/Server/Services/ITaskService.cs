using System.Collections.Generic;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Services
{
    public interface ITaskService
    {
        List<ToDoTask> Get();
        void ChangeStatus(ToDoTask toDoTask);
    }
}
