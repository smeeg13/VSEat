using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Deliverer
    {
        //PK
        public int DelivererID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public int NumberOrdersAssigned { get; set; }
        public int Availability { get; set; }
        public int LocationID { get; set; }
        public DateTime DateAssigned { get; set; }

        public Deliverer(string username, string password, int numberOrdersAssigned, int availability, int locationId, DateTime dateAssigned)
        {
            Username = username;
            Password = password;
            NumberOrdersAssigned = numberOrdersAssigned;
            Availability = availability;
            LocationID = locationId;
            DateAssigned = dateAssigned;

        }

        public Deliverer()
        {
        }

        public override string ToString()
        {
            return "IdDeliverer : " + DelivererID +
                    "Username :  " + Username +
                   "Password : " + Password +
                    "NumberOrdersAssigned : " + NumberOrdersAssigned +
                    "Availability " + Availability;
        }
    }


}

