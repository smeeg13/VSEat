using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using VSEat_Project;

namespace BLL
{
    public class OrderManager
    {

        private IOrderDB OrderDb { get; }
        private IUserDB UserDb { get; }
        private IDelivererDB DelivererDb { get; }
        private IOrderDetailDB OrderDetailDb { get; }

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

        //Method to get one specific order
        public Order GetOrderWithID(int OrderID)
        {
            return OrderDb.GetOrderWithID(OrderID);
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

            Deliverer deliverer = null;
            deliverer = DelivererDb.GetDeliverer(order.DelivererID);
            User user = null;
            user = UserDb.GetUserWithID(order.UserID);
            OrderDetail orderDetail = null;
            orderDetail = OrderDetailDb.AddOrderDetails(order.OrderID);

            //Validation si User is connected
            string isConnected = "Connected";
            if (user.StatusAccount.Equals(isConnected))
            {

                //Validation si le deliverer est dans la meme ville que le restaurant qui concerne l'ordre
                if (deliverer.LocationID != restaurant.locationID)
                {
                    throw new BusinessExceptions("Deliverer Should be in the same city");
                }

                //Augmenter le number Orders assigned dans le deliverer dès qu'on ajoute un order ayant son ID
                if (deliverer.NumberOrdersAssigned >= 5)
                {
                    Console.WriteLine("This Deliverer has already 5 order to delivery");
                    order.DelivererID ++;
                    deliverer.Availability = 'n';
                }
                else
                {
                    deliverer.NumberOrdersAssigned = deliverer.NumberOrdersAssigned + 1;
                }

                deliverer = DelivererDb.UpdateDeliverer(deliverer);
                order = OrderDb.UpdateOrder(order);


                return OrderDb.AddOrder(order);
            }
            else
                throw new BusinessExceptions("The user should be connected to be able to make an order");
        }

        //Update data for one order
        public Order UpdateOrder(Order order)
        {
            return OrderDb.UpdateOrder(order);
        }

        //Delete an order
        public void DeleteOrder(int orderId, string fisrtsname, string lastname)
        {
            //var user = UserDb.GetUser(userId);
            //var order = OrderDb.GetOrdersForUser(orderId,userId);

            //current date must be at least 3hours befor shippDate
            OrderDb.DeleteOrder(orderId, userId);
        }
        //Update RequiredDate for one order
        public String UpdateOrderRequiredDate(Order order, User user, DateTime newRequiredDate)
        {
            string DateIsChanged = null;

            Order orderChanged = null;
            orderChanged = OrderDb.GetOrderForUser(order.OrderID, user.UserID);
            orderChanged.RequiredDate = newRequiredDate;
            orderChanged = OrderDb.UpdateOrder(orderChanged);
            DateIsChanged = "The Required Date has been changed !";

            return DateIsChanged;
        }

        public string OrderIsDelivered(Order order, Deliverer deliverer)
        {
            string isDelivered = null;

            Order orderChanged = OrderDb.GetOrderForUser(order.OrderID, deliverer.DelivererID);
            Deliverer delivererChanged = DelivererDb.GetDeliverer(deliverer.DelivererID);

            //Décrémenter le number orders assigned du Deliverer
            delivererChanged.NumberOrdersAssigned--;

            //Modifier la shipdate en mettant la date courrant
            orderChanged.ShippedDate = DateTime.Now;

            //Modifier le status de l'ordre
            orderChanged.StatusOrder = "Shipped";


            orderChanged = OrderDb.UpdateOrder(orderChanged);
            isDelivered = "The Order has been shipped !";

            return isDelivered;
        }

        public void GetOrderLocationRestaurant()
        {



        }
    }
}
