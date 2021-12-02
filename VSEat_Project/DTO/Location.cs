using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Location
    {
        public int LocationID { get; set; }
        public string NameCity { get; set; }
        public int ZIP { get; set; }

        public override string ToString()
        {
            return "Id City : " + LocationID +
                    "Name City : " + NameCity +
                    "ZIP : " + ZIP;
        }
    }
}
