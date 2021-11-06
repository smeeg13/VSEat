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
        private ILocationDB LocationDb { get; }

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
        Restaurant GetRestaurantWithName(string nameRestaurant)
        {
            return RestaurantDb.GetRestaurantWithName(nameRestaurant);
        }

        //Method to get one Restaurant with his id
        Restaurant GetRestaurantWithID(int restaurantID)
        {
            return RestaurantDb.GetRestaurantWithID(restaurantID);
        }



        //Method to get the location Id of a certain Restaurant
        public string GetLocationOfRestaurant(string RestaurantName)
        {
            int locationId ;
            string locationName = null;

            Restaurant restaurant = RestaurantDb.GetRestaurantWithName(RestaurantName);
            locationId = restaurant.RestaurantID;

            Location location = LocationDb.GetLocationID(locationId);
            locationName = location.NameCity;
            return locationName;
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
