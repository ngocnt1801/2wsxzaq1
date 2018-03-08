using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.Models
{
    public class LoginForm
    { 


        public string Username { get; set; }
        public string Password { get; set; }

        public LoginForm()
        {
        }

        public LoginForm(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}