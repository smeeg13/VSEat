using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RestaurantManager
    {

        private IRestaurantDB RestaurantDb { get; }

        //Constructor
        public RestaurantManager(IConfiguration conf)
        {
            RestaurantDb = new RestaurantDB(conf);
        }

        //Method to list all restaurants in the database
        public List<Restaurant> GetRestaurants()
        {
            return RestaurantDb.GetRestaurants();
        }

        //???????
        //Method to list every restaurants in a certain city
        public List<string> GetRestaurantsByLocation(int LocationID)
        {
            List<Restaurant> Restaurants = new List<Restaurant>();
            List<string> locations = new List<string>();

            Restaurants = RestaurantDb.GetRestaurants();

            return locations;
        }

        //Method to get one Restaurant with his name
        public Restaurant GetRestaurant(string restaurantname)
        {
            return RestaurantDb.GetRestaurant(restaurantname);
        }

        //Method to get one Restaurant with his id
        public int GetRestaurantWithId(string restaurantName)
        {
            int RestID;
            Restaurant restaurant = RestaurantDb.GetRestaurant(restaurantName);
            RestID = restaurant.RestaurantID;

            return RestID;
        }

        //Method to get the location Id of a certain Restaurant
        public string GetLocationOfRestaurant(string RestaurantName)
        {
            int locationId ;
            string location = null;

            Restaurant restaurant = RestaurantDb.GetRestaurant(RestaurantName);
            locationId = restaurant.RestaurantID;

            //--------------------------------------------------------------------------
            //NEED LOCATION METHOD TO BE ABLE TO GET THE LOCATION NAMBE USING HIS ID
            //--------------------------------------------------------------------------

            location = "";//should add the method to GetLocation from locationManager to be able to take the name of the city

            return location;
        }

        //Method to add one Restaurant in the database
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return RestaurantDb.AddRestaurant(restaurant);
        }

        //Method to update one Restaurant in the database
        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            return RestaurantDb.UpdateRestaurant(restaurant);
        }

        //Method to delete one Restaurant in the database
        public void DeleteRestaurant(int restaurantid)
        {
            RestaurantDb.DeleteRestaurant(restaurantid);
        }
    }

}
