using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Order
    {
        //PK
        public int OrderID { get; set; }
        //FK
        public int LocationID { get; set; }
        public int DelivererID { get; set; }
        public int UserID { get; set; }


        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }

        public string ShipAddress { get; set; }
        public int Price { get; set; }
        public string StatusOrder { get; set; }

        //Constructor
        public Order(User user)
        {
            this.UserID = user.UserID;
            OrderDate = DateTime.Now;
            StatusOrder = "In Progress";
        }


        public override string ToString()
        {
            return "Id Order : " + OrderID +
                "Id Location : " + LocationID +
                "Id User : " + UserID +
                "Id Deliverer : " + DelivererID +
                "Order Date  : " + OrderDate +
                "Required Date : " + RequiredDate+
                "Shipped Date : "+ ShippedDate+
                "Ship Address : "+ ShipAddress+
                "Price : "+ Price+
                "Status Order : "+ StatusOrder;
        }

    }
}
