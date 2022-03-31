using api.Data;
using api.Models;

namespace api.Repository
{
	public class CountryRepo : Repo<Country, DataContext>
	{
		public CountryRepo(DataContext context) : base(context)
		{

		}
	}

}