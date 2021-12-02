using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IOrderDetailManager
    {
        OrderDetail AddOrderDetails(OrderDetail orderDetails);
        void DeleteOrderDetails(int orderDetails);
        OrderDetail GetOrderDetailsWithID(int idOrderDetails);
        OrderDetail GetOrderDetailWithMenuID(int MenuID);
        OrderDetail GetOrderDetailWithOrderID(int OrderID);
        List<OrderDetail> GetOrdersDetails();
        List<OrderDetail> GetOrdersDetailsByMenu(int MenuID);
        List<OrderDetail> GetOrdersDetailsByOrder(int OrderID);
        OrderDetail UpdateDiscount(OrderDetail orderDetail, int newDiscount);
        OrderDetail UpdateOrderDetails(OrderDetail orderDetails);
        OrderDetail UpdateQuantity(OrderDetail orderDetail, int newQuantity);
        OrderDetail UpdateTotalAmount(OrderDetail orderDetail);
        OrderDetail UpdateUnitPrice(OrderDetail orderDetail, string menuName);
    }
}