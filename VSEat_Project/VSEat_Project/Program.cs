using System;
using System.IO;
using BLL;
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

            var userManager = new UserManager(Configuration);


            //Add a User
         //   var newUser = userManager.AddUser(new User("Scott", "Lucas", "Rte", "123"));

            //Lister les Users
            // var userrDb = new UserDB(Configuration);
            var users = userManager.GetUsers();

            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }

            //Get a member
            var searchMember = userManager.GetUser("Scott", "Lucas");
            if (searchMember != null)
            {
                Console.WriteLine(searchMember.ToString());
            }
            else
            {
                Console.WriteLine("Email or Password is wrong, no user found !");
            }


        }
    }
}
