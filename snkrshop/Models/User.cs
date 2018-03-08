using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace snkrshop.Models
{ 
    [DataContract]
    public class User
    {
      
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Fullname { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public int Gender { get; set; }
        [DataMember]
        public int Role { get; set; }
        [DataMember]
        public DateTime RegisterDate { get; set; }

        public User(string username, string password, string email, string fullname, string address, string phone, int gender, DateTime registerDate)
        {
            Username = username;
            Password = password;
            Email = email;
            Fullname = fullname;
            Address = address;
            Phone = phone;
            Gender = gender;
            RegisterDate = registerDate;
        }

        public User(string username, string email, string fullname, string address, string phone, int gender, int role, DateTime registerDate)
        {
            Username = username;
            Email = email;
            Fullname = fullname;
            Address = address;
            Phone = phone;
            Gender = gender;
            Role = role;
            RegisterDate = registerDate;
        }
    }
}
