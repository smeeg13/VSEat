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
   public class DelivererManager
    {
        private IDelivererDB DelivererDb { get; }
        private IRestaurantDB RestaurantDb { get; }


        public DelivererManager(IConfiguration conf)
        {
            DelivererDb = new DelivererDB(conf);
        }

        public Deliverer AddDeliverer(Deliverer deliverer)
        {
            return DelivererDb.AddDeliverer(deliverer);
        }

        public void DeleteDeliverer(int DelivererID)
        {
            DelivererDb.DeleteDeliverer(DelivererID);
        }

        public Deliverer GetDeliverer(int DelivererID)
        {
            return DelivererDb.GetDeliverer(DelivererID);
        }

        public List<Deliverer> GetDeliverers()
        {
            return DelivererDb.GetDeliverers();
        }

        public void UpdateDelivererAvailability(Deliverer deliverer, int AvailabilityDeliverer)
        {
            DelivererDb.UpdateDelivererAvailability(deliverer, AvailabilityDeliverer);
        }

        public void DeliveryPerMinutes(int NumberOrdersAssigned, Order order)
        {
            DelivererDb.DeliveryPerMinutes(NumberOrdersAssigned, order);

        }
        public void DeliveryValidation(Order order, Deliverer deliverer)
        {
           
            DelivererDB.DeliveryValidation(order, deliverer);
          
        }
        public void CheckCity(int DelivererID, int RestaurantID)
        {
            int delivererID;
            int restaurantID; 

            Deliverer deliverer = DelivererDb.GetDeliverer(DelivererID);
            delivererID = deliverer.DelivererID;

            Restaurant restaurant = RestaurantDb.GetRestaurantWithID(RestaurantID);
            restaurantID = restaurant.RestaurantID;

            if (deliverer.DelivererID != restaurant.RestaurantID)
                throw new BusinessExceptions("You must choose another deliverer !");

        }
    }
}
