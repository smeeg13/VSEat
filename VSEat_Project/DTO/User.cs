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
        public string Username { get; set; }

        public string Address { get; set; }
        public string Password { get; set; }


        public User()
        {

        }
        public User( string lastname, string firstname, string address, int locationID,  string password)
        {
            Lastname = lastname;
            Firstname = firstname;
            Username = firstname +"."+ lastname;
            Address = address;
            LocationID = locationID;
            Password = password;
            ;
        }

       

        public override string ToString()
        {
            return "IdUser: " + UserID +
                   " LastName: " + Lastname +
                   " Firsname: " + Firstname +
                   "Username : "+ Username+
                   " Address: " + Address +
                   "Password: " + Password;

        }
    }
}
