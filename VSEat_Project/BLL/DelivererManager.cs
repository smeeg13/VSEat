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

        public Deliverer GetDeliverer(int AvailabilityDeliverer, DateTime TimeAssigned)
        {
            return DelivererDb.GetDeliverer(AvailabilityDeliverer, TimeAssigned);
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
