using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IOrderDB
    {
        Order AddOrder(Order order);
        void DeleteOrder(Order order);
        Order GetOrder(int IdOrder, DateTime DateOrder);
        List<Order> GetOrders();
        void UpdateOrderStatus(Order order, string newStatus);
    }
}