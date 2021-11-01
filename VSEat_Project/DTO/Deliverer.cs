using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
        public class Deliverer
    {
        //PK
        public int DelivereID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public int NumberOrdersAssigned { get; set; }
        public int Availability { get; set; } 

        public override string ToString()
        {
            return "IdDeliverer : " + DelivereID +
                    "Username :  " + Username +
                   "Password : " + Password +
                    "NumberOrdersAssigned : " + NumberOrdersAssigned +
                    "Availability " + Availability;       
        }
    }


}
