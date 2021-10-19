using System;
using System.IO;
using DAL;
using Microsoft.Extensions.Configuration;

namespace VSEat_Project
{
    public class Program
    {

        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

        static void Main(string[] args)
            {
           

            }
    }
}
