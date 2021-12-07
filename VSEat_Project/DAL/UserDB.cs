using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDB : IUserDB
    {
        private IConfiguration Configuration { get; }

        //Constructor
        public UserDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Method the list all users in the Database
        public List<User> GetUsers()
        {
            List<User> results = null;

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Users;";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<User>();

                            User user = new User();

                            user.UserID = (int)dr["UserID"];

                            if (dr["Lastname"] != null)
                                user.Lastname = (string)dr["Lastname"];

                            if (dr["Firstname"] != null)
                                user.Firstname = (string)dr["Firstname"];
                            if (dr["Username"] != null)
                                user.Username = (string)dr["Username"];

                            if (dr["Address"] != null)
                                user.Address = (string)dr["Address"];

                            user.Password = (string)dr["Password"];

                            if (dr["LocationID"] != null)
                                user.LocationID = (int)dr["LocationID"];

                            if (dr["StatusAccount"] != null)
                                user.StatusAccount = (string)dr["StatusAccount"];
                            if (dr["IsAdmin"] != null)
                                user.IsAdmin = (char)dr["IsAdmin"];

                            results.Add(user);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }


        //Method to get the user with his username and his password
        public User GetUserWithUsername(string username, string password)
        {
            User result = null;

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Users WHERE Username=@Username AND Password=@Password";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new User();

                            result.UserID = (int)dr["UserID"];

                            if (dr["Lastname"] != null)
                                result.Lastname = (string)dr["Lastname"];

                            if (dr["Firstname"] != null)
                                result.Firstname = (string)dr["Firstname"];
                            if (dr["Username"] != null)
                                result.Username = (string)dr["Username"];

                            if (dr["Address"] != null)
                                result.Address = (string)dr["Address"];

                            result.Password = (string)dr["Password"];

                            if (dr["LocationID"] != null)
                                result.LocationID = (int)dr["LocationID"];

                            if (dr["StatusAccount"] != null)
                                result.StatusAccount = (string)dr["StatusAccount"];
                            if (dr["IsAdmin"] != null)
                                result.IsAdmin = (char)dr["IsAdmin"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        //Method to get the userID with his Firstname and his Lastname
        public int GetUserIDWithName(string firstname, string lastname)
        {
            User result = null;

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Users WHERE Firstname=@Firstname AND Lastname=@Lastname";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Firstname", firstname);
                    cmd.Parameters.AddWithValue("@Lastname", lastname);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new User();

                            result.UserID = (int)dr["UserID"];

                            if (dr["Lastname"] != null)
                                result.Lastname = (string)dr["Lastname"];

                            if (dr["Firstname"] != null)
                                result.Firstname = (string)dr["Firstname"];
                            if (dr["Username"] != null)
                                result.Username = (string)dr["Username"];

                            if (dr["Address"] != null)
                                result.Address = (string)dr["Address"];

                            result.Password = (string)dr["Password"];

                            if (dr["LocationID"] != null)
                                result.LocationID = (int)dr["LocationID"];

                            if (dr["StatusAccount"] != null)
                                result.StatusAccount = (string)dr["StatusAccount"];
                            if (dr["IsAdmin"] != null)
                                result.IsAdmin = (char)dr["IsAdmin"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result.UserID;

        }

        //Method to get the user with his ID
        public User GetUserWithID(int userID)
        {
            User result = null;

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Users WHERE UserID=@UserID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = new User();

                            result.UserID = (int)dr["UserID"];

                            if (dr["Lastname"] != null)
                                result.Lastname = (string)dr["Lastname"];

                            if (dr["Firstname"] != null)
                                result.Firstname = (string)dr["Firstname"];
                            if (dr["Username"] != null)
                                result.Username = (string)dr["Username"];

                            if (dr["Address"] != null)
                                result.Address = (string)dr["Address"];

                            result.Password = (string)dr["Password"];

                            if (dr["LocationID"] != null)
                                result.LocationID = (int)dr["LocationID"];

                            if (dr["StatusAccount"] != null)
                                result.StatusAccount = (string)dr["StatusAccount"];
                            if (dr["IsAdmin"] != null)
                                result.IsAdmin = (char)dr["IsAdmin"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }


        //Method to Add one User in the database
        public User AddUser(User user)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Users(Firstname, Lastname,Username,  Password ,Address, LocationID, StatusAccount, IsAdmin) values(@firstname ,@lastname,@username, @password, @address, @locationID, @statusAccount, @isAdmin); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@address", user.Address);
                    cmd.Parameters.AddWithValue("@locationID", user.LocationID);
                    cmd.Parameters.AddWithValue("@statusAccount", user.StatusAccount);

                    cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin);


                    cn.Open();

                    user.UserID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }

        //Method to Add an Administrator in the database
        public User AddAdmin(User user, char isadmin)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Users(Firstname, Lastname,Username,  Password ,Address, LocationID, StatusAccount, IsAdmin) values(@firstname ,@lastname,@username, @password, @address, @locationID, @statusAccount, @isAdmin); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@address", user.Address);
                    cmd.Parameters.AddWithValue("@locationID", user.LocationID);
                    cmd.Parameters.AddWithValue("@statusAccount", user.StatusAccount);

                    cmd.Parameters.AddWithValue("@isAdmin", isadmin);


                    cn.Open();

                    user.UserID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }


        //Method to Update one User in the database
        //It does not update the admin status
        public User UpdateUser(User user)
        {
            var result = 0;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Users SET Firstname=@Firstname, Lastname=@Lastname, Username=@Username,  Password=@Password, Address=@Address, LocationID=@Location, StatusAccount =@StatusAccount, IsAdmin=@IsAdmin)  WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@UserID", user.UserID);

                    cmd.Parameters.AddWithValue("@Firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@LocationID", user.LocationID);
                    cmd.Parameters.AddWithValue("@StatusAccount", user.StatusAccount);
                    cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);


                    cn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return user;
        }

        //Method to delete one User in the database
        public void DeleteUser(int userid)
        {
            var result = 0;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Users WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@UserID",userid);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}