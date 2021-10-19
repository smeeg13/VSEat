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
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string StatusAccount { get; set; }
        public Boolean IsAdmin { get; set; }


        public User()
        {

        }
        public User( string lastname, string firstname, string email, string address, string username, string password, string statusAccount)
        {
            Lastname = lastname;
            Firstname = firstname;
            Email = email;
            Address = address;
            Username = username;
            Password = password;
            StatusAccount = statusAccount;
            IsAdmin = false;
        }

       

        public override string ToString()
        {
            return "IdUser: " + IdUser +
                   " LastName: " + Lastname +
                   " Firsname: " + Firstname +
                   " Birth Date: " + BirthDate +
                   " Email: " + Email +
                   " Address: " + Address +
                   " Username: " + Username +
                   "Password: " + Password+
                   " Status Account: " + StatusAccount +
                   " Is Admin: " + IsAdmin;

        }

    }



}
