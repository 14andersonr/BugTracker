using System;

using System.Net.Http;

namespace BugTrackerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

           var response = httpClient.GetAsync("https://localhost:44336").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }

           
        }
    }
}