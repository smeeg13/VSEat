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

        public UserDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

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

                            if (dr["Address"] != null)
                                user.Address = (string)dr["Address"];

                            user.Password = (string)dr["Password"];

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

        public User GetUser(string Firstname, string Lastname)
        {
            User result = null;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Users WHERE Firstname=@Firstname AND Lastname=@Lastname";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Firstname", Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", Lastname);

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


                            if (dr["Address"] != null)
                                result.Address = (string)dr["Address"];

                            result.Password = (string)dr["Password"];
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


        public User LogInUser(string Firstname, string Lastname, string password)
        {
            User result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Users SET StatusAccount=@StatusAccount WHERE Firstname=@Firstname AND Lastname=@Lastname AND Password=@Password";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Firstname", Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", Lastname);
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


                            if (dr["Address"] != null)
                                result.Address = (string)dr["Address"];

                            result.Password = (string)dr["Password"];
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


        public User AddUser(User user)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))


                {
                    string query = "Insert into Users(Firstname, Lastname,Username,  Password ,Address, LocationID) values(@Firstname ,@lastname,@username, @password, @address, @LocationID); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    Console.WriteLine("---- Connection String : "+ connectionString);

                    cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@address", user.Address);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@LocationID", user.LocationID);

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


        public void UpdateUserAddress(User user, string newAddress)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Users SET Address = @address WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@address", newAddress);
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateUserPassword(User user, string newPassword)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Users SET Password = @password WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}