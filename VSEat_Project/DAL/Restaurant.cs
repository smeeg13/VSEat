using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Restaurant
    {
        private int Id_Restaurant { get; set; }
        private string Name_Restaurant { get; set; }
        private string Description_Restaurant { get; set; }
        private string Contact { get; set; }
        private string Address_Restaurant { get; set; }

        public Restaurant(int id_Restaurant, string name_Restaurant, string description_Restaurant, string contact, string address_Restaurant)
        {
            Id_Restaurant = id_Restaurant;
            Name_Restaurant = name_Restaurant;
            Description_Restaurant = description_Restaurant;
            Contact = contact;
            Address_Restaurant = address_Restaurant;
        }
    }
}
