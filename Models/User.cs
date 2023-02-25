#nullable disable
using System;
using System.Collections.Generic;

namespace CarRentAPI.Models
{
    public partial class User
    {
        public User()
        {
            Payments = new HashSet<Payment>();
        }

        public int Nic { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}