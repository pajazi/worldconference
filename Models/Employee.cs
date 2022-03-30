
using System;

namespace api.Models
{
    public class Employee : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }

        public string Status { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
