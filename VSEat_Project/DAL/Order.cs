using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Order
    {
        private int Id_Order { get; set; }
        private DateTime Date_Order { get; set; }
        private DateTime Date_Delivery { get; set; }
        private string Delivery_Address { get; set; }
        private int Fees { get; set; }
        private int Total_Amount { get; set; }
        private string Status_Order { get; set; }

        public Order(int id_Order, DateTime date_Order, DateTime date_Delivery, string delivery_Address, int fees, int total_Amount, string status_Order)
        {
            Id_Order = id_Order;
            Date_Order = date_Order;
            Date_Delivery = date_Delivery;
            Delivery_Address = delivery_Address;
            Fees = fees;
            Total_Amount = total_Amount;
            Status_Order = status_Order;
        }
    }
}
