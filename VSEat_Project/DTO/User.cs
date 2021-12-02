using System;

namespace DTO
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
        public string Password { get; set; }
        public string Address { get; set; }
        public string StatusAccount { get; set; }

        public char IsAdmin { get; }


        public User()
        {

        }

        //Constructor
        public User( string lastname, string firstname, string address, int locationID,  string password)
        {
            this.Lastname = lastname;
            this.Firstname = firstname;
            this.Username = firstname +"."+ lastname;
            this.Address = address;
            this.LocationID = locationID;
            this.Password = password;
            this.StatusAccount = "Active";
            this.IsAdmin = 'n'; // no by default
            ;
        }

        public override string ToString()
        {
            return "IdUser: " + UserID +
                   " LastName: " + Lastname +
                   " Firsname: " + Firstname +
                   " Username : " + Username +
                   " Password: " + Password +
                   " Address: " + Address +
                   " LocationID : " + LocationID +
                   " StatusAccount : " + StatusAccount+
                   " Is Admin : "+ IsAdmin;
        }
    }
}
