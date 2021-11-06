using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderDetailManager
    {
        private IOrderDetailDB OrderDetailsDb { get; }

        public OrderDetailManager(IConfiguration conf)
        {
            OrderDetailsDb = new OrderDetailDB(conf);
        }

        public OrderDetail AddOrderDetails(OrderDetail orderDetails)
        {
            return OrderDetailsDb.AddOrderDetails(orderDetails);
        }
        
        public OrderDetail GetOrderDetails(int idOrderDetails)
        {
            return OrderDetailsDb.GetOrderDetail(idOrderDetails);
        }
       
        public List<OrderDetail> GetOrdersDetails()
        {
            return OrderDetailsDb.GetOrdersDetails();
        }

        public OrderDetail UpdateOrderDetails(OrderDetail orderDetails)
        {
             return OrderDetailsDb.UpdateOrderDetails( orderDetails);
        }

        public void DeleteOrderDetails(int orderDetails)
        {
            OrderDetailsDb.DeleteOrderDetails(orderDetails);
        }
    }
}

