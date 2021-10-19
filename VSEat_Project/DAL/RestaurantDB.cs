using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RestaurantDB : IRestaurantDB
    {
        private IConfiguration Configuration { get; }

        public RestaurantDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Restaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.IdRestaurant = (int)dr["idRestaurant"];

                            if (dr["NameRestaurant"] != null)
                                restaurant.NameRestaurant = (string)dr["nameRestaurant"];

                            restaurant.DescriptionRestaurant = (string)dr["descriptionRestaurant"];

                            restaurant.Contact = (string)dr["contact"];

                            if (dr["AddressRestaurant"] != null)
                                restaurant.AddressRestaurant = (string)dr["addressRestaurant"];


                            results.Add(restaurant);

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

        public Restaurant GetRestaurant(string nameRestaurant, string addressRestaurant)
        {
            Restaurant result = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Restaurant WHERE username=@nameresautant AND password=@addressrestaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nameresautant", nameRestaurant);
                    cmd.Parameters.AddWithValue("@addressrestaurant", addressRestaurant);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {


                            result = new Restaurant();

                            result.IdRestaurant = (int)dr["idRestaurant"];

                            if (dr["NameRestaurant"] != null)
                                result.NameRestaurant = (string)dr["NameRestaurant"];

                            result.DescriptionRestaurant = (string)dr["descriptionRestaurant"];

                            result.Contact = (string)dr["contact"];

                            if (dr["AddressRestaurant"] != null)
                                result.AddressRestaurant = (string)dr["addressRestaurant"];


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

        public Restaurant AddRestaurant(Restaurant resaurant)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Restaurant(NameRestaurant, AddressRestaurant) values(@nameRestaurant, @addressRestaurant); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nameRestaurant", resaurant.NameRestaurant);
                    cmd.Parameters.AddWithValue("@addressRestaurant", resaurant.AddressRestaurant);


                    cn.Open();

                    resaurant.IdRestaurant = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return resaurant;
        }

        //Method to update the status of one Restaurant in the database
        public void UpdateRestaurantAddress(Restaurant restaurant, string newAddress)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Restaurant SET AddressRestaurant = @addressrestaurant WHERE IdRestaurant = @idrestaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@addressrestaurant", newAddress);

                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //Method to delete one Restaurant in the database
        public void DeleteRestaurant(Restaurant restaurant)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Restaurant WHERE IdRestaurant = @idrestaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idrestaurant", restaurant.IdRestaurant);

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