using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserManager
    {

        private IUserDB UserDb { get; }


        public UserManager(IConfiguration conf)
        {
            UserDb = new UserDB(conf);
        }

        public User AddUser(User user)
        {
            return UserDb.AddUser(user);
        }

        public User GetUser(string username, string password)
        {
            return UserDb.GetUser(username, password);
        }

        public List<User> GetUsers()
        {
            return UserDb.GetUsers();
        }

        public void UpdateUserAddress(Order order, string newAddress)
        {
            UserDb.UpdateUserAddress(order, newAddress);
        }

        public void UpdateUserPassword(Order order, string newPassword)
        {
            UserDb.UpdateUserPassword(order, newPassword);
        }

    }
}
