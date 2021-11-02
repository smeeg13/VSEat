using System.Collections.Generic;

namespace DAL
{
    public interface IUserDB
    {
        User AddUser(User user);
        User GetUser(string Firstname, string Lastname);
        List<User> GetUsers();
        void UpdateUserAddress(User user, string newAddress);
        void UpdateUserPassword(User user, string newPassword);
    }
}