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
                    string query = "Select * from Restaurants";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.RestaurantID = (int)dr["RestaurantID"];

                            if (dr["RestaurantName"] != null)
                                restaurant.RestaurantName = (string)dr["RestaurantName"];

                            restaurant.DescriptionRestaurant = (string)dr["descriptionRestaurant"];

                            if (dr["AddressRestaurant"] != null)
                                restaurant.Address = (string)dr["AddressRestaurant"];


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
                    string query = "Select * from Restaurant WHERE RestaurantName=@RestaurantName AND AddressRestaurant=@Address";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@RestaurantName", nameRestaurant);
                    cmd.Parameters.AddWithValue("@Address", addressRestaurant);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {


                            result = new Restaurant();

                            result.RestaurantID = (int)dr["RestaurantID"];

                            if (dr["RestaurantName"] != null)
                                result.RestaurantName = (string)dr["RestaurantName"];

                            result.DescriptionRestaurant = (string)dr["DescriptionRestaurant"];

                            if (dr["Address"] != null)
                                result.Address = (string)dr["Address"];


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

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Restaurant(RestaurantName, Address) values(@nameRestaurant, @addressRestaurant); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nameRestaurant", restaurant.RestaurantName);
                    cmd.Parameters.AddWithValue("@addressRestaurant", restaurant.Address);


                    cn.Open();

                    restaurant.RestaurantID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        //Method to update the status of one Restaurant in the database
        public void UpdateRestaurantAddress(Restaurant restaurant, string newAddress)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Restaurant SET Address = @addressrestaurant WHERE RestaurantID = @RestaurantID";
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
                    string query = "Delete from Restaurant WHERE RestaurantID = @RestaurantID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@RestaurantID", restaurant.RestaurantID);

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