using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class DelivererManager
    {
        private IDelivererDB DelivererDb { get; }


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
            DelivererDB.De
        }
        public void CheckCity(Deliverer deliverer, Restaurant restaurant)
        {

        }
    }
}
