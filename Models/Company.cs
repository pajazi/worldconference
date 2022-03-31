
using System;
using System.Collections.Generic;

namespace api.Models
{
    public class Company : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Status { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public Country Country { get; set; }

        public ICollection<Employee> Employees { get; set; }
}
}
