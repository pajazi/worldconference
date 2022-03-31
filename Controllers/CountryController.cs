
using System.Threading.Tasks;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CountryController : ControllerBase
	{
		private readonly CountryRepo _repo;

		public CountryController(CountryRepo repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<IActionResult> GetCountries()
		{
			var countries = await _repo.Get();
			return new JsonResult(countries);
		}
	}
}