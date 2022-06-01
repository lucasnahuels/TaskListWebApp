using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TaskListWebApp.Server.Database.Interfaces;
using TaskListWebApp.Server.Services;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<List<ToDoTask>> Get()
        {
            return _taskService.Get();
        }

        [HttpPut("change-status")]
        public void ChangeStatus(ToDoTask toDoTask)
        {
            _taskService.ChangeStatus(toDoTask);
        }

        [HttpDelete("{id}")]
        public void ChangeStatus(int id)
        {
            _taskService.Delete(id);
        }
    }
}
