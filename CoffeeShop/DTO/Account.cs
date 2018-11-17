using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Account(string username, string password) {
            UserName = username;
            Password = password;
        }
    }
}
