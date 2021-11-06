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

        //Constructor
        public RestaurantDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Method to list all restaurants in the database
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

        //Method to get one Restaurant with his name
        public Restaurant GetRestaurant(string nameRestaurant)
        {
            Restaurant result = null;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Restaurants WHERE RestaurantName=@RestaurantName";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@RestaurantName", nameRestaurant);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            result = new Restaurant();

                            result.RestaurantID = (int)dr["RestaurantID"];

                            if (dr["RestaurantName"] != null)
                                result.RestaurantName = (string)dr["RestaurantName"];

                            if (dr["Address"] != null)
                                result.Address = (string)dr["Address"];

                            if (dr["LocationID"] != null)
                                result.LocationID = (int)dr["LocationID"];

                            result.DescriptionRestaurant = (string)dr["DescriptionRestaurant"];
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

        //Method to add one Restaurant in the database
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Restaurants(RestaurantName, Address, LocationID, DescriptionRestaurant) values(@RestaurantName, @Address, @LocationID, @DescriptionRestaurant); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@RestaurantName", restaurant.RestaurantName);
                    cmd.Parameters.AddWithValue("@Address", restaurant.Address);
                    cmd.Parameters.AddWithValue("@LocationID", restaurant.LocationID);
                    cmd.Parameters.AddWithValue("@DescriptionRestaurant", restaurant.DescriptionRestaurant);

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

        //Method to update one Restaurant in the database
        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var result = 0;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Update from Restaurants SET RestaurantName=@RestaurantName, Address = @Address, LocationID = @LocationID, DescriptionRestaurant = @DescriptionRestaurant WHERE RestaurantID = @RestaurantID";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@RestaurantID", restaurant.RestaurantID);

                    cmd.Parameters.AddWithValue("@RestaurantName", restaurant.RestaurantName);
                    cmd.Parameters.AddWithValue("@Address", restaurant.Address);
                    cmd.Parameters.AddWithValue("@LocationID", restaurant.LocationID);
                    cmd.Parameters.AddWithValue("@DescriptionRestaurant", restaurant.DescriptionRestaurant);

                    cn.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return restaurant;
        }


        //Method to delete one Restaurant in the database
        public void DeleteRestaurant(int restaurantId)
        {
            var result = 0;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Delete from Restaurants WHERE RestaurantID = @RestaurantID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@RestaurantID",restaurantId);

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