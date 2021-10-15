using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IOrderDetailsDB
    {
        List<OrderDetails> GetOrdersDetails();
        OrderDetails GetOrderDetail(string email, string password);
        void AddOrder(OrderDetails orderdetails);
        void UpdateOrderDetails(OrderDetails orderdetail);
        void DeleteOrderDetails(int id);
    }
}
