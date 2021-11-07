using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface IDelivererDB
    {
        List<Deliverer> GetDeliverers();
        Deliverer GetDeliverer(int DelivererID);
        Deliverer AddDeliverer(Deliverer deliverer);
        void DeleteDeliverer(int DelivererID);
        void UpdateDelivererAvailability(Deliverer deliverer);


    }
}
