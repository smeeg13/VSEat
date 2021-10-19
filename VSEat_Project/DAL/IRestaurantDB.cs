using System.Collections.Generic;

namespace DAL
{
    public interface IRestaurantDB
    {
        Restaurant AddRestaurant(Restaurant resaurant);
        void DeleteRestaurant(Restaurant restaurant);
        Restaurant GetRestaurant(string nameRestaurant, string addressRestaurant);
        List<Restaurant> GetRestaurants();
        void UpdateRestaurantAddress(Restaurant restaurant, string newAddress);
    }
}