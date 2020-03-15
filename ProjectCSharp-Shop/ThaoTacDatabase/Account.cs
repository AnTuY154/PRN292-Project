using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCSharp_Shop.DAO
{
    public class Account
    {
        private string username;
        private string password;
        public Account()
        {

        }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}