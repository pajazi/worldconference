using System;

namespace api.DTO
{
    public class CompanyListDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }

        public string Type { get; set; }

        public string City { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Status { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public int CountryId { get; set; }
    }
}