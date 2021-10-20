using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Location
    {
        public int IdCity { get; set; }
        public string NameCity { get; set; }
        public int ZIP { get; set; }

        public override string ToString()
        {
            return "IdCity " + IdCity +
                    "NameCity " + NameCity +
                    "ZIP " + ZIP;
        }
    }
}
