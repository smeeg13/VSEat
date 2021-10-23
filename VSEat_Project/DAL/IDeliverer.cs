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
        Deliverer GetDeliverer(string email, string password);
        Deliverer AddDeliverer(Deliverer deliverer);
        void DeleteDeliverer(Deliverer deliverer);
        void UpdateDeliverer(string email, string password);
    }
}
