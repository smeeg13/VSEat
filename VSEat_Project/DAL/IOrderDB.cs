using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IOrderDB
    {
        //Method to get all orders in the database
        List<Order> GetOrders();

        //Method to get all the order Assigned to one particular Deliverer in the database
        List<Order> GetOrdersForDeliverer(int delivererId);

        //Method to get all the order made by one particular User in the database
        List<Order> GetOrdersForUser(int userId);

        //Method to get one specific order with his ID
        Order GetOrderWithID(int OrderID);

        //Method to get one specific order for one deliverer in the database
        Order GetOrderForDeliverer(int OrderID, int DelivererID);

        //Method to get one specific order for one user in the database
        Order GetOrderForUser(int OrderID, int UserID);

        //Add a new order
        Order AddOrder(Order order);

        //Update data for one order
        Order UpdateOrder(Order order);

        //Delete an order
        void DeleteOrder(int orderId, int userId);

    }
}