using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class OrderManager
    {

        private IOrderDB OrderDb { get; }

        public OrderManager(IConfiguration conf)
        {
            OrderDb = new OrderDB(conf);
        }

        public Order AddOrder(Order order)
        {
            return OrderDb.AddOrder(order);
        }
        public void DeleteOrder(Order order)
        {
            OrderDb.DeleteOrder(order);

        }
        public Order GetOrder(int IdOrder, DateTime DateOrder)
        {
            return OrderDb.GetOrder(IdOrder, DateOrder);

        }
        public List<Order> GetOrders()
        {
            return OrderDb.GetOrders();

        }
        public void UpdateOrderStatus(Order order, string newStatus)
        {
            OrderDb.UpdateOrderStatus(order, newStatus);

        }

    }
}
