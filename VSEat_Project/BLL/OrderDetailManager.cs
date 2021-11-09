using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderDetailManager : IOrderDetailManager
    {
        private IOrderDetailDB OrderDetailsDb { get; }
        private IMenuDB MenuDb { get; }

        public OrderDetailManager(IConfiguration conf)
        {
            OrderDetailsDb = new OrderDetailDB(conf);
        }

        //Method to get all orderdetails
        public List<OrderDetail> GetOrdersDetails()
        {
            return OrderDetailsDb.GetOrdersDetails();
        }

        //Method to get all orderdetails for one order
        public List<OrderDetail> GetOrdersDetailsByOrder(int OrderID)
        {
            return OrderDetailsDb.GetOrdersDetailsByOrder(OrderID);
        }

        //Method to get all orderdetails for one menu
        public List<OrderDetail> GetOrdersDetailsByMenu(int MenuID)
        {
            return OrderDetailsDb.GetOrdersDetailsByMenu(MenuID);
        }


        //Method to get one order with his ID 
        public OrderDetail GetOrderDetailsWithID(int idOrderDetails)
        {
            return OrderDetailsDb.GetOrderDetailWithID(idOrderDetails);
        }

        //Method to get one order with his OrderID 
        public OrderDetail GetOrderDetailWithOrderID(int OrderID)
        {
            return OrderDetailsDb.GetOrderDetailWithOrderID(OrderID);
        }
        //Method to get one order with his MenuID 
        public OrderDetail GetOrderDetailWithMenuID(int MenuID)
        {
            return OrderDetailsDb.GetOrderDetailWithMenuID(MenuID);
        }

        //Method to add one order in the database
        public OrderDetail AddOrderDetails(OrderDetail orderDetails)
        {
            //Ajouté l'idOrder
            //choose menu
           
            return OrderDetailsDb.AddOrderDetails(orderDetails);
        }

        //Method to update one orderdetail in the database
        public OrderDetail UpdateOrderDetails(OrderDetail orderDetails)
        {
            return OrderDetailsDb.UpdateOrderDetails(orderDetails);
        }

        //Method to delete one order details in the database
        public void DeleteOrderDetails(int orderDetails)
        {
            //Validation
            OrderDetailsDb.DeleteOrderDetails(orderDetails);
        }

        //Update the unitprice according to the menu chosen by the user
        public OrderDetail UpdateUnitPrice(OrderDetail orderDetail, string menuName)
        {
            //Take back the unit price of the menu
            Menu menu = MenuDb.GetMenu(menuName);
            orderDetail.UnitPrice = menu.UnitPrice;

            orderDetail = OrderDetailsDb.UpdateOrderDetails(orderDetail);

            return orderDetail;
        }

        //Update the quantity chosen by the user
        public OrderDetail UpdateQuantity(OrderDetail orderDetail, int newQuantity)
        {
            orderDetail.Quantity = newQuantity;
            orderDetail = OrderDetailsDb.UpdateOrderDetails(orderDetail);

            return orderDetail;
        }

        //Update the discount
        public OrderDetail UpdateDiscount(OrderDetail orderDetail, int newDiscount)
        {
            orderDetail.Discount = newDiscount;
            orderDetail = OrderDetailsDb.UpdateOrderDetails(orderDetail);

            return orderDetail;
        }

        //Update of the total amount for the menu chosen according to the quantity, unitprice and discount
        public OrderDetail UpdateTotalAmount(OrderDetail orderDetail)
        {
            orderDetail.TotalAmount = (orderDetail.UnitPrice * orderDetail.Quantity) - orderDetail.Discount;
            orderDetail = OrderDetailsDb.UpdateOrderDetails(orderDetail);

            return orderDetail;
        }
    }
}

