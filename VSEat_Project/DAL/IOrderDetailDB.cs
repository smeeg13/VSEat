using System.Collections.Generic;

namespace DAL
{
    public interface IOrderDetailDB
    {
        OrderDetail AddOrderDetails(OrderDetail orderDetails);
        void DeleteOrderDetails(OrderDetail orderDetails);
        OrderDetail GetOrderDetail(int idOrderDetails, int TotalAmount);
        List<OrderDetail> GetOrdersDetails();
        void UpdateOrderDetailsQuantity(OrderDetail orderDetails, int newQuantity);
    }
}