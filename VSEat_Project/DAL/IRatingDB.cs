using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRatingDB
    {
        List<Rating> GetRating();
        Rating GetRating(string email, string password);
        void AddRating(Rating rating);
        void UpdateRating(Rating rating);
        void DeleteRating(int id);
    }
}
