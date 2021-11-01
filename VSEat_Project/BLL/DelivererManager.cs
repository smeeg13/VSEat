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

        public void DeleteDeliverer(Deliverer deliverer)
        {
            DelivererDb.DeleteDeliverer(deliverer);
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
    }
}
