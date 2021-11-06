using System.Collections.Generic;

namespace DAL
{
    public interface IRestaurantDB
    {
        //Method to list all restaurants in the database
        List<Restaurant> GetRestaurants();

        //Method to get one Restaurant with his name
        Restaurant GetRestaurant(string nameRestaurant);

        //Method to add one Restaurant in the database
        Restaurant AddRestaurant(Restaurant restaurant);

        //Method to update one Restaurant in the database
        Restaurant UpdateRestaurant(Restaurant restaurant);

        //Method to delete one Restaurant in the database
        void DeleteRestaurant(int restaurantId);

    }
}