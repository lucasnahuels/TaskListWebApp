using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Helpers
{
    public static class GetUrlHelper
    {
        public static async Task<List<ToDoTask>> GetResponseAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://hipsum.co/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = await client.GetAsync("?type=hipster-centric&sentences=3");
                
                var stringResponse = await response.Content.ReadAsStringAsync();

                return MapResponseToTaskList(stringResponse);
            }
        }

        private static List<ToDoTask> MapResponseToTaskList(string urlText)
        {
            List<string> stringList = urlText.Trim(new Char[] { '[', '"', ']' }).Split('.').ToList();
            stringList.RemoveAt(stringList.Count - 1);
            var taskList = new List<ToDoTask>();
            foreach (var item in stringList)
            {
                taskList.Add(new ToDoTask
                {
                    Title = item,
                    Done = (new Random()).Next(2) == 1
                });
            }
            return taskList;
        }
    }
}
