using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface DelivererDB
    {
        List<Deliverer> GetDeliverers();
        Order GetDeliverer(string email, string password);
        void AddDeliverer(Deliverer deliverer);
        void DeleteDeliverer(int id);
    }
}
