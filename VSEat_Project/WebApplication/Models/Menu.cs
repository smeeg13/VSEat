using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Menu
    {
        //PK
        public int MenuID { get; set; }
        //FK
        public int RestaurantID { get; set; }
        public int CategoryID { get; set; }
        public string MenuName { get; set; }
        public int QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public string StatusMenu { get; set; }

        public override string ToString()
        {
            return "Id Menu :" + MenuID +
                    "Name Menu :" + MenuName +
                    "Unit Price :" + UnitPrice +
                    "Units In Stock :" + UnitsInStock +
                    "Units On Order :" + UnitsOnOrder +
                    "StatusMenu " + StatusMenu;
        }
    }
}

