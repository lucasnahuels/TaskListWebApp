using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult<List<TaskModel>> Get()
        {
            UrlHelper.CallUrl();
            var list = new List<TaskModel>
            {
                new TaskModel
                {
                    Id= 1,
                    Title = "Cooking",
                    Done= false
                },
                new TaskModel
                {
                    Id= 2,
                    Title = "Cleaning",
                    Done= true
                }
            };
            return list;
            //return _taskRepository.GetAll().ToList();
        }
    }
}
