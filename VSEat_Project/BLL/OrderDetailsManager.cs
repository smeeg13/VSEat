using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderDetailsManager
    {
        private IOrderDetailsDB OrderDetailsDb { get; }

        public OrderDetailsManager(IConfiguration conf)
        {
            OrderDetailsDb = new OrderDetailsDB(conf);
        }


        public OrderDetails AddOrderDetails(OrderDetails orderDetails)
        {
            return OrderDetailsDb.AddOrderDetails(orderDetails);
        }
        
        public void DeleteOrderDetails(OrderDetails orderDetails)
        {
            OrderDetailsDb.DeleteOrderDetails(orderDetails);
        }
        
        public OrderDetails GetOrderDetails(int idOrderDetails, int TotalAmount)
        {
            return OrderDetailsDb.GetOrderDetails(idOrderDetails, TotalAmount);
        }
       
        public List<OrderDetails> GetOrdersDetails()
        {
            return OrderDetailsDb.GetOrdersDetails();
        }

        public void UpdateOrderDetailsQuantity(OrderDetails orderDetails, int newQuantity)
        {
            OrderDetailsDb.UpdateOrderDetailsQuantity(orderDetails, newQuantity);
        }
    }
}

