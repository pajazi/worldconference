using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
	public class EmployeeRepo : Repo<Employee, DataContext>
	{
		public EmployeeRepo(DataContext context) : base(context)
		{

		}

		public new async Task<List<Employee>> Get()
		{
			return await _context.Employees.Include(c => c.Company).ToListAsync();
		}
	}

}