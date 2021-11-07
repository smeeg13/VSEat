using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public interface IOrderManager
    {
        Order AddOrder(User user, DateTime requiredDate, string shipAddress, string locationName);
        void DeleteOrder(int orderId, string firstname, string lastname);
        Location GetLocationRestaurant(Order order);
        Order GetOrderForDeliverer(int OrderID, int DelivererID);
        Order GetOrderForUser(int OrderID, int UserID);
        List<Order> GetOrders();
        List<Order> GetOrdersForDeliverer(int delivererId);
        List<Order> GetOrdersForUser(int userId);
        Order GetOrderWithID(int OrderID);
        string OrderIsDelivered(Order order, Deliverer deliverer);
        int UpdateDelivererID(Order order, Deliverer deliverer);
        Order UpdateOrder(Order order);
        int UpdateOrderPrice(Order order, User user);
        string UpdateOrderRequiredDate(Order order, User user, DateTime newRequiredDate);
    }
}