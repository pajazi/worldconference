
using System.Collections.Generic;

namespace api.Models
{
    public class Country : IModel
    {
        public int Id { get; set; }

        public string RegionCode { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
