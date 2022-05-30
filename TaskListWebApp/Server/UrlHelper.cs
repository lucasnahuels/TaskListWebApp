using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TaskListWebApp.Server
{
    public  static class UrlHelper
    {
        public static void CallUrl()
        {
            string baseUrl = "https://hipsum.co/api/";
            WebRequest request = HttpWebRequest.Create(baseUrl + "?type=hipster-centric&sentences=3");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string urlText = reader.ReadToEnd();
            Debug.Write(urlText.ToString());
        }
    }
}
