using System;
using System.IO;
using BLL;
using DAL;
using Microsoft.Extensions.Configuration;

namespace VSEat_Project
    {
        public class Program
        {

            private static IConfiguration Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();


            static void Main(string[] args)
            {

            var userManager = new UserManager(Configuration);
            var orderManager = new OrderManager(Configuration);


                //Add a User
                //Test add user without an address
                var newUser = userManager.AddUser(new User("Mégane", "Solliard", "", 1, "123"));
                userManager.UpdateUser(newUser);

                //Lister les Users
                var users = userManager.GetUsers();

                foreach (var user in users)
                {
                    Console.WriteLine(user.ToString());
                }

                //Get a member
                var searchMember = userManager.GetUserWithName("Scott", "Lucas");
                if (searchMember != null)
                {
                    Console.WriteLine("--- THIS IS MY USER : ----");
                    Console.WriteLine(searchMember.ToString());
                }
                else
                {
                    Console.WriteLine("The User or The Password is Wrong.");
                }


                //To Take the current day and time
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));


        }
        }
    }
