using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TaskListWebApp.Server.Database.Interfaces;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        [HttpGet]
        public ActionResult<List<ToDoTask>> Get()
        {
            return _taskRepository.GetAll().ToList();
        }
    }
}
