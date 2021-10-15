using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDetails
    {
        private int Id_OrderDetails { get; set; }
        private int Unit_Price { get; set; }
        private int Quantity { get; set; }
        private int Discount { get; set; }

        public OrderDetails(int id_OrderDetails, int unit_Price, int quantity, int discount)
        {
            Id_OrderDetails = id_OrderDetails;
            Unit_Price = unit_Price;
            Quantity = quantity;
            Discount = discount;
        }
    }
}
