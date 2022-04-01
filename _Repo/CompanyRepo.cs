using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Paging;
using api.Search;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CompanyRepo : Repo<Company, DataContext>
    {
        public CompanyRepo(DataContext context) : base(context)
        {

        }

        public new async Task<List<Company>> Get()
        {
            return await _context.Companies.Include(c => c.Country)
										   .ToListAsync();
        }

		public async Task<PagedList<Company>> GetCompanyTable(CompanySearchCriteria searchCriteria)
		{
			var companies = _context.Companies.Include(c => c.Country)
											  .Include(c => c.Country).AsQueryable();

			companies = ProcessSearchCriteria(companies, searchCriteria);

			return await PagedList<Company>.CreateAsync(companies, searchCriteria.PageNumber, searchCriteria.PageSize);
		}

		private IQueryable<Company> ProcessSearchCriteria(IQueryable<Company> companies, CompanySearchCriteria searchCriteria) 
        {

            if (searchCriteria.CompanyIds.Count != 0)
				companies = companies.Where(c => searchCriteria.CompanyIds.Any(id => id == c.Id));

            return companies;
        }
    }

}