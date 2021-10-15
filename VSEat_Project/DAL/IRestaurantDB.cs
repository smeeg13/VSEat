using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRestaurantDB
    {
        List<Restaurant> GetRestaurants();
        Order GetRestaurant(string email, string password);
        void AddRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant Restaurant);
        void DeleteRestaurant(int id);
    }
}
