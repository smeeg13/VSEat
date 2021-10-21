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

        public RestaurantManager(IConfiguration conf)
        {
            RestaurantDb = new RestaurantDB(conf);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return RestaurantDb.AddRestaurant(restaurant);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            RestaurantDb.DeleteRestaurant(restaurant);
        }

        public Restaurant GetRestaurant(string nameRestaurant, string addressRestaurant)
        {
            return RestaurantDb.GetRestaurant(nameRestaurant, addressRestaurant);
        }

        public List<Restaurant> GetRestaurants()
        {
            return RestaurantDb.GetRestaurants();
        }

        public void UpdateRestaurantAddress(Restaurant restaurant, string newAddress)
        {
            RestaurantDb.UpdateRestaurantAddress(restaurant, newAddress);
        }
    }

}
