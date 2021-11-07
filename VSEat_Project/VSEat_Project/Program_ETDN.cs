using System;
using System.IO;
using BLL;
using DAL;
using Microsoft.Extensions.Configuration;

namespace VSEat_Project
{
    class Program_ETDN
    {
        private static IConfiguration Configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();

        static void Main(string[] args)
        {
            var delivererManager = new DelivererManager(Configuration);


            //Add a User
            //Test add user without an address
            var newDeliverer = delivererManager.AddDeliverer(new Deliverer("ETDN", "yoooo", 0, 1));
            delivererManager.UpdateDelivererAvailability(newDeliverer);

            //List the deliverer
            var deliverers = delivererManager.GetDeliverers();

            foreach (var user in deliverers)
            {
                Console.WriteLine(user.ToString());
            }
        }
    }
}
