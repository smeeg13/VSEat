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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from User";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<User>();

                            User user = new User();

                            user.IdUser = (int)dr["idMember"];

                            if (dr["Lastname"] != null)
                                user.Lastname = (string)dr["Lastname"];

                            if (dr["Firstname"] != null)
                                user.Firstname = (string)dr["Firstname"];

                            user.BirthDate = (DateTime)dr["BirthDate"];

                            user.PhoneNumber = (string)dr["PhoneNumber"];

                            user.Email = (string)dr["Email"];

                            if (dr["Address"] != null)
                                user.Address = (string)dr["Address"];

                            if (dr["Username"] != null)
                                user.Username = (string)dr["Username"];

                            user.Password = (string)dr["Password"];

                            user.StatusAccount = (string)dr["StatusAccount"];

                            user.IsAdmin = (Boolean)dr["IsAdmin"];


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

        public User GetUser(string username, string password)
        {
            User result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from User WHERE username=@username AND password=@mypassword";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@mypassword", password);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {


                            result = new User();

                            result.IdUser = (int)dr["idMember"];

                            if (dr["Lastname"] != null)
                                result.Lastname = (string)dr["Lastname"];

                            if (dr["Firstname"] != null)
                                result.Firstname = (string)dr["Firstname"];

                            result.BirthDate = (DateTime)dr["BirthDate"];

                            result.PhoneNumber = (string)dr["PhoneNumber"];

                            result.Email = (string)dr["Email"];

                            if (dr["Address"] != null)
                                result.Address = (string)dr["Address"];

                            if (dr["Username"] != null)
                                result.Username = (string)dr["Username"];

                            result.Password = (string)dr["Password"];

                            result.StatusAccount = (string)dr["StatusAccount"];

                            result.IsAdmin = (Boolean)dr["IsAdmin"];

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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into User(Lastname,Firstname, Address, Username, Password, StatusAccount, IsAdmin) values(@lastname,@firstname, @address, @username, @password,@statusAccount, @IsAdmin); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@lastname", user.Lastname);
                    cmd.Parameters.AddWithValue("@firstname", user.Firstname);
                    cmd.Parameters.AddWithValue("@address", user.Address);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@statusAccount", user.StatusAccount);
                    cmd.Parameters.AddWithValue("@isadmin", user.IsAdmin);



                    cn.Open();

                    user.IdUser = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return user;
        }


        public void UpdateUserAddress(Order order, string newAddress)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from User SET Address = @address WHERE IdUser = @iduser";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@address", newAddress);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateUserPassword(Order order, string newPassword)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from User SET Password = @password WHERE IdUser = @iduser";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@password", newPassword);

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