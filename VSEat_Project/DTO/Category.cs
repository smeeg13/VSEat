using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Category
    {
        //PK
        public int CategoryID  { get; set; }
        public string CategoryName  { get; set; }
        public string Description  { get; set; }


        public override string ToString()
        {
            return "Id Category : " +CategoryID+
            "Name Category : " + CategoryName+
            "Description : " + Description;
        }
    }


}
