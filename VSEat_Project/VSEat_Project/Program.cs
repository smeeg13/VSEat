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
            var newMessage = userManager.AddUser(new User("Scott", "Lucas", "s.l@gmail.com", "Rte", "Scot-Lu", "123", "active"));

            //Lister les Users
                // var userrDb = new UserDB(Configuration);
            var users = userManager.GetUsers();

            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }

            //Get a member
            var searchMember = userManager.GetUser("m.sol@hotmail.com", "1234");
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
