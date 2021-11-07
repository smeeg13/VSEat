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

        //Method to list every restaurants in a certain city
        public List<Restaurant> GetRestaurantsByLocation(int LocationID)
        {
            return RestaurantDb.GetRestaurants();
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



        //Method to get the location of a certain Restaurant
        public string GetLocationOfRestaurant(string RestaurantName)
        {
            int locationId ;
            string locationName = null;
            int locationZIP;

            Restaurant restaurant = RestaurantDb.GetRestaurantWithName(RestaurantName);
            locationId = restaurant.RestaurantID;

            Location location = LocationDb.GetLocationWithID(locationId);
            locationName = location.NameCity;
            locationZIP = location.ZIP;

            return locationZIP + " " + locationName;
        }

        //Method to add one Restaurant in the database
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            if (restaurant.Address == null)
                throw new BusinessExceptions("Restaurant must have an address !");

            return RestaurantDb.AddRestaurant(restaurant);
        }

        //Method to update one Restaurant in the database
        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            return RestaurantDb.UpdateRestaurant(restaurant);
        }

        //Method to update Address of the Restaurant in the database
        public string UpdateAddress(Restaurant restaurant, string newAddress)
        {
            string AddressIsChanged = null;

            Restaurant restauUpdated = null;
            restauUpdated = RestaurantDb.GetRestaurantWithName(restaurant.RestaurantName);
            restauUpdated.Address = newAddress;
            restauUpdated = RestaurantDb.UpdateRestaurant(restauUpdated);
            AddressIsChanged = "The address has been changed !";

            return AddressIsChanged;
        }

        //Method to update LocationID of the Restaurant in the database
        public string UpdateLocation(Restaurant restaurant, string newlocation)
        {
            string LocationIsChanged = null;
            int locationId;

            Restaurant restauUpdated = null;
            restauUpdated = RestaurantDb.GetRestaurantWithName(restaurant.RestaurantName);
            locationId = LocationDb.GetLocationWithName(newlocation); //          Get the id location with the location name

            restauUpdated.LocationID = locationId;
            restauUpdated = RestaurantDb.UpdateRestaurant(restauUpdated);


            LocationIsChanged = "The locationID has been changed !";
            return LocationIsChanged;
        }

        //Method to update Description of the Restaurant in the database
        public string UpdateDescription(Restaurant restaurant, string newDrescription)
        {
            string DescriptionIsChanged = null;

            Restaurant restauUpdated = null;
            restauUpdated = RestaurantDb.GetRestaurantWithName(restaurant.RestaurantName);
            restauUpdated.DescriptionRestaurant = newDrescription;
            restauUpdated = RestaurantDb.UpdateRestaurant(restauUpdated);
            DescriptionIsChanged = "The description has been changed !";

            return DescriptionIsChanged;
        }


        //Method to delete one Restaurant in the database
        public void DeleteRestaurant(int restaurantid)
        {
            RestaurantDb.DeleteRestaurant(restaurantid);
        }
    }

}
