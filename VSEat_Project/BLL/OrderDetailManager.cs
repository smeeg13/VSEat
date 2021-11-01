using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderDetailManager
    {
        private IOrderDetailDB OrderDetailsDb { get; }

        public OrderDetailManager(IConfiguration conf)
        {
            OrderDetailsDb = new OrderDetailDB(conf);
        }


        public OrderDetail AddOrderDetails(OrderDetail orderDetails)
        {
            return OrderDetailsDb.AddOrderDetails(orderDetails);
        }
        
        public void DeleteOrderDetails(OrderDetail orderDetails)
        {
            OrderDetailsDb.DeleteOrderDetails(orderDetails);
        }
        
        public OrderDetail GetOrderDetails(int idOrderDetails, int TotalAmount)
        {
            return OrderDetailsDb.GetOrderDetail(idOrderDetails, TotalAmount);
        }
       
        public List<OrderDetail> GetOrdersDetails()
        {
            return OrderDetailsDb.GetOrdersDetails();
        }

        public void UpdateOrderDetailsQuantity(OrderDetail orderDetails, int newQuantity)
        {
            OrderDetailsDb.UpdateOrderDetailsQuantity(orderDetails, newQuantity);
        }
    }
}

