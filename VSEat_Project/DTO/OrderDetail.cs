using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDetail
    {
        //PK
        public int OrderDetailsID { get; set; }
        //FK
        public int MenuID { get; set; }
        public int OrderID { get; set; }

        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int TotalAmount { get; set; }

        public OrderDetail()
        {

        }

        public OrderDetail(int orderId, int menuId, int unitPrice, int quantity, int discount, int totalAmount)
        {
            OrderID = orderId;
            MenuID = menuId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
            TotalAmount = totalAmount;
        }


        public override string ToString()
        {
            return "Id OrderDetail : " + OrderDetailsID +
                "Id Menu : " + MenuID +
                "Id Order : " + OrderID +
                "Unit price : " + UnitPrice +
                "Quantity : " + Quantity +
                "Discount : " + Discount+
                "TotalAmount : "+ TotalAmount;
        }

    }
}
