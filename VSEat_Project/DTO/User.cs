using System;

namespace DAL
{
    public class User
    {
        
        //PK
        public int IdUser { get; set; }
        //Fk
        public int IdCity { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Boolean IsAdmin { get; set; }


        public User()
        {

        }
        public User( string lastname, string firstname, string address, string username, string password)
        {
            Lastname = lastname;
            Firstname = firstname;
            Address = address;
            Username = username;
            Password = password;
        }

       

        public override string ToString()
        {
            return "IdUser: " + IdUser +
                   " LastName: " + Lastname +
                   " Firsname: " + Firstname +
                   " Address: " + Address +
                   " Username: " + Username +
                   "Password: " + Password+
                   " Is Admin: " + IsAdmin;

        }
    }
}
