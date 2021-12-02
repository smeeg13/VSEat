using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IOrderDetailDB
    {
        //Method to get all orderdetails 
        List<OrderDetail> GetOrdersDetails();

        //Method to get all orderdetails for one order
        List<OrderDetail> GetOrdersDetailsByOrder(int OrderID);

        //Method to get all orderdetails for one menu
        List<OrderDetail> GetOrdersDetailsByMenu(int MenuID);

        //Method to get one order with his ID 
        OrderDetail GetOrderDetailWithID(int idOrderDetails);

        //Method to get one order with his OrderID 
        OrderDetail GetOrderDetailWithOrderID(int OrderID);

        //Method to get one order with his MenuID
        OrderDetail GetOrderDetailWithMenuID(int MenuID);

        //Method to add one order in the database
        OrderDetail AddOrderDetails(OrderDetail orderDetails);

        //Method to update one orderdetail in the database
        OrderDetail UpdateOrderDetails(OrderDetail orderDetails);

        //Method to delete one order details in the database
        void DeleteOrderDetails(int orderDetails);
    }
}