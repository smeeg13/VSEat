using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class OrderManager
    {

        private IOrderDB OrderDb { get; }
        private IUserDB UserDb { get; }
        private IDelivererDB DelivererDb { get; }

        //Constructor
        public OrderManager(IConfiguration conf)
        {
            OrderDb = new OrderDB(conf);
        }

        //Method to get all orders in the database
        public List<Order> GetOrders()
        {
            return OrderDb.GetOrders();
        }

        //Method to get all the order Assigned to one particular Deliverer in the database
        public List<Order> GetOrdersForDeliverer(int delivererId)
        {
            return OrderDb.GetOrdersForDeliverer(delivererId);
        }

        //Method to get all the order made by one particular User in the database
        public List<Order> GetOrdersForUser(int userId)
        {
            return OrderDb.GetOrdersForUser(userId);
        }

        //Method to get one specific order for one deliverer in the database
        public Order GetOrderForDeliverer(int OrderID, int DelivererID)
        {
            return OrderDb.GetOrderForDeliverer(OrderID, DelivererID);
        }

        //Method to get one specific order for one user in the database
        public Order GetOrderForUser(int OrderID, int UserID)
        {
            return OrderDb.GetOrderForUser(OrderID, UserID);
        }

        //Add a new order
        public Order AddOrder(Order order)
        {
            //Augmenter le number Orders assigned dans le deliverer dès qu'on ajoute un order ayant son ID
            return OrderDb.AddOrder(order);
        }

        //Update data for one order
        public Order UpdateOrder(Order order)
        {
            return OrderDb.UpdateOrder(order);
        }

        //Delete an order
        public void DeleteOrder(int orderId, int userId)
        {
            //var user = UserDb.GetUser(userId);
            //var order = OrderDb.GetOrdersForUser(orderId,userId);

            //if()
            OrderDb.DeleteOrder(orderId, userId);
        }
    }
}
