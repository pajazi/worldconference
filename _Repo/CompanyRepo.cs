using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Models;
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
    }

}