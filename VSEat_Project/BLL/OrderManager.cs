using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using VSEat_Project;

namespace BLL
{
    public class OrderManager : IOrderManager
    {

        private IOrderDB OrderDb { get; }
        private IUserDB UserDb { get; }
        private IDelivererDB DelivererDb { get; }
        private IOrderDetailDB OrderDetailDb { get; }
        private ILocationDB LocationDb { get; }
        private IMenuDB MenuDb { get; }
        private IRestaurantDB RestaurantDb { get; }

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

        //Method to get one specific order with his ID
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
        public Order AddOrder(User user)
        {
            int locationID = LocationDb.GetLocationWithName(locationName);

            //Validation if User is connected
            string isConnected = "Connected";
            if (user.StatusAccount.Equals(isConnected))
            {
                //Add order informations
                Order order = new Order();
                order.UserID = user.UserID;
                //Ajout du deliverer ID
                    //Validation if deliverer est dans la meme ville que le restaurant qui concerne l'ordre
                    //with method checkCity(delivererID, restaurantID) dans deliverer manager
                    //DelivererManager delivmnger = new DelivererManager(conf);

                //Augmenter le number Orders assigned dans le deliverer dès qu'on ajoute un order ayant son ID
                    //deliverer = DelivererDb.UpdateDeliverer(deliverer);

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
        public void DeleteOrder(int orderId, string firstname, string lastname)
        {
            //Check that the firstname and the lastname correspond to the user who made the order
            var userId = UserDb.GetUserIDWithName(firstname, lastname);
            var user = UserDb.GetUserWithID(userId);
            var order = OrderDb.GetOrderForUser(orderId, userId);

            //current date must be at least 3 hours before shipped Date
            var diffOfDates = order.RequiredDate - DateTime.Now; //get difference of two dates
            Console.WriteLine("Difference in Hours: {0}", diffOfDates.Hours);

            if (diffOfDates.Hours >= 3)
            {
                OrderDb.DeleteOrder(orderId, userId);
            }
            else
            {
                throw new BusinessExceptions("You cannot delete an order less than 3 hours before its delivery");
            }
        }


        //Update RequiredDate for one order
        public String UpdateOrderRequiredDate(Order order, User user, DateTime newRequiredDate)
        {

            //GESTION DES 15 MINUTES EN + !!!!
            string DateIsChanged;

            Order orderChanged = OrderDb.GetOrderForUser(order.OrderID, user.UserID);

            orderChanged.RequiredDate = newRequiredDate;

            orderChanged = OrderDb.UpdateOrder(orderChanged);

            DateIsChanged = "The Required Date has been changed !";

            return DateIsChanged;
        }

        //Update RequiredDate for one order
        public int UpdateOrderPrice(Order order, User user)
        {
            int price = 0;
            //Reprendre tout les orders details ayant le meme orderID
            List<OrderDetail> ordersDetails = OrderDetailDb.GetOrdersDetailsByOrder(order.OrderID);

            //Adition of all total amount in order Details to form the price of the order
            foreach (OrderDetail orderDet in ordersDetails)
            {
                price += orderDet.TotalAmount;
            }

            //Update in the DB
            Order orderChanged = OrderDb.GetOrderForUser(order.OrderID, user.UserID);
            orderChanged.Price = price;
            orderChanged = OrderDb.UpdateOrder(orderChanged);

            Console.WriteLine("The Price of the order is  " + orderChanged.Price + ".-");

            return orderChanged.Price;
        }


        //Update Deliverer Id
        public int UpdateDelivererID(Order order, Deliverer deliverer)
        {
            int delivererID = 0;
            
            //CheckCity
            if(available = "yes")
            {
                order.DelivererID = deliverer.DelivererID;
            }


            return delivererID;
        }

        public string OrderIsDelivered(Order order, Deliverer deliverer)
        {
            string isDelivered;

            Order orderChanged = OrderDb.GetOrderForDeliverer(order.OrderID, deliverer.DelivererID);
            Deliverer delivererChanged = DelivererDb.GetDeliverer(deliverer.DelivererID);

            //Décrémenter le number orders assigned du Deliverer
            delivererChanged.NumberOrdersAssigned--;

            //Modifier la shipdate en mettant la date courrante
            orderChanged.ShippedDate = DateTime.Now;

            //Modifier le status de l'ordre
            orderChanged.StatusOrder = "Shipped";

            orderChanged = OrderDb.UpdateOrder(orderChanged);
            isDelivered = "The Order has been shipped !";

            return isDelivered;
        }

        public Location GetLocationRestaurant(Order order)
        {
            OrderDetail orderDetail = OrderDetailDb.GetOrderDetailWithOrderID(order.OrderID);
            Menu menu = MenuDb.GetMenuWithID(orderDetail.MenuID);

            Restaurant restaurant = RestaurantDb.GetRestaurantWithID(menu.RestaurantID);
            Location location = LocationDb.GetLocationWithID(restaurant.LocationID);

            return location;
        }
    }
}
