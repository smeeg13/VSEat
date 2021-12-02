using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IRestaurantDB
    {
        //Method to list all restaurants in the database
        List<Restaurant> GetRestaurants();

        //Method to list all restaurants Located in a certain city 
        List<Restaurant> GetRestaurantsByLocation(int locationID);

        //Method to get one Restaurant with his name
        Restaurant GetRestaurantWithName(string nameRestaurant);

        //Method to get one Restaurant with his ID
        Restaurant GetRestaurantWithID(int restaurantID);

        //Method to add one Restaurant in the database
        Restaurant AddRestaurant(Restaurant restaurant);

        //Method to update one Restaurant in the database
        Restaurant UpdateRestaurant(Restaurant restaurant);

        string GetLocationOfRestaurant(string RestaurantName);

        //Method to delete one Restaurant in the database
        void DeleteRestaurant(int restaurantId);

    }
}