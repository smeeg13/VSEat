using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Category
    {
        //PK
        public int IdCategory  { get; set; }
        //FK
        public int IdMenu { get; set; }

        public string NameCategory  { get; set; }
        public string DescriptionCategory  { get; set; }


        public override string ToString()
        {
            return "IdCategory " +IdCategory+
            "NameCategory " + NameCategory+
            "DescriptionCategory " + DescriptionCategory;
        }
    }


}
