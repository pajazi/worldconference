using api.Data;
using api.Models;

namespace api.Repository
{
	public class CompanyRepo : Repo<Company, DataContext>
	{
		public CompanyRepo(DataContext context) : base(context)
		{

		}
	}

}