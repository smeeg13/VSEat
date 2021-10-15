using System;

namespace DAL
{
    public class Customer
    {
        private int Id_Admin { get; set; }
        private string Lastname { get; set; }
        private string Firstname { get; set; }
        private string Birth_Date { get; set; }
        private string Phone_Number { get; set; }
        private string Email { get; set; }
        private string Address { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Status_Account { get; set; }

        public Customer(int id_Admin, string lastname, string firstname, string birth_Date, string phone_Number, string email, string address, string username, string password, string status_Account)
        {
            Id_Admin = id_Admin;
            Lastname = lastname;
            Firstname = firstname;
            Birth_Date = birth_Date;
            Phone_Number = phone_Number;
            Email = email;
            Address = address;
            Username = username;
            Password = password;
            Status_Account = status_Account;
        }
    }

}
