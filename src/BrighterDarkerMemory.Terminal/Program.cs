using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace BrighterDarkerMemory.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();

            using (var client = new HttpClient())
            {
                while (true)
                {
                    watch.Reset();
                    watch.Start();

                    // If you don't use the query processor there is no memory leak
                    // and the context is brought in correctly
                    //var response = client.GetAsync("http://localhost:51673/api/test-no-processor").Result;

                    // If you use the query processor the memory leak occurs due to the query
                    // processor being a singleton and trying to create scoped instances
                    var response = client.GetAsync("http://localhost:51673/api/test").Result;

                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;

                    watch.Stop();

                    Console.WriteLine($"Posted in {watch.Elapsed.Milliseconds.ToString()} milliseconds.");
                    Thread.Sleep(100);
                }
            }
        }
    }
}
