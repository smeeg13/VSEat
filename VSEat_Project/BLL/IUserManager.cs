using DAL;
using System.Collections.Generic;

namespace BLL
{
    public interface IUserManager
    {
        User AddAdmin(User user);

        User AddUser(User user);
        
        void DeleteUser(int userid);
        
        string GetLocationOfUser(User user);
        
        List<User> GetUsers();
        
        User GetUserwithID(int userid);
        
        User GetUserWithName(string username, string password);
        
        string LogIn(string username, string password);
        
        string LogOut(string username, string password);
        
        string UpdateAddress(string username, string password, string newAddress);
        
        string UpdatePassword(string username, string password, string newPwd);
        
        User UpdateUser(User user);
    }
}