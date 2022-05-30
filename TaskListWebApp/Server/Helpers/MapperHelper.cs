using System;
using System.Collections.Generic;
using System.Linq;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Helpers
{
    public static class MapperHelper
    {
        public static List<TaskModel> MapResponseToTaskList(string urlText)
        {
            List<string> stringList = urlText.Trim(new Char[] { '[', '"', ']' }).Split('.').ToList();
            stringList.RemoveAt(stringList.Count - 1);
            var taskList = new List<TaskModel>();
            var count = 0;
            foreach (var item in stringList)
            {
                taskList.Add(new TaskModel
                {
                    Id = count,
                    Title = item,
                    Done = (new Random()).Next(2) == 1
                });
                count++;
            }
            return taskList;
        }
    }
}
