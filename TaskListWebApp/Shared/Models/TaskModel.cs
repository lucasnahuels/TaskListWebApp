using System.ComponentModel.DataAnnotations;

namespace TaskListWebApp.Shared.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
    }
}
