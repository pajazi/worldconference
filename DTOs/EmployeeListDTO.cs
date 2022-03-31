using System;

namespace api.DTO
{
    public class EmployeeListDTO
    {
         public string Name { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }

        public string Status { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public int CompanyId { get; set; }
    }
}