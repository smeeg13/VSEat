using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

        public void UpdateDelivererAvailability(Deliverer deliverer)
        {
            DelivererDb.UpdateDelivererAvailability(deliverer);
        }

        public void DeliveryPerMinutes(int NumberOrdersAssigned, Order order) //requiredDate
        {
            string available = null;

            // si NumberOrdersAssigned < 5 pour 30 minutes = Ok
            // string available = yes;
            //or
            // BusinessExceptions
        }
        public void DeliveryValidation(Order order, Deliverer deliverer)
        {
            // if string available = yes 
            // sout the deliverer is available
            // or business exceptions
          
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
