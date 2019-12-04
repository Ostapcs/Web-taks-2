using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string  Role { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public User()
        {
            Comments = new HashSet<Comment>();
            Orders = new HashSet<Order>();
        }
    }
}
