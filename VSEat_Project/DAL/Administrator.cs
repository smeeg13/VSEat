using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Administrator
    {
        private int Id_Admin;
        private string Lastname;
        private string Firstname;
        private string Birth_Date;
        private string Phone_Number;
        private string Email;
        private string Address;
        private string Username;
        private string Password;
        private string Status_Account;

        public Administrator(int id_Admin, string lastname, string firstname, string birth_Date, string phone_Number, string email, string address, string username, string password, string status_Account)
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
        public int id_Admin { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string birth_Date { get; set; }
        public string phone_Number { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string status_Account { get; set; }

    }


}
