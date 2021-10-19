using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDetails
    {
        //PK
        public int IdOrderDetails { get; set; }
        //FK
        public int IdMenu { get; set; }
        public int IdOrder { get; set; }

        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int TotalAmount { get; set; }

        
    }
}
