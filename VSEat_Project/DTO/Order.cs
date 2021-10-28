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
        public int IdOrder { get; set; }
        //FK
        public int IdOrderDetails { get; set; }
        public int IdResautant { get; set; }
        public int IdDeliverer { get; set; }
        public int IdUser { get; set; }


        public DateTime DateOrder { get; set; }
        public DateTime DateDelivery { get; set; }
        public string DeliveryAddress { get; set; }
        public int Fees { get; set; }
        public int TotalAmount { get; set; }
        public string StatusOrder { get; set; }
        public DateTime DeliveryTime { get; set; }


    }
}
