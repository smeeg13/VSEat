using System.Collections.Generic;

namespace DAL
{
    public interface IUserDB
    {
        //Method the list all users in the Database
        List<User> GetUsers();

        //Method to get the user with his username and his password
        User GetUserWithUsername(string username, string password);

        //Method to get the userID with his Firstname and his Lastname
        int GetUserIDWithName(string firstname, string Lastname);

        //Method to get the user with his ID
        User GetUserWithID(int userid);

        //Method to Add one User in the database
        User AddUser(User user);

        //Method to Add an Administrator in the database
        User AddAdmin(User user, char isadmin);

        //Method to Update one User in the database
        User UpdateUser(User user);

        //Method to delete one User in the database
        void DeleteUser(int userid);

    }
}