using BLL.Interfaces;
using DAL;
using DTO;
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
        public OrderManager(IOrderDB OrderDb, IUserDB UserDb, IDelivererDB DelivererDb, IOrderDetailDB OrderDetailDb, ILocationDB LocationDb, IMenuDB MenuDb, IRestaurantDB RestaurantDb)
        {
            this.OrderDb = OrderDb;
            this.UserDb = UserDb;
            this.DelivererDb = DelivererDb;
            this.OrderDetailDb = OrderDetailDb;
            this.LocationDb = LocationDb;
            this.MenuDb = MenuDb;
            this.RestaurantDb = RestaurantDb;
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

        //Method to count all orders assigned to one particular deliverer in the database
        public List<Order> CountOrdersForDeliverer(Deliverer deliverer)
        {
            return OrderDb.CountOrdersForDeliverer(deliverer);
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
        public Order AddOrder(User user, DateTime requiredDate, string shipAddress, string locationName)
        {

            //Validation if User is connected
            string isConnected = "Connected";
            if (user.StatusAccount.Equals(isConnected))
            {
                //Add order informations that we already have ( the user ID and DateOrder = now, Status = In Progress according to the constructor)
                Order order = new Order();
                order.UserID = user.UserID;

                return OrderDb.AddOrder(order);
            }
            else
                throw new BusinessExceptions("The user should be connected to be able to make an order");
        }

        //Update data for one order
        public Order UpdateOrder(Order order,DateTime requireddate,Boolean sameaddressuser, string shipaddress, string locationname)
        {
            User user = UserDb.GetUserWithID(order.UserID);

            //the user will add a required date for his order
            order.RequiredDate = requireddate;
            order.LastChangeDate = DateTime.Now;

            //He will tell us if he want to use his address or another one which he have to give us
            order.SameAddressUser = sameaddressuser;
            if (sameaddressuser = true)
            {
                order.ShipAddress = user.Address;
                order.LocationID = user.LocationID;
            }
            else
            {
                order.ShipAddress = shipaddress;
                order.LocationID = LocationDb.GetLocationWithName(locationname);
            }

            //Ajout du deliverer ID
                //Validation if deliverer est dans la meme ville que le restaurant qui concerne l'ordre
                //with method checkCity(delivererID, restaurantID) dans deliverer manager
                //DelivererManager delivmnger = new DelivererManager(conf);

                //int delivererid = UpdateDelivererID(order);


            //Ajout du prix total de l'ordre
            order.Price = GetOrderPrice(order, user);

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
        public String UpdateOrderRequiredDate(Order order,User user, DateTime newRequiredDate)
        {
            var diffOfDates = order.LastChangeDate - DateTime.Now; //get difference of two dates
            Console.WriteLine("Difference in Minutes: {0}", diffOfDates.Minutes);

            string DateIsChanged;
            Order orderChanged = OrderDb.GetOrderForUser(order.OrderID, user.UserID);

            //GESTION DES 15 MINUTES ENTRE CHAQUE CHANGEMENT DE REQUIRED DATE
            if (diffOfDates.Minutes >= 15)
            {
                orderChanged.RequiredDate = newRequiredDate;

                orderChanged = OrderDb.UpdateOrder(orderChanged);

                DateIsChanged = "The Required Date has been changed !";
            }
            else
            {
                throw new BusinessExceptions("User muste wait a little before changing the required date");
            }
            return DateIsChanged;
        }

        //Get the final Priceof the order
        public int GetOrderPrice(Order order, User user)
        {
            Order orderChanged = OrderDb.GetOrderForUser(order.OrderID, user.UserID);

            int price = 0;

            //Reprendre tout les orders details ayant le meme orderID
            List<OrderDetail> ordersDetails = OrderDetailDb.GetOrdersDetailsByOrder(order.OrderID);

            //Adition of all total amount in order Details to form the price of the order
            foreach (OrderDetail orderDet in ordersDetails)
            {
                price += orderDet.TotalAmount;
            }

            Console.WriteLine("The Price of the order is  " + orderChanged.Price + ".-");

            return price;
        }


        //Update Deliverer Id
        public int UpdateDelivererID(Order order, Deliverer deliverer)
        {
            List<Order> nbOrdersDeliv;
            int delivererID = 0;

            //Validation Deliverer Method dans Deliverer Manager 
                //-> Met available yes
                //si deliverer est ds meme ville que restaur de l'ordre
                //ET si il n'a pas + de 5 ordres assignés

            //Maybe return true pour reprendre dans le if ???????????????????????

            /*
            if(DelivererValidation(order, deliverer) = true)
            {
                order.DelivererID =0;
            }
            */

            //Augmenter le number Orders assigned dans le deliverer qu'on a choisi plus haut
                //deliverer.NumberOrdersAssigned =+ 1;
                //deliverer = DelivererDb.UpdateDeliverer(deliverer);


            return delivererID;
        }

        public int UpdateOrderPrice(Order order, User user)
        {
            int idk=0;
            // Yooo, tu l'avais oublié, je te laisse remplir la méthode :)
            return idk;
        }

        //Method to let the deliverer confirm the delivery of the order
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

        //Method to let the user confirm his order
        public string OrderIsConfirmed(Order order, User user)
        {
            string isConfirmed;

            Order orderChanged = OrderDb.GetOrderForUser(order.OrderID, user.UserID);


            //Modifier la shipdate en mettant la date courrante
            orderChanged.OrderDate = DateTime.Now;

            //Modifier le status de l'ordre
            orderChanged.StatusOrder = "Confirmed";

            orderChanged = OrderDb.UpdateOrder(orderChanged);
            isConfirmed = "The Order has been shipped !";

            return isConfirmed;
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
