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
        List<Order> CountOrdersForDeliverer(Deliverer deliverer);
        List<Order> GetOrders();
        List<Order> GetOrdersForUser(int userId);
        Order GetOrderWithID(int OrderID);
        string OrderIsDelivered(Order order, Deliverer deliverer);
        string OrderIsConfirmed(Order order, User user);
        int UpdateDelivererID(Order order, Deliverer deliverer);
        Order UpdateOrder(Order order, DateTime requireddate, Boolean sameaddressuser, string shipaddress, string locationname);
        int UpdateOrderPrice(Order order, User user);
        string UpdateOrderRequiredDate(Order order, User user, DateTime newRequiredDate);
    }
}