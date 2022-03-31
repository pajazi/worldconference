using api.Data;
using api.Models;

namespace api.Repository
{
	public class EmployeeRepo : Repo<Employee, DataContext>
	{
		public EmployeeRepo(DataContext context) : base(context)
		{

		}
	}

}