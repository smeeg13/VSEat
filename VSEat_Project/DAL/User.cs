using System;

namespace DAL
{
    public class User
    {
        //PK
        private int IdUser { get; set; }
        //Fk
        public int IdCity { get; set; }
        private string Lastname { get; set; }
        private string Firstname { get; set; }
        private string BirthDate { get; set; }
        private string PhoneNumber { get; set; }
        private string Email { get; set; }
        private string Address { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Status_Account { get; set; }
        public Boolean IsAdmin { get; set; }

        public User(int idUser, string lastname, string firstname, string birthDate, string phoneNumber, string email, string address, string username, string password, string status_Account, bool isAdmin)
        {
            IdUser = idUser;
            Lastname = lastname;
            Firstname = firstname;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            Username = username;
            Password = password;
            Status_Account = status_Account;
            IsAdmin = isAdmin;
        }
    }

}
