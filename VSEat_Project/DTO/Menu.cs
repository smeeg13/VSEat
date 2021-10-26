using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Menu
    {

        public int IdMenu { get; set; }
        public string NameMenu { get; set; }
        public int PriceMenu { get; set; }
        public int ImageMenu { get; set; } // ???? INT 
        public string IngredientsMenu { get; set; }
        public string StatusMenu { get; set; }

        public override string ToString()
        {
            return "IdMenu " + IdMenu +
                    "NameMenu " + NameMenu +
                    "PriceMenu " + PriceMenu +
                    "ImageMenu " + ImageMenu +
                    "IngredientsMenu " +IngredientsMenu +
                     "StatusMenu " + StatusMenu;
        }
    }
}
