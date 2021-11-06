using System.Collections.Generic;

namespace DAL
{
    public interface IOrderDetailDB
    {

        List<OrderDetail> GetOrdersDetails();

        OrderDetail GetOrderDetail(int idOrderDetails);

        OrderDetail AddOrderDetails(OrderDetail orderDetails);

        OrderDetail UpdateOrderDetails(OrderDetail orderDetails);

        void DeleteOrderDetails(int orderDetails);
    }
}