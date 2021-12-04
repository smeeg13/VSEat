using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserManager
    {
        User AddAdmin(User user);
        User AddUser(User user);
        void DeleteUser(int userid);
        string GetUserLocation(User user);
        List<User> GetUsers();
        User GetUserwithID(int userid);
        User GetUserWithName(string username, string password);
        string LogIn(string username, string password);
        string LogOut(string username, string password);
        string UpdateAddress(string username, string password, string newAddress);
        string UpdateLocation(User user, string newlocation);
        string UpdatePassword(string username, string password, string newPwd);
        User UpdateUser(User user);
    }
}