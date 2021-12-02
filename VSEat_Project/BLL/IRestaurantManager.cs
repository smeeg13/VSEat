using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IRestaurantManager
    {
        Restaurant AddRestaurant(Restaurant restaurant);
        void DeleteRestaurant(int restaurantid);
        string GetLocationOfRestaurant(string RestaurantName);
        List<Restaurant> GetRestaurants();
        List<Restaurant> GetRestaurantsByLocation(int LocationID);
        string UpdateAddress(Restaurant restaurant, string newAddress);
        string UpdateDescription(Restaurant restaurant, string newDrescription);
        string UpdateLocation(Restaurant restaurant, string newlocation);
        Restaurant UpdateRestaurant(Restaurant restaurant);
    }
}