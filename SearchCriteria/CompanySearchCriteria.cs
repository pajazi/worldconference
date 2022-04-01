using System.Collections.Generic;

namespace api.Search
{
    public class CompanySearchCriteria : SearchCriteria
    {
        public List<int> CompanyIds { get; set; }
    }
}