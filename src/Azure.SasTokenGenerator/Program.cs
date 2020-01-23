using System;

namespace Azure.SasTokenGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var appConfiguration = AppConfiguration.ReadFromJsonFile("appsettings.json");

        }
    }
}
