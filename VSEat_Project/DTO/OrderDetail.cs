using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
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

        
    }
}
