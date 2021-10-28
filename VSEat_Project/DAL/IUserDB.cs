using System.Collections.Generic;

namespace DAL
{
    public interface IUserDB
    {
        User AddUser(User user);
        User GetUser(string username, string password);
        List<User> GetUsers();
        void UpdateUserAddress(Order order, string newAddress);
        void UpdateUserPassword(Order order, string newPassword);
    }
}