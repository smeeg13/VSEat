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

        public User GetUser(string Firstname, string Lastname)
        {
            return UserDb.GetUser(Firstname, Lastname);
        }

        public List<User> GetUsers()
        {
            return UserDb.GetUsers();
        }

        public void UpdateUserAddress(User user, string newAddress)
        {
            UserDb.UpdateUserAddress(user, newAddress);
        }

        public void UpdateUserPassword(User user, string newPassword)
        {
            UserDb.UpdateUserPassword(user, newPassword);
        }

    }
}
