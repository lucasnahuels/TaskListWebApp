using System;
using System.Collections.Generic;
using TaskListWebApp.Server.Helpers;
using TaskListWebApp.Shared.Models;
using Xunit;

namespace TaskListWebApp.Test
{
    public class GetUrlHelperTest
    {
        [Fact]
        public void MapResponseToTaskList()
        {
            //arrange
            string urlTextResponse = "[\"Air plant cardigan banh mi listicle single-origin coffee master cleanse. 3 wolf moon normcore gentrify narwhal post-ironic. Forage swag pug, copper mug chicharrones twee letterpress lo-fi try-hard franzen actually sartorial kogi.\"]";
            List<ToDoTask> expectedResponse = new List<ToDoTask>
            {
                new ToDoTask
                {
                    Title = "Air plant cardigan banh mi listicle single-origin coffee master cleanse"
                },
                new ToDoTask
                {
                    Title = " 3 wolf moon normcore gentrify narwhal post-ironic"
                },
                new ToDoTask
                {
                    Title = " Forage swag pug, copper mug chicharrones twee letterpress lo-fi try-hard franzen actually sartorial kogi"
                }
            };
            
            //act
            var response = GetUrlHelper.MapResponseToTaskList(urlTextResponse);

            //assert
            Assert.Equal(expectedResponse.Count, response.Count);
            Assert.Equal(expectedResponse[0].Title, response[0].Title);
            Assert.Equal(expectedResponse[1].Title, response[1].Title);
            Assert.Equal(expectedResponse[2].Title, response[2].Title);
        }
    }
}
