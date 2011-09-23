
using System;
using Nancy.Hosting.Self;

namespace NancyStartingPoint
{
    class Program
    {
        private const string ROOT_URL = "http://localhost:8888/";

        static void Main(string[] args)
        {
            var nancyHost = new NancyHost(new Uri(ROOT_URL), new StaticContentBootstrapper(ROOT_URL));

            nancyHost.Start();

            Console.WriteLine(String.Format("Nancy now listening - navigate to {0}. \r\n\r\nPress enter to stop", ROOT_URL));
            Console.ReadKey();

            nancyHost.Stop();

            Console.WriteLine("Stopped. Good bye!");
        }
    }
}
