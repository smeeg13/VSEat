using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSEat_Project;

namespace BLL
{
    public class UserManager 
    {

        private IUserDB UserDb { get; }
        private ILocationDB LocationDb { get; }


        //Constructor
        public UserManager(IConfiguration conf)
        {
            UserDb = new UserDB(conf);
        }

        //Method to list all users in the Database
        public List<User> GetUsers()
        {
            return UserDb.GetUsers();
        }

        //Method to get the user with his username and his password
        public User GetUserWithName(string username, string password)
        {
            User user = new User();

            user = UserDb.GetUserWithName(username, password);

            if (user == null)
                throw new BusinessExceptions(" Username or Password wrong, Try again ");

            return user;
        }

        //Method to get the user with his username and his password
        public User GetUserwithID(int userid)
        {
            User user;

            user = UserDb.GetUserWithID(userid);

            return user;
        }

        //Method to get Location of the user
        public string GetUserLocation(User user)
        {
            int locationId;
            string locationName = null;
            int locationZIP ;

            User userForLocation = UserDb.GetUserWithName(user.Username, user.Password);
            locationId = userForLocation.UserID;

            Location location = LocationDb.GetLocationID(locationId);
            locationName = location.NameCity;
            locationZIP = location.ZIP;

            return locationZIP+" " + locationName;
        }

        //Method to Add one User in the database
        public User AddUser(User user)
        {
            if (user.Address == null)
                throw new BusinessExceptions("User must have an address !");

            return UserDb.AddUser(user);
        }

        //Method to Add an Administrator in the database
        public User AddAdmin(User user)
        {
            char isadmin = 'y';

            if (user.Address == null)
                throw new BusinessExceptions("User must have an address !");

            return UserDb.AddAdmin(user, isadmin);
        }

        //Method to Update one User in the database
        public User UpdateUser(User user)
        {
            return UserDb.UpdateUser(user);
        }

        //Method to delete one User in the database
        public void DeleteUser(int userid)
        {
            UserDb.DeleteUser(userid);
        }

        //Method to login
        public string LogIn(string username, string password)
        {
            string isConnected = null;

            User user = GetUserWithName(username, password);
            user.StatusAccount = "Connected";
            user = UserDb.UpdateUser(user);

            isConnected = user.StatusAccount;

            return isConnected;
        }

        //Method to logout
        public string LogOut(string username, string password)
        {
            string isConnected = null;

            User user = GetUserWithName(username, password);
            user.StatusAccount = "Logged Out";
            user = UserDb.UpdateUser(user);

            isConnected = user.StatusAccount;

            return user.Username + " " + isConnected;
        }

        //Update the password
        public string UpdatePassword(string username, string password, string newPwd)
        {
            string pwdIsChanged = null;

            User user = null;
            user = UserDb.GetUserWithName(username, password);
            user.Password = newPwd;
            user = UserDb.UpdateUser(user);
            pwdIsChanged = "The Password has been changed !";

            return pwdIsChanged;
        }

        //Update the address
        public string UpdateAddress(string username, string password, string newAddress)
        {
            string AddressIsChanged = null;

            User user = null;
            user = UserDb.GetUserWithName(username, password);
            user.Address = newAddress;
            user = UserDb.UpdateUser(user);
            AddressIsChanged = "The address has been changed !";

            return AddressIsChanged;
        }

        //Method to update LocationID of the Restaurant in the database
        public string UpdateLocation(User user, string newlocation)
        {
            string LocationIsChanged = null;
            int locationId=0;

            User UserUpdated = null;
            UserUpdated = UserDb.GetUserWithName(user.Username, user.Password);
            locationId = LocationDb.GetLocationID(newlocation); //Get the id location with the location name

            UserUpdated.LocationID = locationId;
            UserUpdated = UserDb.UpdateUser(UserUpdated);

            LocationIsChanged = "The locationID has been changed !";
            return LocationIsChanged;
        }
    }
}
