using System.Collections.Generic;

namespace DAL
{
    public interface IOrderDetailsDB
    {
        OrderDetails AddOrderDetails(OrderDetails orderDetails);
        void DeleteOrderDetails(OrderDetails orderDetails);
        OrderDetails GetOrderDetails(int idOrderDetails, int TotalAmount);
        List<OrderDetails> GetOrdersDetails();
        void UpdateOrderDetailsQuantity(OrderDetails orderDetails, int newQuantity);
    }
}