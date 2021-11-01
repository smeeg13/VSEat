using System;

namespace DAL
{
    public class User
    {
        
        //PK
        public int UserID { get; set; }
        //Fk
        public int LocationID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public Boolean IsAdmin { get; set; }


        public User()
        {

        }
        public User( string lastname, string firstname, string address,  string password)
        {
            Lastname = lastname;
            Firstname = firstname;
            Address = address;
            Password = password;
        }

       

        public override string ToString()
        {
            return "IdUser: " + UserID +
                   " LastName: " + Lastname +
                   " Firsname: " + Firstname +
                   " Address: " + Address +
                   "Password: " + Password+
                   " Is Admin: " + IsAdmin;

        }
    }
}
