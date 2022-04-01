using System;
using System.Collections.Generic;

namespace api.DTO
{
    public class CompanyTableListDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public List<EmployeeListDTO> Employees { get; set; }
    }
}