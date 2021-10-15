using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Rating
    {
        private int Id_Rating { get; set; }
        private int Score { get; set; }
        private string Remarks { get; set; }
        private DateTime Date_Rating { get; set; }

        public Rating(int id_Rating, int score, string remarks, DateTime date_Rating)
        {
            Id_Rating = id_Rating;
            Score = score;
            Remarks = remarks;
            Date_Rating = date_Rating;
        }
    }


}
