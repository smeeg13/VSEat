using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IOrderDB
    {
        Order AddOrder(Order order);
        void DeleteOrder(Order order);
        Order GetOrder(int OrderID, int UserID);
        List<Order> GetOrders();
        void UpdateOrderStatus(Order order, string newStatus);
    }
}