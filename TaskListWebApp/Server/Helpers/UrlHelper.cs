using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Helpers
{
    public static class UrlHelper
    {
        public static string CallUrl()
        {
            string baseUrl = "https://hipsum.co/api/";
            WebRequest request = HttpWebRequest.Create(baseUrl + "?type=hipster-centric&sentences=3");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }

    }
}
